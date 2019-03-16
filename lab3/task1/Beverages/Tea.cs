
namespace task1.Beverages
{
    class Tea : Beverage
    {
		public Tea(TeaSort teaSort)
			: base(GetSortDescription(teaSort) + " Tea")
		{
		}

		public override double GetCost()
		{
			return 30;
		}

		private static string GetSortDescription(TeaSort teaSort)
		{
			switch (teaSort)
			{
				case TeaSort.Black:
					return "Black";
				case TeaSort.Green:
					return "Green";
				case TeaSort.Red:
					return "Red";
				case TeaSort.White:
					return "White";
				default:
					return "Unknown";
			}
		}
	}

	public enum TeaSort
	{
		Black,
		Green,
		Red,
		White
	};
}
