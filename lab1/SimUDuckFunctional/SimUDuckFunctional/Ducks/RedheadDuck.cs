using SimUDuckFunctional.Behaviors;

using System;

namespace SimUDuckFunctional.Ducks
{
	sealed class RedheadDuck : Duck
	{
		public RedheadDuck()
			: base(FlyBehavior.FlyWithWings(), QuackBehavior.Quack, DanceBehavior.DanceMenuet)
		{
		}

		public override void Display()
		{
			Console.WriteLine("I'm redhead duck");
		}
	}
}
