using task1.Beverages;

namespace task1.Condiments
{
    class Lemon : CondimentDecorator
    {
		private uint m_quantity;

		public Lemon(IBeverage beverage, uint quantity = 1)
		: base(beverage)
		{
			m_quantity = quantity;
		}

		protected override double GetCondimentCost()
		{
			return 10 * m_quantity;
		}

		protected override string GetCondimentDescription()
		{
			return $"Lemon x {m_quantity}";
		}
	}
}
