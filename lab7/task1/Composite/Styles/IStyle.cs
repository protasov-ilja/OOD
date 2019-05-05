using SFML.Graphics;

namespace task1.Composite.Styles
{
	public interface IStyle
	{
		Color? GetColor();
		void SetColor(Color color);

		bool? IsEnabled();
		void Enable(bool enable);

		bool IsComposite();
	}
}
