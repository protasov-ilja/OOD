using System;
using System.Collections.Generic;
using System.Text;

namespace SimUDuckFunctional.Ducks
{
	class MallardDuck : Duck
	{
		public MallardDuck()
			: base(FlyBehavior.FlyWithWings, QuackBehavior.Quack, DanceBehavior.DanceWaltz)
		{
		}

		public override void Display()
		{
			Console.WriteLine("I'm mallard duck");
		}
	}
}
