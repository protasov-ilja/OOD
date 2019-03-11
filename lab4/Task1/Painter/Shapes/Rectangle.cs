using System.Numerics;

namespace Task1.Painter.Shapes
{
	public class Rectangle : IShape
	{
		public Vector2 LeftTop { get; private set; }
		public Vector2 RightBottom { get; private set; }

		private Enums.Color _color;

		public Rectangle(Vector2 leftTop, Vector2 rightBottom, Enums.Color color)
		{
			LeftTop = leftTop;
			RightBottom = rightBottom;
			_color = color;
		}

		public void Draw(ICanvas canvas)
		{
			var rightTop = new Vector2(RightBottom.X, LeftTop.Y);
			var leftBottom = new Vector2(LeftTop.X, RightBottom.Y);

			canvas.Color = _color;
			canvas.DrawLine(LeftTop, rightTop);
			canvas.DrawLine(rightTop, RightBottom);
			canvas.DrawLine(RightBottom, leftBottom);
			canvas.DrawLine(leftBottom, LeftTop);
		}

		public Enums.Color GetColor()
		{
			return _color;
		}
	}
}
