using SimUDuckFunctional.Behaviors;

using System;

namespace SimUDuckFunctional.Ducks
{
	sealed class ModelDuck : Duck
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
