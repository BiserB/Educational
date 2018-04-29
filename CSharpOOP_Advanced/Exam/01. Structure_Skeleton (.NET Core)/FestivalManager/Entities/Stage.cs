namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;
    using System.Linq;
    using System;

    public class Stage : IStage
    {
        private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets { get { return this.sets; } }

        public IReadOnlyCollection<ISong> Songs { get { return this.songs; } }

        public IReadOnlyCollection<IPerformer> Performers { get { return this.performers; } }

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = this.Performers.FirstOrDefault(p => p.Name == name);

            //if (performer == null)
            //{
            //    throw new ArgumentException("Pperformer with name {0} doesn't exists!");
            //}

            return performer;
        }

        public ISet GetSet(string name)
        {
            ISet set = this.Sets.FirstOrDefault(s => s.Name == name);
            
            return set;
        }

        public ISong GetSong(string name)
        {
            ISong song = this.Songs.FirstOrDefault(s => s.Name == name);            

            return song;
        }

        public bool HasPerformer(string name)
        {
            return GetPerformer(name) != null;
        }

        public bool HasSet(string name)
        {
            return GetSet(name) != null;
        }

        public bool HasSong(string name)
        {
            return GetSong(name) != null;
        }
    }
}
