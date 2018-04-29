
using System;
using System.Linq;
namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using FestivalManager.Entities.Factories.Contracts;
    using IO.Contracts;


    public class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;        

        private IFestivalController festivalController;
        private ISetController setController;
        

        public Engine(IReader reader, IWriter writer, 
            IFestivalController festivalController, ISetController setController)
        {
            this.reader = reader;
            this.writer = writer;

            this.festivalController = festivalController;
            this.setController = setController;
        }

        public void Run()
		{            

			while (true) 
			{
				string input = this.reader.ReadLine();

				if (input == "END")
					break;

				try
				{
					//string.Intern(input);

					string result = this.ProcessCommand(input);                    

					this.writer.WriteLine(result);
				}
				catch (Exception ex) 
				{
					this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
				}
			}

			string end = this.festivalController.ProduceReport().TrimEnd();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			string[] args = input.Split(" ".ToCharArray().First());

            string command = args.First();

            string[] data = args.Skip(1).ToArray();

			if (command == "LetsRock")
			{
				string sets = this.setController.PerformSets();

				return sets;
			}
           
			MethodInfo festivalcontrolfunction = this.festivalController.GetType()
				                                .GetMethods()
				                                .FirstOrDefault(x => x.Name == command);

            string result = "";

            if (festivalcontrolfunction != null)
            {
                result = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { data });
            }           


            return result;
		}
	}
}