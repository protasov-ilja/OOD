using task1.Beverages;

namespace task1.Condiments
{
    class ChocolateSlice : CondimentDecorator
    {
		private uint m_amount;

		public ChocolateSlice(IBeverage beverage, uint amount)
			: base(beverage)
		{
			m_amount = amount < 5 ? amount : 5;
		}

		protected override double GetCondimentCost()
		{
			return 10 * m_amount;
		}

		protected override string GetCondimentDescription()
		{
			return "Chocolate Slice x " + m_amount;
		}
	}
}
