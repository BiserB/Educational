namespace FestivalManager.Entities.Instruments
{
	public class Drums : Instrument
	{
        private const int RepairAmountConst = 20;

        protected override int RepairAmount => RepairAmountConst;
	}
}
