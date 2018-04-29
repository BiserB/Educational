namespace FestivalManager
{
	using System.IO;
	using System.Linq;
	using Core;
	using Core.Contracts;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;
    using FestivalManager.Entities.Factories;

    public static class StartUp
	{
		public static void Main()
		{
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

			IStage stage = new Stage();

            IInstrumentFactory instrumentFactory = new InstrumentFactory();
            IPerformerFactory performerFactory = new PerformerFactory();
            ISetFactory setFactory = new SetFactory();
            ISongFactory songFactory = new SongFactory();

            IFestivalController festivalController = new FestivalController
                (stage, instrumentFactory, performerFactory, setFactory, songFactory);
			ISetController setController = new SetController(stage);
            

			var engine = new Engine(reader, writer, festivalController, setController);

			engine.Run();
		}
	}
}