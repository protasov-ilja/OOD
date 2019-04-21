using SFML.Graphics;
using task1.Composite;

namespace task1.Shapes
{
	public abstract class Shape : IComponent
	{
		private Style? _outlineStyle;
		private Style? _fillStyle;
		private float? _lineThickness;
		private Rect<float> _frame;

		public IComponent Parent { get; set; }
		public Rect<float> Frame
		{
			get => _frame;

			set
			{
				_frame = value;
				Parent?.RecalculateFrame();
			}
		}

		public Style? FillStyle
		{
			get => _fillStyle;

			set
			{
				_fillStyle = value;
				Parent?.RecalculateFillStyle();
			}
		}

		public Style? OutlineStyle
		{
			get => _outlineStyle;

			set
			{
				_outlineStyle = value;
				Parent?.RecalculateOutlineStyle();
			}
		}

		public float? LineThickness
		{
			get => _lineThickness;

			set
			{
				_lineThickness = value.Value;
				Parent?.RecalculateLineThickness();
			}
		}

		public Shape(Rect<float> frame, Style outlineStyle, Style fillStyle, float lineThickness)
		{
			Frame = frame;
			OutlineStyle = outlineStyle;
			FillStyle = fillStyle;
			LineThickness = lineThickness;
		}

		public abstract void Draw(ICanvas canvas);

		protected void SetParametersInCanvas(ICanvas canvas)
		{
			canvas.BeginFill((FillStyle.HasValue && FillStyle.Value.IsEnabled()) ? FillStyle.Value.Color : Color.Transparent);
			canvas.SetLineColor((OutlineStyle.HasValue && OutlineStyle.Value.IsEnabled()) ? OutlineStyle.Value.Color : Color.Black);
			canvas.SetLineThickness(LineThickness.HasValue ? LineThickness.Value : 1);
		}

		public int GetShapesCount()
		{
			return 1;
		}

		public void InsertShape(IComponent shape, int position) { }

		public void RecalculateFillStyle() { }

		public void RecalculateFrame() { }

		public void RecalculateLineThickness() { }

		public void RecalculateOutlineStyle() { }

		public void RemoveShapeAtIndex(int index) { }
	}
}
