using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.App.Auxiliary;
using Microsoft.AspNetCore.Mvc;
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