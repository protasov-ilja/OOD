using lab9._1.ChartDrawer.Models.Enums;
using System;

namespace lab9._1.ChartDrawer.Models
{
	public sealed class Harmonic
	{
		private HarmonicType _type = HarmonicType.Sin;
		private float _amplitude = 1;
		private float _frequency = 1;
		private float _phase = 0;

		public HarmonicType Type
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
				ParametersChanged?.Invoke();
			}
		}

		public float Amplitude
		{
			get
			{
				return _amplitude;
			}
			set
			{
				_amplitude = value;
				ParametersChanged?.Invoke();
			}
		}

		public float Frequency
		{
			get
			{
				return _frequency;
			}
			set
			{
				_frequency = value;
				ParametersChanged?.Invoke();
			}
		}

		public float Phase
		{
			get
			{
				return _phase;
			}
			set
			{
				_phase = value;
				ParametersChanged?.Invoke();
			}
		}

		public event Action ParametersChanged;

		public Harmonic() { }

		public Harmonic(HarmonicType type, float amplitude, float frequency, float phase)
		{
			Type = type;
			Amplitude = amplitude;
			Frequency = frequency;
			Phase = phase;
		}

		public override string ToString()
		{
			return $"{ Amplitude } * { HarmonicTypeToString() }({ Frequency } * x + { Phase })";
		}

		private string HarmonicTypeToString()
		{
			return Type == HarmonicType.Cos ? "cos" : "sin";
		}
	}
}
