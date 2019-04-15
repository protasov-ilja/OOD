using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using task1.Composite;
using task1.Shapes;

namespace task1
{
    class Program
    {
		private static string _apllicationName = "Painter";
		private static uint _windowWidth = 800;
		private static uint _windowHeight = 500;

        static void Main(string[] args)
        {
			try
			{
				var circle = new CircleShape(100f)
				{
					FillColor = Color.Blue
				};

				var mode = new VideoMode(_windowWidth, _windowHeight);
				var window = new RenderWindow(mode, _apllicationName);
				window.Closed += (_, __) => window.Close();
				var canvas = new Canvas(Console.Out, window);
				var slide = new Slide(_windowWidth, _windowHeight);
				InitializeSlide(slide);
				slide.Draw(canvas);
				while (window.IsOpen)
				{
					window.DispatchEvents();
					window.Clear(Color.White);
					
					window.Draw(circle);
					window.Display();
				}

				Console.WriteLine("exit");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void InitializeSlide(Slide slide)
		{
			var rectFrame = new Rect<float>{ Top = 0, Left = 0, Width = 100, Height = 100 };
			var rectangle = new Rectangle(rectFrame, new Style(Color.Green, true), new Style(Color.Green, true), 3);

			var eFrame = new Rect<float> { Top = 100, Left = 200, Width = 100, Height = 100 };
			var ellipse = new Ellipse(eFrame, new Style(Color.Green, true), new Style(Color.Green, true), 3);

			var tFrame = new Rect<float> { Top = 300, Left = 100, Width = 100, Height = 100 };
			var triangle = new Triangle(tFrame, new Style(Color.Green, true), new Style(Color.Green, true), 5);

			var r = new Rectangle(rectFrame, new Style(Color.Green, true), new Style(Color.Green, true), 3);
			var e = new Ellipse(eFrame, new Style(Color.Green, true), new Style(Color.Green, true), 3);
			var t = new Triangle(tFrame, new Style(Color.Green, true), new Style(Color.Green, true), 5);

			var group = new Group(new Style(Color.Black, true), new Style(Color.Black, true), 1);
			group.InsertShape(rectangle, 0);
			group.InsertShape(ellipse, 1);
			group.InsertShape(triangle, 2);

			var gFrame = new Rect<float> { Top = 0, Left = 0, Width = 100, Height = 100 };
			group.Frame = gFrame;

			slide.InsertShape(r, 0);
			slide.InsertShape(e, 1);
			slide.InsertShape(t, 2);
			slide.InsertShape(group, 3);
		}
	}
}
