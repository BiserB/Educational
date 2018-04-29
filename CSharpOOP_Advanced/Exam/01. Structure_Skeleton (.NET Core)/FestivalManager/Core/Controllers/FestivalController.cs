namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

		private readonly IStage stage;

        private IPerformerFactory performerFactory;
        private IInstrumentFactory instrumentFactory;

        private ISetFactory setFactory;
        private ISongFactory songFactory;

        public FestivalController(IStage stage, IInstrumentFactory instrumentFactory, IPerformerFactory performerFactory, 
            ISetFactory setFactory, ISongFactory songFactory)
		{
			this.stage = stage;
            this.instrumentFactory = instrumentFactory;
            this.performerFactory = performerFactory;
            this.setFactory = setFactory;
            this.songFactory = songFactory;
        }

		public string ProduceReport()
		{
			string result = string.Empty;

			TimeSpan totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

			result += ($"Festival length: {(totalFestivalLength).ToString(TimeFormat)}") + "\n";

			foreach (var set in this.stage.Sets)
			{
				result += ($"--{set.Name} ({(set.ActualDuration).ToString(TimeFormat)}):") + "\n";

				var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					result += ($"---{performer.Name} ({instruments})") + "\n";
				}

				if (!set.Songs.Any())
					result += ("--No songs played") + "\n";
				else
				{
					result += ("--Songs played:") + "\n";
					foreach (var song in set.Songs)
					{
						result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
					}
				}
			}

			return result.ToString();
		}

		public string RegisterSet(string[] args)
		{
            string name = args[0];

            string type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);

            this.stage.AddSet(set);

            return $"Registered {type} set";
        }

		public string SignUpPerformer(string[] args)
		{
			string name = args[0];
			int age = int.Parse(args[1]);

			string[] arguments = args.Skip(2).ToArray();

			IInstrument[] currentInstruments = arguments
				                .Select(i => this.instrumentFactory.CreateInstrument(i))
				                .ToArray();

			IPerformer performer = this.performerFactory.CreatePerformer(name, age);

			foreach (var instrument in currentInstruments)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
            //CultureInfo culture = CultureInfo.CurrentCulture;

            string name = args[0];

            string[] time = args[1].Split(':');

            int minutes = int.Parse(time[0]);
            int seconds = int.Parse(time[1]);

            TimeSpan duration = new TimeSpan(0,0,minutes,seconds,0);

            ISong song = this.songFactory.CreateSong(name, duration);

            this.stage.AddSong(song);

            return $"Registered song {song}";
		}

		public string SongRegistration(string[] args)
		{
			var songName = args[0];
			var setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException("Invalid song provided");
			}

			ISet set = this.stage.GetSet(setName);
			ISong song = this.stage.GetSong(songName);

			set.AddSong(song);

			return $"Added {song} to {set.Name}";
		}

		
		public string AddPerformerToSet(string[] args)
		{
            var performerName = args[0];
            var setName = args[1];

            var performer = this.stage.GetPerformer(performerName);

            if (performer == null)
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            var set = this.stage.GetSet(setName);

            if (set == null)
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }
        		

		public string RepairInstruments(string[] args)
		{
			IInstrument[] instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            ISet set = this.stage.GetSet(setName);

            if (set == null)
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            ISong song = this.stage.GetSong(songName);

            if (song == null)
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            set.AddSong(song);            

            return $"Added {songName} ({song.Duration:mm\\:ss}) to {setName}";
        }
    }
}