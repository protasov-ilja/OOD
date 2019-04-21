using task1.Shapes;

namespace task1.Composite
{
	public interface IComponent : IShape
	{
		IComponent Parent { get; set; }

		void RecalculateFillStyle();
		void RecalculateOutlineStyle();
		void RecalculateFrame();
		void RecalculateLineThickness();

		void InsertShape(IComponent shape, int position);
		void RemoveShapeAtIndex(int index);
		int GetShapesCount();
	}
}
