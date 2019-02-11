using System;

namespace SimUDuckFunctional.Ducks
{
	abstract class Duck
    {
		private Action m_flyBehavior;
		private Action m_quackBehavior;
		private Action m_danceBehavior;

		public Duck(Action flyBehavior, Action quackBehavior, Action danceBehavior)
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

		public void SetQuackBehavior(Action quackBehavior)
		{
			m_quackBehavior = quackBehavior;
		}

		protected void SetFlyBehavior(Action flyBehavior)
		{
			m_flyBehavior = flyBehavior;
		}

		private void SetDanceBehavior(Action danceBehavior)
		{
			m_danceBehavior = danceBehavior;
		}

		public abstract void Display();
	}
}
