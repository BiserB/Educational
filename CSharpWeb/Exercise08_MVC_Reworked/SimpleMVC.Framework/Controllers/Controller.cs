namespace SimpleMVC.Framework.Controllers
{
    using SimpleMVC.Framework.ActionResults;
    using SimpleMVC.Framework.Attributes.Properties;
    using SimpleMVC.Framework.Interfaces;
    using SimpleMVC.Framework.Models;
    using SimpleMVC.Framework.Security;
    using SimpleMVC.Framework.Views;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using WebServer.Http;
    using WebServer.Http.Contracts;

    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
            this.User = new Authentication();
        }

        public ViewModel Model { get; internal set; }

        public IHttpRequest Request { get; internal set; }

        public Authentication User { get; private set; }

        protected internal void InitializeController()
        {
            var user = this.Request.Session
                            .Get<string>(SessionStore.CurrentUserKey);
            if (user != null)
            {
                this.User = new Authentication(user);
            }
        }

        protected void SignIn(string name)
        {
            this.Request.Session.Add(SessionStore.CurrentUserKey, name);
        }

        protected void SignOut()
        {
            this.Request.Session.Clear();
        }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            this.InitializeViewModelData();

            string fullQualifiedName = this.GetFullyQualifiedName(caller);

            IRenderable view = new View(fullQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }

        protected bool IsValidModel(object bindingModel)
        {
            foreach (var property in bindingModel.GetType().GetProperties())
            {
                var attributes = property
                                 .GetCustomAttributes()
                                 .Where(a => a is ValidationAttribute);

                if (!attributes.Any())
                {
                    continue;
                }

                foreach (ValidationAttribute attribute in attributes)
                {
                    var value = property.GetValue(bindingModel);

                    var validationResult = attribute.GetValidationResult(value, new ValidationContext(bindingModel));

                    if (validationResult != ValidationResult.Success)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private string GetFullyQualifiedName(string caller)
        {
            string controllerName = this.GetType().Name
                                        .Replace(MvcContext.Get.ControllersSuffix, string.Empty);

            string fullQualifiedName = string.Format(
                                            "{0}\\{1}\\{2}",
                                            MvcContext.Get.ViewsFolder,
                                            controllerName,
                                            caller);
            return fullQualifiedName;
        }

        private void InitializeViewModelData()
        {
            if (this.User.IsAuthenticated)
            {
                this.Model["onGuest"] = "none";
                this.Model["onUser"] = "block";
                this.Model["onAdmin"] = "";
            }
            else
            {
                this.Model["onGuest"] = "block";
                this.Model["onUser"] = "none";
                this.Model["onAdmin"] = "";
            }
        }
    }
}