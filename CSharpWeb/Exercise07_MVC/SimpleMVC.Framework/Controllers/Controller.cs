namespace SimpleMVC.Framework.Controllers
{
    using SimpleMVC.Framework.Interfaces;
    using SimpleMVC.Framework.Interfaces.Generic;
    using SimpleMVC.Framework.ViewEngine;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string caller = "")
        {
            string fullQualifiedName = this.GetFullyQualifiedName(caller, this.GetType().Name);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult View(string controllerName, string action)
        {
            string fullQualifiedName = this.GetFullyQualifiedName(action, controllerName);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName] string caller = "")
        {
            string fullQualifiedName = this.GetFullyQualifiedName(caller, this.GetType().Name);

            return new ActionResult<T>(fullQualifiedName, model);
        }

        protected IActionResult<T> View<T>(T model, string controllerName, string action)
        {
            string fullQualifiedName = this.GetFullyQualifiedName(action, controllerName);

            return new ActionResult<T>(fullQualifiedName, model);
        }

        private string GetFullyQualifiedName(string caller, string controller)
        {
            string controllerName = controller.Replace(MvcContext.Get.ControllersSuffix, string.Empty);

            string fullQualifiedName = string.Format(
                                            "{0}.{1}.{2}.{3}, {0}",
                                            MvcContext.Get.AssemblyName,
                                            MvcContext.Get.ViewsFolder,
                                            controllerName,
                                            caller);
            return fullQualifiedName;
        }
    }
}