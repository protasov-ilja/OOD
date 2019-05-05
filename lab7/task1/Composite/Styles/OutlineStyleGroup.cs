using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace task1.Composite.Styles
{
	public class OutlineStyleGroup : IOutlineStyle
	{
		private readonly IEnumerable<IOutlineStyle> _styles;

		public float? LineThickness
		{
			get
			{
				try
				{
					var firstStyle = Enumerable.First(_styles);
					if (firstStyle != null)
					{
						var firstLineThickness = firstStyle.LineThickness;
						foreach (var style in _styles)
						{
							if (firstLineThickness != style.LineThickness)
							{
								return null;
							}
						}

						return firstLineThickness;
					}

					return null;
				}
				catch (Exception ex)
				{
					return null;
				}
			}

			set
			{
				foreach (var style in _styles)
				{
					style.LineThickness = value;
				}
			}
		}

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

		public bool IsComposite()
		{
			return true;
		}
	}
}
