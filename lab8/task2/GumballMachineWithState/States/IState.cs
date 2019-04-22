﻿namespace task1.GumballMachineWithState.States
{
	public interface IState
	{
		void InsertQuarter();
		void EjectQuarter();
		void TurnCrank();
		void Dispense();
	}
}
