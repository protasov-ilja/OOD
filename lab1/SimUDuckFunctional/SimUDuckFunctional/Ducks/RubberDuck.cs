using System;
using System.Collections.Generic;
using System.Text;

namespace SimUDuckFunctional.Ducks
{
	class RubberDuck : Duck
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
