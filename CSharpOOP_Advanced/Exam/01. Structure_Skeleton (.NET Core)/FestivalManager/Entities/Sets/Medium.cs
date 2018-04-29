namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
		public Medium(string name)
			: base(name, new TimeSpan(0, 0, 40, 0, 0))
		{
			
		}
	}
}