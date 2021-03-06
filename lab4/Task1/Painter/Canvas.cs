﻿using System;
using Task1.Painter.Enums;

namespace Task1.Painter
{
	public class Canvas : ICanvas
	{
		Color ICanvas.Color { get; set; }

		public void DrawEllipse(double l, double t, double width, double height)
		{
			Console.WriteLine($"l: {l} t: {t} width: {width} height: {height}");
		}

		public void DrawLine(Point from, Point to)
		{
			Console.WriteLine($"from: {from} to: {to}");
		}
	}
}
