using System;

namespace SimUDuckFunctional.Behaviors
{
	sealed class QuackBehavior
    {
		public static void MuteQuack() {}

		public static void Quack()
		{
			Console.WriteLine("Quack Quack!!!");
		}

		public static void Squeak()
		{
			Console.WriteLine("Squeek!!!");
		}
	}
}
