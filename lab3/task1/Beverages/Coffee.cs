
namespace task1.Beverages
{
	class Coffee : Beverage
	{
		public Coffee(string description)
			: base("Coffee" + description)
		{
		}

		public override double GetCost()
		{
			return 60;
		}
	}
}
