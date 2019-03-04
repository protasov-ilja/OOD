namespace task1.Beverages
{
    class Latte : Coffee
    {
		private double m_cost;

		public Latte(LatteType latteType)
			: base((latteType == LatteType.Double ? " double" : " standart") + " Latte")
		{
			m_cost = (latteType == LatteType.Double) ? 130 : 90;
		}

		public override double GetCost()
		{
			return m_cost;
		}
	}

	public enum LatteType
	{
		Standart,
		Double
	};
}
