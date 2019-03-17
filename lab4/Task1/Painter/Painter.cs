using System;

namespace Task1.Painter
{
    public class Painter : IPainter
    {
		public void DrawPicture(PictureDraft pictureDraft, ICanvas canvas)
		{
			for (var i = 0; i < pictureDraft.ShapeCount; ++i)
			{
				var shape = pictureDraft.GetShapeByIndex(i);
				Console.WriteLine($"type: {shape.GetType().Name}");
				shape.Draw(canvas);
				Console.WriteLine("----------------------");
			}
		}
	}
}
