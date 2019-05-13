using task1.Composite;
using task1.Composite.Styles;

namespace task1.Shapes
{
	public abstract class Shape : IComponent
	{
		private Rect<float>? _frame;

		public IStyle FillStyle { get; private set; }
		public IOutlineStyle OutlineStyle { get; private set; }

		public Shape(Rect<float> frame, IOutlineStyle outlineStyle, IStyle fillStyle)
		{
			SetFrame(frame);
			OutlineStyle = outlineStyle;
			FillStyle = fillStyle;
		}

		public abstract void Draw(ICanvas canvas);

		protected void SetParametersInCanvas(ICanvas canvas)
		{
			canvas.BeginFill(FillStyle.GetColor().Value);
			canvas.SetLineColor(OutlineStyle.GetColor().Value);
			canvas.SetLineThickness(OutlineStyle.GetLineThickness().Value);
		}

		public int GetShapesCount()
		{
			return 0;
		}

		public void InsertShape(IComponent shape, int position) { }

		public void RemoveShapeAtIndex(int index) { }

		public IComponent GetComponentByIndex(int index)
		{
			return null;
		}

		public Group GetGroup()
		{
			return null;
		}

		public Rect<float>? GetFrame()
		{
			return _frame;
		}

		public void SetFrame(Rect<float> frame)
		{
			_frame = frame;
		}
	}
}
