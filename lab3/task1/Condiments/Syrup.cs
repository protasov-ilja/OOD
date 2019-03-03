
using task1.Beverages;

namespace task1.Condiments
{
    class Syrup : CondimentDecorator
	{
		private SyrupType m_syrupType;

		public Syrup(IBeverage beverage, uint quantity, SyrupType syrupType)
		   : base(beverage)
		{
			m_syrupType = syrupType;
		}

		protected override double GetCondimentCost()
		{
			return 15;
		}

		protected override string GetCondimentDescription()
		{
			return (m_syrupType == SyrupType.Chocolate ? "Chocolate" : "Maple") + " syrup";
		}
	}

	public enum SyrupType
	{
		Chocolate,  // Шоколадный
		Maple    // Кленовый
	};
}
