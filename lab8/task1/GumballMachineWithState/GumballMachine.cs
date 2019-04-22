﻿using System;
using task1.GumballMachineWithState.States;

namespace task1.GumballMachineWithState
{
	public class GumballMachine : IGumballMachine, IGumballMachineController
	{
		private SoldState _soldState;
		private SoldOutState _soldOutState;
		private NoQuarterState _noQuarterState;
		private HasQuarterState _hasQuarterState;
		private IState _state;
		private uint _count = 0;

		public GumballMachine(uint numBalls = 0)
		{
			_count = numBalls;
			_soldState = new SoldState(this);
			_soldOutState = new SoldOutState(this);
			_noQuarterState = new NoQuarterState(this);
			_hasQuarterState = new HasQuarterState(this);
			_state = (_count > 0) ? _noQuarterState : (IState)_soldOutState;
		}

		public uint GetBallCount()
		{
			return _count;
		}

		public void ReleaseBall()
		{
			if (_count != 0)
			{
				Console.WriteLine("A gumball comes rolling out the slot...");
				--_count;
			}
		}

		public void SetHasQuarterState()
		{
			_state = _hasQuarterState;
		}

		public void SetNoQuarterState()
		{
			_state = _noQuarterState;
		}

		public void SetSoldOutState()
		{
			_state = _soldOutState;
		}

		public void SetSoldState()
		{
			_state = _soldState;
		}

		public override string ToString()
		{
			var fmt = $"(Mighty Gumball, Inc.C++ - enabled Standing Gumball Model #2016 (with state)Inventory: { _count } gumball{ (_count != 1 ? "s" : "") } Machine is { _state.ToString() })";

			return fmt;
		}

		public void EjectQuarter()
		{
			_state.EjectQuarter();
		}

		public void InsertQuarter()
		{
			_state.InsertQuarter();
		}

		public void TurnCrank()
		{
			_state.TurnCrank();
			_state.Dispense();
		}
	}
}
