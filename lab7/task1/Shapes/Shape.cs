using task1.Composite;
using task1.Composite.Styles;

namespace task1.Shapes
{
	public abstract class Shape : IComponent
	{
		private IOutlineStyle _outlineStyle;
		private IStyle _fillStyle;

		public Rect<float>? Frame { get; set; }
		public IStyle FillStyle { get; private set; }
		public IOutlineStyle OutlineStyle { get; private set; }

		public Shape(Rect<float> frame, IOutlineStyle outlineStyle, IStyle fillStyle)
		{
			Frame = frame;
			OutlineStyle = outlineStyle;
			FillStyle = fillStyle;
		}

		public abstract void Draw(ICanvas canvas);

		protected void SetParametersInCanvas(ICanvas canvas)
		{
			canvas.BeginFill(FillStyle.GetColor().Value);
			canvas.SetLineColor(OutlineStyle.GetColor().Value);
			canvas.SetLineThickness(OutlineStyle.LineThickness.Value);

			//canvas.BeginFill((FillStyle.IsEnabled().Value) ? FillStyle.Value.Color : Color.Transparent);
			//canvas.SetLineColor((OutlineStyle.HasValue && OutlineStyle.Value.IsEnabled()) ? OutlineStyle.Value.Color : Color.Black);
			//canvas.SetLineThickness(LineThickness.HasValue ? LineThickness.Value : 1);
		}

		public int GetShapesCount()
		{
			return 0;
		}

		public void InsertShape(IComponent shape, int position) { }

		public void RemoveShapeAtIndex(int index) { }

		public bool IsComposite()
		{
			return false;
		}
	}
}
