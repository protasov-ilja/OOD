using System.IO;
using Task1.Painter;
using Task1.Painter.Shapes;

namespace Task1Tests.ClientsTests
{
    public class TestDesigner : IDesigner
    {
		public bool IsDraftCreated { get; private set; } = false;

		public PictureDraft CreateDraft(TextReader strm)
		{
			IsDraftCreated = true;
			var draft = new PictureDraft();
			draft.AddShape(new Rectangle(new Point(0, 3), new Point(2, -2), Task1.Painter.Enums.Color.Black));

			return draft;
		}
    }
}
