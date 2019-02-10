using SimUDuck.Ducks;
using SimUDuck.FlyBehaviors;
using System;

namespace SimUDuck
{
    class Program
    {
        static void Main(string[] args)
        {
			MallardDuck mallardDuck = new MallardDuck();
			PlayWithDuck(mallardDuck);

			RedheadDuck redheadDuck = new RedheadDuck();
			PlayWithDuck(redheadDuck);

			RubberDuck rubberDuck = new RubberDuck();
			PlayWithDuck(rubberDuck);

			DecoyDuck decoyDuck = new DecoyDuck();
			PlayWithDuck(decoyDuck);

			ModelDuck modelDuck = new ModelDuck();
			PlayWithDuck(modelDuck);
			modelDuck.SetFlyBehavior(new FlyWithWings());
			PlayWithDuck(modelDuck);
		}

		static void DrawDuck(Duck duck)
		{
			duck.Display();
		}

		static void PlayWithDuck(Duck duck)
		{
			DrawDuck(duck);
			duck.Quack();
			duck.Fly();
			duck.Fly();
			duck.Fly();
			duck.Dance();
			Console.WriteLine();
		}
	}
}
