using lab9._1.ChartDrawer.Models;
using System;

namespace lab9Tests.ChartDrawer
{
	public class TestObject
	{
		public bool IsEventHarmonicAddedInvoked { get; private set; } = false;
		public bool IsEventActiveHarmonicChangedInvoked { get; private set; } = false;
		public bool IsEventHarmonicDeletedInvoked { get; private set; } = false;
		public bool IsEventHarmonicParametersChangedInvoked { get; private set; } = false;
		public bool ExceptionWasThrownInSelectActiveHarmonicMethod { get; private set; } = false;

		public int activeIndex = -1;
		public int deletedIndex = -1;
		public int addedIndex = -1;

		public int newActiveIndex;

		private IHarmonicsContainer _container;

		public TestObject()
		{
		}

		public TestObject(IHarmonicsContainer container)
		{
			_container = container;
		}

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
			deletedIndex = index;
			IsEventHarmonicDeletedInvoked = true;
		}

		public void ChangeHarmonicSelectedIndexOnHarmonicDeleted(int index)
		{
			try
			{
				deletedIndex = index;
				IsEventHarmonicDeletedInvoked = true;
				_container.SelectHarmonicByIndex(newActiveIndex);
			}
			catch (Exception ex)
			{
				ExceptionWasThrownInSelectActiveHarmonicMethod = true;
			}
		}
	}
}
