using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace task1.Composite.Styles
{
	public class FillStyleGroup : IStyle
	{
		private readonly IEnumerable<IStyle> _styles;

		public Color? GetColor()
		{
			try
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

				return null;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public void SetColor(Color color)
		{
			foreach (var style in _styles)
			{
				style.SetColor(color);
			}
		}

		public FillStyleGroup(IEnumerable<IStyle> styles)
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

		public bool IsComposite()
		{
			return true;
		}

		public bool? IsEnabled()
		{
			try
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

				return null;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
