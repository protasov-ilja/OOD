using Task1.Painter;
using Task1.Painter.Enums;
using Task1.Painter.Shapes;

namespace Task1Tests.PictureDrafts
{
	public class TestShape : Shape
	{
		public bool IsActivated { get; private set; } = false;

		public TestShape()
			:base(Color.Black)
		{
		}

		public override void Draw(ICanvas canvas)
		{
			IsActivated = true;
		}
	}
}
