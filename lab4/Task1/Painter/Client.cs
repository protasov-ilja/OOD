using System;
using System.IO;

namespace Task1.Painter
{
    public class Client
    {
		private PictureDraft _draft;

		public void CreatePictureDraft(IDesigner designer, TextReader inStrm)
		{
			ShowHelpInfo();
			_draft = designer.CreateDraft(inStrm);
		}

		public void DrawPicture(IPainter painter, ICanvas canvas)
		{
			if (_draft != null)
			{
				painter.DrawPicture(_draft, canvas);
			}
		}

		private void ShowHelpInfo()
		{
			Console.WriteLine("ellipse <center.X> <center.Y> <horizontalRadius> <verticalRadius> <color>");
			Console.WriteLine("rectangle <leftTop.X> <leftTop.Y> <rightBottom.X> <rightBottom.Y> <color>");
			Console.WriteLine("polygon <vertexCount> <center.x> <center.y> <radius> <color>");
			Console.WriteLine("triangle <vertex1.x> <vertex1.Y> <vertex2.x> <vertex2.Y> <vertex3.x> <vertex3.Y> <color>");
			Console.WriteLine("use <exit> - to exit from draft creation and draw shapes on canvas");
		}
    }
}
