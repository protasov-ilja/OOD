namespace task1.Composite.Styles
{
	public interface IOutlineStyle : IStyle
	{
		float? GetLineThickness();
		void SetLineThickness(float thickness);
	}
}
