
using task1.Beverages;

namespace task1.Condiments
{
	class ChocolateCrumbs : CondimentDecorator
	{
		private uint m_mass;

		public ChocolateCrumbs(IBeverage beverage, uint mass)
			: base(beverage)
		{
			m_mass = mass;
		}

		protected override double GetCondimentCost()
		{
			return 2 * m_mass;
		}

		protected override string GetCondimentDescription()
		{
			return "Chocolate crumbs " + m_mass + "g";
		}
	}
}
