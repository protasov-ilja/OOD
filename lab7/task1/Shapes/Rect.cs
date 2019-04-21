using System;
using System.Collections.Generic;

namespace task1.Shapes
{
    public struct Rect<T>
    {
		public Rect(T top, T left, T width, T height)
		{
			Top = top;
			Left = left;
			Width = width;
			Height = height;
		}

		public T Top { get; set; }
		public T Left { get; set; }
		public T Width { get; set; }
		public T Height { get; set; }

		public override bool Equals(Object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			Rect<T> other = (Rect<T>)obj;

			return Left.Equals(other.Left) && Top.Equals(other.Top) 
				&& Width.Equals(other.Width) && Height.Equals(other.Height);
		}

		public override int GetHashCode()
		{
			var hashCode = 1636396453;
			hashCode = hashCode * -1521134295 + base.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Left);
			hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Top);
			hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Width);
			hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Height);
			return hashCode;
		}
	}
}
