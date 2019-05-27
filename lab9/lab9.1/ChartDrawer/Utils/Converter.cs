using lab9._1.ChartDrawer.Models.Enums;
using lab9._1.ChartDrawer.Views;

namespace lab9._1.ChartDrawer.Utils
{
	public sealed class Converter
	{
		public static string GetStringRepresentation(HarmonicData harmonicData)
		{
			return $"{ harmonicData.Amplitude } * { (harmonicData.Type == HarmonicType.Cos ? "cos" : "sin") }({ harmonicData.Frequency } * x + { harmonicData.Phase })";
		}
	}
}
