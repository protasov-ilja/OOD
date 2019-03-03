
using task1.Beverages;

namespace task1.Condiments
{
    class CoconutFlakes : CondimentDecorator
	{
		private uint m_mass;

		public CoconutFlakes(IBeverage beverage, uint mass)
			: base(beverage)
		{
			m_mass = mass;
		}

		protected override double GetCondimentCost()
		{
			return 1 * m_mass;
		}

		protected override string GetCondimentDescription()
		{
			return "Coconut flakes " + m_mass + "g";
		}
	}
}
