﻿using SimUDuck.DanceBehavior;
using SimUDuck.FlyBehaviors;
using SimUDuck.QuackBehaviors;

using System;

namespace SimUDuck.Ducks
{
    class ModelDuck : Duck
	{
		public ModelDuck()
			: base(new FlyNoWay(), new QuackBehavior(), new NoDanceBehavior())
		{
		}

		public override void Display()
		{
			Console.WriteLine("I'm model duck");
		}
	}
}
