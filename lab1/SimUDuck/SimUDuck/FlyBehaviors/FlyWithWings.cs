using System;

namespace SimUDuck.FlyBehaviors
{
    class FlyWithWings : IFlyBehavior
	{
		private int m_flightsAmount = 0;

		public void Fly()
		{
			m_flightsAmount++;
			Console.WriteLine("I'm flying {0} with wings!!", m_flightsAmount);
		}
	}
}
