namespace Task1.Painter
{
	public interface IShapeFactory
    {
		IShape CreateShape(string description);
	}
}
