using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace task1.Composite
{
    public class Style
    {
		public Color Color { get; set; }

		private bool _isEnabled = false;

		public Style(Color color, bool isEnabled)
		{
			Color = color;
			_isEnabled = isEnabled;
		}

		public bool IsEnabled()
		{
			return _isEnabled;
		}

		public void Enable(bool enable)
		{
			_isEnabled = enable;
		}

		public override bool Equals(Object obj)
		{
			if (this == obj)
			{
				return true;
			}

			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			Style other = (Style)obj;
			return Color.Equals(other.Color) && _isEnabled == other.IsEnabled();
		}

		public override int GetHashCode()
		{
			var hashCode = 1304336967;
			hashCode = hashCode * -1521134295 + EqualityComparer<Color>.Default.GetHashCode(Color);
			hashCode = hashCode * -1521134295 + _isEnabled.GetHashCode();
			return hashCode;
		}
	}
}
