using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Painter;
using Task1Tests.PictureDrafts;

namespace Task1Tests.PaintersTests
{
	[TestClass]
	public class PainterTests
    {
		[TestMethod]
		public void CanCreatePainterAndDrawShapes()
		{
			var painter = new Painter();
			var canvas = new Canvas();
			var draft = new PictureDraft();
			var shape1 = new TestShape();
			var shape2 = new TestShape();

			draft.AddShape(shape1);
			draft.AddShape(shape2);
			painter.DrawPicture(draft, canvas);

			Assert.IsTrue(shape1.IsActivated);
			Assert.IsTrue(shape2.IsActivated);
		}
	}
}
