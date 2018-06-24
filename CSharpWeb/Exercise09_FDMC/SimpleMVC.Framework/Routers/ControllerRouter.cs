namespace SimpleMVC.Framework.Routers
{
    using SimpleMVC.Framework.Attributes.Methods;
    using SimpleMVC.Framework.Controllers;
    using SimpleMVC.Framework.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Exceptions;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ControllerRouter : IHandleable
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            var getParams = request.UrlParameters;

            var postParams = request.FormData;

            var requestMethod = request.Method.ToString();

            var path = CorrectThePath(request.Path);

            var controllerName = GetControllerName(path);

            var actionName = GetActionName(path);

            Controller controller = this.GetController(controllerName, request);

            MethodInfo method = this.GetMethod(controller, requestMethod, actionName);

            if (method == null)
            {
                return new NotFoundResponse();
            }

            var parameters = method.GetParameters();

            object[] methodParams = this.AddParameters(parameters, getParams, postParams, requestMethod);

            try
            {
                IHttpResponse response = GetResponse(controller, method, methodParams);
                return response;
            }
            catch (Exception e)
            {
                return new InternalServerErrorResponse(e);
            }
        }

        private string CorrectThePath(string path)
        {
            if (path == "/")
            {
                path = "/home/index";
            }

            return path;
        }

        private string GetControllerName(string path)
        {
            string[] parts = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                throw new BadRequestException("Invalid count of path elements.");
            }

            string ctrlName = char.ToUpper(parts[0][0]) + parts[0].Substring(1);

            return ctrlName + MvcContext.Get.ControllersSuffix;
        }

        private string GetActionName(string path)
        {
            string[] parts = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            string actionName = char.ToUpper(parts[1][0]) + parts[1].Substring(1);

            return actionName;
        }

        private MethodInfo GetMethod(Controller controller, string requestMethod, string actionName)
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in this.GetSuitableMethods(controller, actionName))
            {
                IEnumerable<Attribute> attributes = methodInfo
                                                    .GetCustomAttributes()
                                                    .Where(a => a is HttpMethodAttribute)
                                                    .ToList();

                if (!attributes.Any() || requestMethod == "GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }
            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller
                       .GetType()
                       .GetMethods()
                       .Where(m => m.Name.ToLower() == actionName.ToLower());
        }

        private Controller GetController(string controllerName, IHttpRequest request)
        {
            var controllerFullQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                controllerName);

            Type type = Type.GetType(controllerFullQualifiedName);

            if (type == null)
            {
                return null;
            }

            var controller = (Controller)Activator.CreateInstance(type);

            if (controller != null)
            {
                controller.Request = request;
                controller.InitializeController();
            }

            return controller;
        }

        private object[] AddParameters(ParameterInfo[] parameters, IDictionary<string, string> getParams, IDictionary<string, string> postParams, string requestMethod)
        {
            object[] methodParams = new object[parameters.Count()];

            int index = 0;

            foreach (ParameterInfo param in parameters)
            {
                if (param.ParameterType.IsPrimitive || param.ParameterType == typeof(string))
                {
                    object value = null;

                    if (requestMethod.ToUpper() == "GET")
                    {
                        value = getParams[param.Name];
                    }
                    else
                    {
                        value = postParams[param.Name];
                    }

                    methodParams[index] = Convert.ChangeType(value, param.ParameterType);
                }
                else
                {
                    Type bindingModelType = param.ParameterType;
                    object bindingModel = Activator.CreateInstance(bindingModelType);
                    PropertyInfo[] properties = bindingModelType.GetProperties();

                    foreach (var property in properties)
                    {
                        property.SetValue(bindingModel,
                            Convert.ChangeType(postParams[property.Name], property.PropertyType));
                    }

                    methodParams[index] = Convert.ChangeType(bindingModel, bindingModelType);
                }
                index++;
            }

            return methodParams;
        }

        private static IHttpResponse GetResponse(Controller controller, MethodInfo method, object[] methodParams)
        {
            IActionResult actionResult = (IActionResult)method.Invoke(controller, methodParams);

            string invocationResult = actionResult.Invoke();

            if (actionResult is IViewable)
            {
                return new ContentResponse(HttpStatusCode.Ok, invocationResult);
            }
            if (actionResult is IRedirectable)
            {
                return new RedirectResponse(invocationResult);
            }

            throw new InvalidOperationException("Not supported actionResult!");
        }
    }
}