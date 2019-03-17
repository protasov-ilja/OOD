using System;
using Task1.Painter;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
			var factory = new ShapeFactory();
			var client = new Client();
			var designer = new Designer(factory);
			var painter = new Painter.Painter();
			var canvas = new Canvas();
			client.CreatePictureDraft(designer, Console.In);
			client.DrawPicture(painter, canvas);
        }
    }
}
