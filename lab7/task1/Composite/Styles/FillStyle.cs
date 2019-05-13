
using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace task1.Composite.Styles
{
	public class FillStyle : IStyle
	{
		private bool _isEnabled;

		private Color _color = Color.Transparent;

		public FillStyle(Color color, bool isEnabled)
		{
			_color = color;
			_isEnabled = isEnabled;
		}

		public Color? GetColor()
		{
			return _isEnabled ? _color : Color.Transparent;
		}

		public void SetColor(Color color)
		{
			_color = color;
		}

		public bool? IsEnabled()
		{
			return _isEnabled;
		}

		public void Enable(bool enable)
		{
			_isEnabled = enable;
		}

		public override bool Equals(Object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			FillStyle other = (FillStyle)obj;
			return GetColor().Equals(other.GetColor()) && _isEnabled == other.IsEnabled();
		}

		public static bool operator ==(FillStyle lhs, FillStyle rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(FillStyle lhs, FillStyle rhs)
		{
			return !(lhs == rhs);
		}

		public override int GetHashCode()
		{
			var hashCode = 1304336967;
			hashCode = hashCode * -1521134295 + EqualityComparer<Color?>.Default.GetHashCode(GetColor());
			hashCode = hashCode * -1521134295 + _isEnabled.GetHashCode();
			return hashCode;
		}
	}
}
