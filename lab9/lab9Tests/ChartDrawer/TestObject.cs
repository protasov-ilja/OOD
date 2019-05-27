namespace lab9Tests.ChartDrawer
{
	public class TestObject
	{
		public bool IsEventHarmonicAddedInvoked { get; private set; } = false;
		public bool IsEventActiveHarmonicChangedInvoked { get; private set; } = false;
		public bool IsEventHarmonicDeletedInvoked { get; private set; } = false;
		public bool IsEventHarmonicParametersChangedInvoked { get; private set; } = false;
		
		public int activeIndex = -1;
		public int deltedIndex = -1;
		public int addedIndex = -1;

		public void OnHarmonicsChanged()
		{
			IsEventHarmonicParametersChangedInvoked = true;
		}

		public void OnActiveHarmonicChanged(int index)
		{
			activeIndex = index;
			IsEventActiveHarmonicChangedInvoked = true;
		}

		public void OnHarmonicAdded(int index)
		{
			addedIndex = index;
			IsEventHarmonicAddedInvoked = true;
		}

		public void OnHarmonicDeleted(int index)
		{
			deltedIndex = index;
			IsEventHarmonicDeletedInvoked = true;
		}
	}
}
