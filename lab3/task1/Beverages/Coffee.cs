
namespace task1.Beverages
{
	class Coffee : Beverage
	{
		public Coffee(string descrition)
			: base("Coffee" + descrition)
		{
		}

		public override double GetCost()
		{
			return 60;
		}
	}
}
