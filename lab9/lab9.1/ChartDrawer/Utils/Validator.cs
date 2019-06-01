using System.Windows.Forms;

namespace lab9._1.ChartDrawer.Utils
{
	public sealed class Validator
	{
		public static bool TryValidateTextBox(TextBox box, out float result)
		{
			result = 0;
			var text = box.Text;
			var isEmplty = text.Length == 0;
			if (!isEmplty && float.TryParse(text, out var value))
			{
				result = value;
				return true;
			}

			if (!isEmplty)
			{
				box.Text = "";
			}

			return false;
		}
	}
}
