namespace SimpleMVC.Framework.Interfaces
{
    public interface IRedirectable : IActionResult
    {
        string RedirectUrl { get; }
    }
}