using task1.Beverages;

namespace task1.Condiments
{
	class Cream : CondimentDecorator
	{
		public Cream(IBeverage beverage)
			: base(beverage)
		{
		}

		protected override double GetCondimentCost()
		{
			return 25;
		}

		protected override string GetCondimentDescription()
		{
			return " Cream ";
		}
	}
}
