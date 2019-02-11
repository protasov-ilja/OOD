using System;

namespace SimUDuckFunctional.Behaviors
{
	sealed class FlyBehavior
	{
		public static Action FlyWithWings()
		{
			int flightsAmount = 0;
			Action action = () =>
			{
				flightsAmount++;
				Console.WriteLine("I'm flying {0} with wings!!", flightsAmount);
			};

			return action;
		}

		public static void FlyNoWay() {}
    }
}
