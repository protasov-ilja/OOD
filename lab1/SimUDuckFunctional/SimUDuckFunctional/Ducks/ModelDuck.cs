using System;
using System.Collections.Generic;
using System.Text;

namespace SimUDuckFunctional.Ducks
{
	class ModelDuck : Duck
	{
		public ModelDuck()
			: base(FlyBehavior.FlyNoWay, QuackBehavior.Quack, DanceBehavior.NoDance)
		{
		}

		public override void Display()
		{
			Console.WriteLine("I'm model duck");
		}
	}
}
