using SimUDuckFunctional.Behaviors;

using System;

namespace SimUDuckFunctional.Ducks
{
	sealed class MallardDuck : Duck
	{
		public MallardDuck()
			: base(FlyBehavior.FlyWithWings(), QuackBehavior.Quack, DanceBehavior.DanceWaltz)
		{
		}

		public override void Display()
		{
			Console.WriteLine("I'm mallard duck");
		}
	}
}
