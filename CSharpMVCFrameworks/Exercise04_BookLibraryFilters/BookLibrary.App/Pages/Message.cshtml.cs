using BookLibrary.App.Auxiliary;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookLibrary.App.Pages.Shared
{
    public class MessageModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet(int msgId)
        {
            this.Message = StaticMessages.Msg[msgId];
        }
    }
}