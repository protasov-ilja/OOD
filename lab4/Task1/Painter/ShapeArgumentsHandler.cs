using System.Collections.Generic;
using Task1.Painter.Enums;

namespace Task1.Painter
{
    public class ShapeArgumentsHandler
    {
		private List<string> _shapeArguments;

		private int _index = 0;

		public int ArgumentsLeft
		{
			get { return _shapeArguments.Count - _index; }
		}

		public Color ShapeColor
		{
			get
			{
				if (_index >= _shapeArguments.Count)
				{
					return Color.Black;
				}

				switch (_shapeArguments[_index])
				{
					case "red":
						return Color.Red;
					case "yellow":
						return Color.Yellow;
					case "green":
						return Color.Green;
					case "blue":
						return Color.Blue;
					case "pink":
						return Color.Pink;
					default:
						return Color.Black;
				}
			}
		}

		public ShapeArgumentsHandler(string args)
		{
			_shapeArguments = new List<string>(args.Split(separator: " "));
		}

		public string GetShapeType()
		{
			return _shapeArguments[_index++];
		}

		public int GetNextIntArg()
		{
			return int.Parse(_shapeArguments[_index++]);
		}

		public float GetNextFloatArg()
		{
			return float.Parse(_shapeArguments[_index++]);
		}
    }
}
