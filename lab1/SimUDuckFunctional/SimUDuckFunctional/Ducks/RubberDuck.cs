using SimUDuckFunctional.Behaviors;

using System;

namespace SimUDuckFunctional.Ducks
{
	sealed class RubberDuck : Duck
	{
		public RubberDuck()
			: base(FlyBehavior.FlyNoWay, QuackBehavior.Squeak, DanceBehavior.NoDance)
		{
		}

		public override void Display()
		{
			Console.WriteLine("I'm rubber duck");
		}
	}
}
