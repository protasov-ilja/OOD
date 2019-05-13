using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace task1.Composite.Styles
{
	public class OutlineStyle : IOutlineStyle
	{
		private Color _color = Color.Transparent;
		private bool _isEnabled;
		private float _lineThickness = 1;

		public OutlineStyle(Color color, bool isEnabled, float thickness = 1)
		{
			SetLineThickness(thickness);
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

			OutlineStyle other = (OutlineStyle)obj;
			return GetColor().Equals(other.GetColor()) && _isEnabled == other.IsEnabled() && GetLineThickness() == other.GetLineThickness();
		}

		public static bool operator ==(OutlineStyle lhs, OutlineStyle rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(OutlineStyle lhs, OutlineStyle rhs)
		{
			return !(lhs == rhs);
		}

		public override int GetHashCode()
		{
			var hashCode = 1304336967;
			hashCode = hashCode * -1521134295 + EqualityComparer<Color?>.Default.GetHashCode(GetColor());
			hashCode = hashCode * -1521134295 + _isEnabled.GetHashCode();
			hashCode = hashCode * -1521134295 + GetLineThickness().GetHashCode();
			return hashCode;
		}

		public float? GetLineThickness()
		{
			return _lineThickness;
		}

		public void SetLineThickness(float thickness)
		{
			_lineThickness = thickness;
		}
	}
}
