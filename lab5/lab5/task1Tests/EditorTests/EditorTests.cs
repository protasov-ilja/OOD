using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1.DocumentEditor;

namespace task1Tests.EditorTests
{
	[TestClass]
	public class EditorTests
    {
		[TestMethod]
		public void CanInsertImage()
		{
			var argsHandler = new TestArgsHandler();
			argsHandler.ArgumentsLeft = 0;
			Editor e = new Editor();
		}

		[TestMethod]
		public void CanInsertParagraph()
		{
			var argsHandler = new TestArgsHandler();
			argsHandler.ArgumentsLeft = 0;
			Editor e = new Editor();
		}
	}
}
