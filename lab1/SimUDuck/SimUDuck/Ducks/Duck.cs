using SimUDuck.DanceBehavior;
using SimUDuck.FlyBehaviors;
using SimUDuck.QuackBehaviors;

using System;

namespace SimUDuck.Ducks
{
	class Duck
	{
		private IFlyBehavior m_flyBehavior;
		private IQuackBehavior m_quackBehavior;
		private IDanceBehavior m_danceBehavior;

		public Duck(IFlyBehavior flyBehavior, IQuackBehavior quackBehavior, IDanceBehavior danceBehavior)
		{
			SetFlyBehavior(flyBehavior);
			SetQuackBehavior(quackBehavior);
			SetDanceBehavior(danceBehavior);
		}

		public void Quack()
		{
			m_quackBehavior.Quack();
		}

		public void Swim()
		{
			Console.WriteLine("I'm swimming");
		}

		public void Fly()
		{
			m_flyBehavior.Fly();
		}

		public virtual void Dance()
		{
			m_danceBehavior.Dance();
		}

		public void SetQuackBehavior(IQuackBehavior quackBehavior)
		{
			m_quackBehavior = quackBehavior;
		}

		public void SetFlyBehavior(IFlyBehavior flyBehavior)
		{
			m_flyBehavior = flyBehavior;
		}

		public void SetDanceBehavior(IDanceBehavior danceBehavior)
		{
			m_danceBehavior = danceBehavior;
		}

		public virtual void Display() {}
	}
}
