namespace SimpleMVC.Framework.Interfaces
{
    public interface IActionResult : IInvocable
    {
        IRenderable Action { get; set; }
    }
}