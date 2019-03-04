
namespace task1.Beverages
{
	abstract class Beverage : IBeverage
	{
		private string m_description;

		public Beverage(string descrition)
		{
			m_description = descrition;
		}

		public abstract double GetCost();

		public string GetDescription()
		{
			return m_description;
		}
	}
}
