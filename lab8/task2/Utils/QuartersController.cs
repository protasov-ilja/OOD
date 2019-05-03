using System;

namespace task2.Utils
{
	public sealed class QuartersController : IQuartersController
	{
		private uint _quartersAmount = 0;
		private uint _quartersMaxLimit;

		public QuartersController(uint maxAmountOfQuarters)
		{
			_quartersMaxLimit = maxAmountOfQuarters;
		}

		public void UseQuarter()
		{
			if (_quartersAmount <= 0)
			{
				throw new ArgumentOutOfRangeException("quartersAmount");
			}

			_quartersAmount--;
		}

		public void EjectQuarters()
		{
			if (_quartersAmount <= 0)
			{
				throw new ArgumentOutOfRangeException("quartersAmount");
			}

			_quartersAmount = 0;
		}

		public uint GetQuartersCount()
		{
			return _quartersAmount;
		}

		public bool HasQuarters()
		{
			return _quartersAmount > 0;
		}

		public void InsertQuarter()
		{
			if (_quartersAmount >= _quartersMaxLimit)
			{
				throw new ArgumentOutOfRangeException("quartersAmount");
			}

			_quartersAmount++;
		}
	}
}
