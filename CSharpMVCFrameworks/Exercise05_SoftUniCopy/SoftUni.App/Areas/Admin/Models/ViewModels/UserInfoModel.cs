using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUni.App.Areas.Admin.Models.ViewModels
{
    public class UserInfoModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }
    }
}
