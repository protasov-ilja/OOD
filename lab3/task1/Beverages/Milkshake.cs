
namespace task1.Beverages
{
	class Milkshake : Beverage
	{
		private double m_cost = 80;

		public Milkshake(MilkshakeType milkshakeType)
			: base (GetTypeDescription(milkshakeType) + " Milkshake")
		{
			SetCost(milkshakeType);
		}

		public override double GetCost()
		{
			return m_cost;
		}

		private void SetCost(MilkshakeType milkshakeType)
		{
			switch (milkshakeType)
			{
				case MilkshakeType.Small:
					m_cost = 50;
					break;
				case MilkshakeType.Medium:
					m_cost = 60;
					break;
				case MilkshakeType.Big:
					m_cost = 80;
					break;
			}
		}

		private static string GetTypeDescription(MilkshakeType milkshakeType)
		{
			switch (milkshakeType)
			{
				case MilkshakeType.Small:
					return "Small";
				case MilkshakeType.Medium:
					return "Medium";
				case MilkshakeType.Big:
					return "Big";
				default:
					return "Unknown";
			}
		}
	}

	public enum MilkshakeType
	{
		Small,
		Medium,
		Big
	};
}
