using System;
using SFML.Graphics;
using SFML.Window;
using task1.Composite;
using task1.Shapes;

namespace task1
{
    class Program
    {
		private static string _apllicationName = "Painter";
		private static uint _windowWidth = 800;
		private static uint _windowHeight = 700;

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
				CreatePicture(slide);
				window.Clear(Color.White);
				slide.Draw(canvas);
				window.Display();
				while (window.IsOpen)
				{
					window.DispatchEvents();
				}

				Console.WriteLine("exit");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void CreatePicture(Slide slide)
		{
			var steamR = new Rect<float>(50, 400, 50, 50 );
			var steam = new Ellipse(steamR, new Style(Color.Red, true), new Style(Color.Yellow, true), 2);

			var pipeR = new Rect<float>(150, 350, 50, 150);
			var pipe = new Rectangle(pipeR, new Style(Color.Blue, true), new Style(Color.Red, true), 10);

			var roofR = new Rect<float>(200, 150, 300, 150);
			var roof = new Triangle(roofR, new Style(Color.Yellow, true), new Style(Color.Blue, true), 1);

			var rectR = new Rect<float>(350, 150, 300, 250);
			var rect = new Rectangle(rectR, new Style(Color.Cyan, true), new Style(Color.Magenta, true), 5);

			var windowR = new Rect<float>(400, 250, 100, 100);
			var window = new Rectangle(windowR, new Style(Color.Black, true), new Style(Color.Blue, true), 1);

			var sunR = new Rect<float> { Top = 0, Left = 0, Width = 100, Height = 100 };
			var sun = new Ellipse(sunR, new Style(Color.Red, true), new Style(Color.Green, true), 3);

			var group = new Group(steam);
			group.InsertShape(pipe, 1);
			group.InsertShape(roof, 2);
			// group.FillStyle = new Style(Color.Black, false);

			var house = new Group(group);
			house.InsertShape(rect, 1);
			house.InsertShape(window, 2);

			house.Frame = new Rect<float>(0, 0, 100,100);

			slide.InsertShape(group, 0);
			slide.InsertShape(sun, 1);
			slide.InsertShape(house, 2);
		}
	}
}
