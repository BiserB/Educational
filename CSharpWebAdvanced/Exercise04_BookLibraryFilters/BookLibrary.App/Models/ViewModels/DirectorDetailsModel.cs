using System.Collections.Generic;

namespace BookLibrary.App.Models.ViewModels
{
    public class DirectorDetailsModel
    {
        public string DirectorName { get; set; }

        public List<MovieShortInfoModel> Movies { get; set; } = new List<MovieShortInfoModel>();
    }
}