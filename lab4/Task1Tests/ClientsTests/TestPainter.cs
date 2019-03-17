using Task1.Painter;

namespace Task1Tests.ClientsTests
{
	public class TestPainter : IPainter
	{
		public bool WasDrawed { get; private set; } = false;

		public void DrawPicture(PictureDraft draft, ICanvas canvas)
		{
			WasDrawed = true;
		}
	}
}
