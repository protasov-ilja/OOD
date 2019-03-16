namespace Task1.Painter
{
	public class Designer
    {
		private IShapeFactory _factory;

		public Designer(IShapeFactory factory)
		{
			_factory = factory;
		}

		//public PictureDraft CreateDraft(std::istream inputData)
		//{
		//	PictureDraft draft;
		//	string line;
		//	while (getline(inputData, line))
		//	{
		//		draft.AddShape(m_factory.CreateShape(line));
		//	}

		//	return draft;
		//}
	}
}
