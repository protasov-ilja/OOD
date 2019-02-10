using System;
using System.Collections.Generic;
using System.Text;

namespace SimUDuckFunctional.Ducks
{
	class DecoyDuck : Duck
	{
		public DecoyDuck()
			: base(FlyBehavior.FlyWithWings, QuackBehavior.MuteQuack, DanceBehavior.NoDance)
		{
		}

		public override void Display()
		{
			Console.WriteLine("I'm decoy duck");
		}
	}
}
