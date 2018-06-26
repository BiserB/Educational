namespace MyTube.App.Controllers
{
    using MyTube.App.Utils;
    using MyTube.Data;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Wellcome();
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Wellcome()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Index();
            }

            this.Model["username"] = this.User.Name;

            using (var db = new MyTubeDbContext())
            {
                var allTubes = db.Tubes.ToList();

                string tubeCard = File.ReadAllText(Paths.PartialViewsPath + "TubeCard.html");

                StringBuilder allTubesView = new StringBuilder();

                foreach (var tube in allTubes)
                {
                    string tubeView = string.Format(tubeCard,
                                                            tube.Id,
                                                            tube.YouTubeId,
                                                            tube.Title,
                                                            tube.Author);

                    allTubesView.AppendLine(tubeView);
                }

                this.Model["allTubes"] = allTubesView.ToString();
            }

            return this.View();
        }
    }
}