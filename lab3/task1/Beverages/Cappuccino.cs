
namespace task1.Beverages
{
    class Cappuccino : Coffee
    {
		private CappuccinoType m_cappuccinoType;

		public Cappuccino(CappuccinoType cappuccinoType)
			: base((cappuccinoType == CappuccinoType.Double ? " double " : " standart ") + " Cappuccino ")
		{
			m_cappuccinoType = cappuccinoType;
		}

		public override double GetCost()
		{
			return m_cappuccinoType == CappuccinoType.Double ? 120 : 80;
		}
	}

	public enum CappuccinoType
	{
		Standart,
		Double
	};
}
