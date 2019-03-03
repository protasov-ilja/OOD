using task1.Beverages;

namespace task1.Condiments
{
    class Liquor : CondimentDecorator
    {
		private LiquorType m_liquorType;

		public Liquor(IBeverage beverage, LiquorType liquorType)
			: base(beverage)
		{
			m_liquorType = liquorType;
		}

		protected override double GetCondimentCost()
		{
			return 50;
		}

		protected override string GetCondimentDescription()
		{
			return (m_liquorType == LiquorType.Chocolate ? "Chocolate" : "Nut") + " Liquor ";
		}
	}

	public enum LiquorType
	{
		Chocolate,
		Nut
	};
}
