
namespace task1.Beverages
{
    class Capuccino : Coffee
    {
		private CapuccinoType m_capuccinoType;

		public Capuccino(CapuccinoType capuccinoType)
			: base((capuccinoType == CapuccinoType.Double ? " double " : " standart ") + " Capuccino ")
		{
		}

		public override double GetCost()
		{
			return m_capuccinoType == CapuccinoType.Double ? 120 : 80;
		}
	}

	public enum CapuccinoType
	{
		Standart,
		Double
	};
}
