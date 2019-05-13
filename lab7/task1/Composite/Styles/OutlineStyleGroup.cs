using SFML.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace task1.Composite.Styles
{
	public class OutlineStyleGroup : IOutlineStyle
	{
		private readonly IEnumerable<IOutlineStyle> _styles;

		public Color? GetColor()
		{
			if (_styles.Count() != 0)
			{
				var firstStyle = Enumerable.First(_styles);
				if (firstStyle != null)
				{
					var firstColor = firstStyle.GetColor();
					foreach (var style in _styles)
					{
						if (firstColor != style.GetColor())
						{
							return null;
						}
					}

					return firstColor;
				}
			}

			return null;
		}

		public void SetColor(Color color)
		{
			foreach (var style in _styles)
			{
				style.SetColor(color);
			}
		}

		public OutlineStyleGroup(IEnumerable<IOutlineStyle> styles)
		{
			_styles = styles;
		}

		public void Enable(bool enable)
		{
			foreach (var style in _styles)
			{
				style.Enable(enable);
			}
		}

		public bool? IsEnabled()
		{
			if (_styles.Count() != 0)
			{
				var firstStyle = Enumerable.First(_styles);
				if (firstStyle != null)
				{
					var firstState = firstStyle.IsEnabled();
					foreach (var style in _styles)
					{
						if (firstState != style.IsEnabled())
						{
							return null;
						}
					}

					return firstState;
				}
			}

			return null;
		}

		public float? GetLineThickness()
		{
			if (_styles.Count() != 0)
			{
				var firstStyle = Enumerable.First(_styles);
				if (firstStyle != null)
				{
					var firstLineThickness = firstStyle.GetLineThickness();
					foreach (var style in _styles)
					{
						if (firstLineThickness != style.GetLineThickness())
						{
							return null;
						}
					}

					return firstLineThickness;
				}
			}

			return null;
		}

		public void SetLineThickness(float thickness)
		{
			foreach (var style in _styles)
			{
				style.SetLineThickness(thickness);
			}
		}
	}
}
