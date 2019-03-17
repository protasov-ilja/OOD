using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Task1.Painter;

namespace Task1Tests.DesignersTests
{
	[TestClass]
	public class DesignerTests
    {
		[TestMethod]
		public void CanCreateShapesDraft()
		{
			using (StreamReader sr = new StreamReader("inputTest.txt"))
			{
				var factory = new ShapeFactory();
				var designer = new Designer(factory);
				var draft = designer.CreateDraft(sr);
				Assert.AreEqual(draft.ShapeCount, 2);
			}
		}
	}
}
