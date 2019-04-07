using System;
using task1.Adapters;
using task1.GraphicsLib;
using task1.ModernGraphicsLib;
using task1.ShapeDrawingLib;

using Point = task1.ShapeDrawingLib.Point;


namespace task1.App
{
	public class App
	{
		private const string ModerRendererOnCommand = "y";

		public App()
		{
			Console.WriteLine($"Should we use new API ({ModerRendererOnCommand})?");
			string userInput = Console.ReadLine().ToLower();
			if (userInput == ModerRendererOnCommand)
			{
				Console.WriteLine("---------ObjectAdapter--------");
				PaintPictureOnMGRendererObjectAdapter();
				Console.WriteLine("---------ClassAdapter--------");
				PaintPictureOnMGRendererClassAdapter();
			}
			else
			{
				PaintPictureOnCanvas();
			}
		}

		private void PaintPicture(CanvasPainter painter)
		{
			var triangle = new Triangle(new Point(10, 15), new Point(100, 200), new Point(150, 250));
			var rectangle = new Rectangle(new Point(30, 40), 18, 24);
			Console.WriteLine("---------triangle--------");
			painter.Draw(triangle);
			Console.WriteLine("---------rectangle--------");
			painter.Draw(rectangle);
		}

		private void PaintPictureOnCanvas()
		{
			Canvas simpleCanvas = new Canvas();
			CanvasPainter painter = new CanvasPainter(simpleCanvas);
			PaintPicture(painter);
		}

		private void PaintPictureOnMGRendererObjectAdapter()
		{
			var renderer = new ModernGraphicsRenderer(Console.Out);
			var adapter = new MGRendererObjectAdapter(renderer);
			var painter = new CanvasPainter(adapter);
			try
			{
				adapter.Renderer.BeginDraw();
				PaintPicture(painter);
				adapter.Renderer.EndDraw();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void PaintPictureOnMGRendererClassAdapter()
		{
			var adapter = new MGRendererClassAdapter(Console.Out);
			var painter = new CanvasPainter(adapter);
			try
			{
				adapter.BeginDraw();
				PaintPicture(painter);
				adapter.EndDraw();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
