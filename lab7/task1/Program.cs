using System;
using SFML.Graphics;
using SFML.Window;
using task1.Composite;
using task1.Composite.Styles;
using task1.Shapes;

namespace task1
{
    class Program
    {
		private const string _apllicationName = "Painter";
		private const uint _windowWidth = 800;
		private const uint _windowHeight = 700;

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
				var canvas = new Canvas(window);
				var slide = new Slide(_windowWidth, _windowHeight);
				CreatePicture(slide);
				
				while (window.IsOpen)
				{
					window.Clear(Color.White);
					slide.Draw(canvas);
					window.Display();
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
			var steamR = new Rect<float>(50, 400, 50, 50);
			var steam = new Ellipse(steamR, new OutlineStyle(Color.Red, true, 2), new FillStyle(Color.Yellow, true));

			var pipeR = new Rect<float>(150, 350, 50, 150);
			var pipe = new Rectangle(pipeR, new OutlineStyle(Color.Blue, true, 10), new FillStyle(Color.Red, true));

			var roofR = new Rect<float>(200, 150, 300, 150);
			var roof = new Triangle(roofR, new OutlineStyle(Color.Yellow, true, 1), new FillStyle(Color.Blue, true));

			var rectR = new Rect<float>(350, 150, 300, 250);
			var rect = new Rectangle(rectR, new OutlineStyle(Color.Cyan, true, 5), new FillStyle(Color.Magenta, true));

			var windowR = new Rect<float>(400, 250, 100, 100);
			var window = new Rectangle(windowR, new OutlineStyle(Color.Black, true, 1), new FillStyle(Color.Blue, true));

			var sunR = new Rect<float> { Top = 0, Left = 0, Width = 100, Height = 100 };
			var sun = new Ellipse(sunR, new OutlineStyle(Color.Red, true, 3), new FillStyle(Color.Green, true));

			var group = new Group(steam);
			group.InsertShape(pipe, 1);
			group.InsertShape(roof, 2);
			group.FillStyle.SetColor(Color.Black);

			var house = new Group(group);
			house.InsertShape(rect, 1);
			house.InsertShape(window, 2);

			house.SetFrame(new Rect<float>(0, 0, 100, 100));

			slide.InsertShape(group, 0);
			slide.InsertShape(sun, 1);
			slide.InsertShape(house, 2);
		}
	}
}
