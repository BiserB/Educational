﻿namespace SimpleMvc.App.ViewModels
{
    using System.Collections.Generic;

    public class UserProfileViewModel
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public IEnumerable<NoteViewModel> Notes { get; set; }
    }
}