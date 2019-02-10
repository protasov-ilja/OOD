using SimUDuck.DanceBehavior;
using SimUDuck.FlyBehaviors;
using SimUDuck.QuackBehaviors;

using System;

namespace SimUDuck.Ducks
{
    class RedheadDuck : Duck
	{
		public RedheadDuck()
			: base(new FlyWithWings(), new QuackBehavior(), new DanceMenuetBehavior())
		{
		}

		public override void Display()
		{
			Console.WriteLine("I'm redhead duck");
		}
	}
}
