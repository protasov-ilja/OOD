using System;
using System.Collections.Generic;
using System.Text;

namespace SimUDuckFunctional.Ducks
{
    class Duck
    {
		public delegate void FlyBehaviour();
		public delegate void QuackBehaviour();
		public delegate void DanceBehaviour();

		private FlyBehaviour m_flyBehavior;
		private QuackBehaviour m_quackBehavior;
		private DanceBehaviour m_danceBehavior;

		public Duck(FlyBehaviour flyBehavior, QuackBehaviour quackBehavior, DanceBehaviour danceBehavior)
		{
			SetFlyBehavior(flyBehavior);
			SetQuackBehavior(quackBehavior);
			SetDanceBehavior(danceBehavior);
		}

		public void Quack()
		{
			m_quackBehavior.Invoke();
		}

		public void Swim()
		{
			Console.WriteLine("I'm swimming");
		}

		public void Fly()
		{
			m_flyBehavior.Invoke();
		}

		public virtual void Dance()
		{
			m_danceBehavior.Invoke();
		}

		public void SetQuackBehavior(QuackBehaviour quackBehavior)
		{
			m_quackBehavior = quackBehavior;
		}

		public void SetFlyBehavior(FlyBehaviour flyBehavior)
		{
			m_flyBehavior = flyBehavior;
		}

		public void SetDanceBehavior(DanceBehaviour danceBehavior)
		{
			m_danceBehavior = danceBehavior;
		}

		public virtual void Display() {}
	}
}
