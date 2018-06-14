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
        private IHttpRequest request;
        private IDictionary<string, string> getParams;
        private IDictionary<string, string> postParams;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private object[] methodParams;

        public IHttpResponse Handle(IHttpRequest request)
        {
            this.request = request;

            this.getParams = request.UrlParameters;

            this.postParams = request.FormData;

            this.requestMethod = request.Method.ToString();

            this.controllerName = GetControllerName(request.Path);

            this.actionName = GetActionName(request.Path);

            MethodInfo method = this.GetMethod();

            if (method == null)
            {
                return new NotFoundResponse();
            }

            MapMethodParameters(method);

            IInvocable actionResult = (IInvocable)method.Invoke(this.GetController(), this.methodParams);

            string content = actionResult.Invoke();

            IHttpResponse response = new ContentResponse(HttpStatusCode.Ok, content);

            return response;
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

        private MethodInfo GetMethod()
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in this.GetSuitableMethods())
            {
                IEnumerable<Attribute> attributes = methodInfo
                                                    .GetCustomAttributes()
                                                    .Where(a => a is HttpMethodAttribute)
                                                    .ToList();

                if (!attributes.Any() && this.requestMethod == "GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(this.requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }
            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            var conroller = this.GetController();

            if (conroller == null)
            {
                return new MethodInfo[0];
            }

            return this.GetController()
                       .GetType()
                       .GetMethods()
                       .Where(m => m.Name == this.actionName);
        }

        private Controller GetController()
        {
            var controllerFullQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                this.controllerName);

            Type type = Type.GetType(controllerFullQualifiedName);

            if (type == null)
            {
                return null;
            }

            var controller = (Controller)Activator.CreateInstance(type);

            return controller;
        }

        private void MapMethodParameters(MethodInfo method)
        {
            IEnumerable<ParameterInfo> parameters = method.GetParameters();

            this.methodParams = new object[parameters.Count()];

            int index = 0;

            foreach (ParameterInfo param in parameters)
            {
                if (param.ParameterType.IsPrimitive || param.ParameterType == typeof(string))
                {
                    object value = this.getParams[param.Name];
                    this.methodParams[index] = Convert.ChangeType(value, param.ParameterType);
                }
                else
                {
                    Type bindingModelType = param.ParameterType;
                    object bindingModel = Activator.CreateInstance(bindingModelType);
                    IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

                    foreach (var property in properties)
                    {
                        property.SetValue(bindingModel,
                            Convert.ChangeType(postParams[property.Name], property.PropertyType));
                    }

                    this.methodParams[index] = Convert.ChangeType(bindingModel, bindingModelType);
                }
                index++;
            }
        }
    }
}