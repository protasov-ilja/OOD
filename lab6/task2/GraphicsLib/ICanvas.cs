namespace task2.GraphicsLib
{
    public interface ICanvas
    {
		void SetColor(uint rgbColor);
		// Ставит "перо" в точку x, y
		void MoveTo(int x, int y);
		// Рисует линию с текущей позиции, передвигая перо в точку x,y 
		void LineTo(int x, int y);
    }
}
