using System;

namespace Task1.Painter
{
	public struct Point
	{
		public float X { get; private set; }
		public float Y { get; private set; }

		public Point(float x, float y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return $"x: {X} y: {Y}";
		}

		public bool Equals(Point other)
		{
			const double e = 0.001;

			return Math.Abs(X - other.X) <= e && Math.Abs(Y - other.Y) <= e;
		}

		public static bool operator ==(Point first, Point second)
		{
			return first.Equals(second);
		}

		public static bool operator !=(Point first, Point second)
		{
			return !(first == second);
		}
	}
}
