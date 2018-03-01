// Name – a string
// TotalTime – a floating-point number
// Car - parameter of type Car
// FuelConsumptionPerKm – a floating-point number
// Speed – a floating-point number

namespace t01.Models
{
    internal class Car
    {
        private readonly decimal MAX_CAPACITY = 160m;

        private int hp;
        private decimal fuelAmount;
        private Tyre tyreType;

        public Tyre TyreType
        {
            get { return tyreType; }
            set { tyreType = value; }
        }
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public decimal FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public void ConsumeFuel()
        {

        }

    }
}