namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
        private const int RepairAmountConst = 60;

        protected override int RepairAmount => RepairAmountConst;
    }
}
