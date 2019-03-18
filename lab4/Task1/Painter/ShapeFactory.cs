using System;
using System.Collections.Generic;
using Task1.Painter.Shapes;

namespace Task1.Painter
{
	public class ShapeFactory : IShapeFactory
	{
		private const string CommandAddRectangle = "rectangle";
		private const string CommandAddTriangle = "triangle";
		private const string CommandAddEllipse = "ellipse";
		private const string CommandAddPolygon = "polygon";

		private readonly Dictionary<string, Func<ShapeArgumentsHandler, Shape>> _actionMap;

		public ShapeFactory()
		{
			_actionMap = new Dictionary<string, Func<ShapeArgumentsHandler, Shape>>
			{
				{ CommandAddRectangle, CreateRectangle },
				{ CommandAddTriangle, CreateTriangle },
				{ CommandAddEllipse, CreateEllipse },
				{ CommandAddPolygon, CreateRegularPolygon }
			};
		}

		public Shape CreateShape(string description)
		{
			var shapeArgumentsHandler = new ShapeArgumentsHandler(description);
			var shapeType = shapeArgumentsHandler.GetShapeType();
			if (_actionMap.ContainsKey(shapeType))
			{
				return _actionMap[shapeType](shapeArgumentsHandler);
			}

			throw new Exception($"can't found command {shapeType}");
		}

		private Shape CreateRectangle(ShapeArgumentsHandler argsHandler)
		{
			if (argsHandler.ArgumentsLeft < 4)
			{
				throw new ArgumentException("Invalid number of arguments to create rectangle", "rectangleArgs");
			}

			var leftTop = new Point(argsHandler.GetNextFloatArg(), argsHandler.GetNextFloatArg());
			var rightBottom = new Point(argsHandler.GetNextFloatArg(), argsHandler.GetNextFloatArg());
			var color = argsHandler.ShapeColor;

			return new Rectangle(leftTop, rightBottom, color);
		}

		Shape CreateTriangle(ShapeArgumentsHandler argsHandler)
		{
			if (argsHandler.ArgumentsLeft < 6)
			{
				throw new ArgumentException("Invalid number of arguments to create triangle", "triangleArgs");
			}

			var v1 = new Point(argsHandler.GetNextFloatArg(), argsHandler.GetNextFloatArg());
			var v2 = new Point(argsHandler.GetNextFloatArg(), argsHandler.GetNextFloatArg());
			var v3 = new Point(argsHandler.GetNextFloatArg(), argsHandler.GetNextFloatArg());
			var color = argsHandler.ShapeColor;

			return new Triangle(v1, v2, v3, color);
		}

		Shape CreateEllipse(ShapeArgumentsHandler argsHandler)
		{
			if (argsHandler.ArgumentsLeft < 4)
			{
				throw new ArgumentException("Invalid number of arguments to create ellipse", "ellipseArgs");
			}

			var center = new Point(argsHandler.GetNextFloatArg(), argsHandler.GetNextFloatArg());
			var horizontalRadius = argsHandler.GetNextFloatArg();
			var verticalRadius = argsHandler.GetNextFloatArg();
			var color = argsHandler.ShapeColor;

			return new Ellipse(center, horizontalRadius, verticalRadius, color);
		}

		Shape CreateRegularPolygon(ShapeArgumentsHandler argsHandler)
		{
			if (argsHandler.ArgumentsLeft < 4)
			{
				throw new ArgumentException("Invalid number of arguments to create polygon", "polygonArgs");
			}

			var vertexCount = argsHandler.GetNextIntArg();
			var center = new Point(argsHandler.GetNextFloatArg(), argsHandler.GetNextFloatArg());
			var radius = argsHandler.GetNextFloatArg();
			var color = argsHandler.ShapeColor;

			return new RegularPolygon(vertexCount, center, radius, color);
		}
	}
}
