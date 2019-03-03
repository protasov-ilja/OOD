using task1.Beverages;

namespace task1.Condiments
{
	abstract class CondimentDecorator : IBeverage
	{
		private IBeverage m_beverage;

		public double GetCost()
		{
			return m_beverage.GetCost() + GetCondimentCost();
		}

		public string GetDescription()
		{
			return m_beverage.GetDescription() + ", " + GetCondimentDescription();
		}

		protected CondimentDecorator(IBeverage beverage)
		{
			m_beverage = beverage;
		}

		protected abstract string GetCondimentDescription();
		protected abstract double GetCondimentCost();
	}
}
