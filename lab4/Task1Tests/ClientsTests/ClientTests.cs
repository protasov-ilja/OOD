using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Task1.Painter;

namespace Task1Tests.ClientsTests
{
	[TestClass]
	public class ClientTests
    {
		[TestMethod]
		public void CanCreateDraftAndDrawIt()
		{
			var client = new Client();
			var designer = new TestDesigner();
			client.CreatePictureDraft(designer, new StreamReader(new MemoryStream()));
			Assert.IsTrue(designer.IsDraftCreated);

			var painter = new TestPainter();
			var canvas = new Canvas();
			client.DrawPicture(painter, canvas);
			Assert.IsTrue(painter.WasDrawed);
		}
	}
}
