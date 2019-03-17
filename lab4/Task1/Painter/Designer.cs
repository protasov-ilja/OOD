using System;
using System.IO;

namespace Task1.Painter
{
	public enum DraftState
	{
		ShapeAdded,
		ShapeNotAdded
	};

	public class Designer : IDesigner
    {
		private const string CommandExit = "exit";

		private IShapeFactory _factory;

		public Designer(IShapeFactory factory)
		{
			_factory = factory;
		}

		public PictureDraft CreateDraft(TextReader inputData)
		{
			PictureDraft draft = new PictureDraft();
			while (true)
			{
				try
				{
					var command = inputData.ReadLine().ToLower();
					if (command == null || command == CommandExit)
					{
						break;
					}

					draft.AddShape(_factory.CreateShape(command));
					Console.WriteLine("Successfuly added!");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Sth went wrong... {ex.Message}");
				}
			}

			return draft;
		}
	}
}
