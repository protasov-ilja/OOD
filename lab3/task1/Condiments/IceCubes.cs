

using task1.Beverages;

namespace task1.Condiments
{
    class IceCubes : CondimentDecorator
    {
		private uint m_quantity;
		private IceCubeType m_type;

		public IceCubes(IBeverage beverage, uint quantity, IceCubeType type = IceCubeType.Water)
		   : base(beverage)
		{
			m_quantity = quantity;
			m_type = type;
		}

		protected override double GetCondimentCost()
		{
			return (m_type == IceCubeType.Dry ? 10 : 5) * m_quantity;
		}

		protected override string GetCondimentDescription()
		{
			return (m_type == IceCubeType.Dry ? "Dry" : "Water") + " ice cubes x " + m_quantity;
		}
	}

	public enum IceCubeType
	{
		Dry,    // Сухой лед (для суровых сибирских мужиков)
		Water   // Обычные кубики из воды
	};
}
