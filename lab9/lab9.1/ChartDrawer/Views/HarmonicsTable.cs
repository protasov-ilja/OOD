using System.Windows.Forms;

namespace lab9._1.ChartDrawer.Views
{
	public sealed class HarmonicsTable : HarmonicsVisualizer
	{
		private const float MinChartBorder = 0;
		private const float MaxChartBorder = 4.5f;
		private const float StepSize = 0.5f;

		private DataGridView _table;

		public HarmonicsTable(DataGridView table)
		{
			_table = table;
		}

		protected override void Update()
		{
			_table.Rows.Clear();
			if (_harmonicsData.Count > 0)
			{
				for (float x = MinChartBorder; x <= MaxChartBorder; x += StepSize)
				{
					DataGridViewCell cellX = new DataGridViewTextBoxCell();
					DataGridViewCell cellY = new DataGridViewTextBoxCell();
					cellX.Value = x;
					cellY.Value = GetResultY(x, _harmonicsData);
					DataGridViewRow row = new DataGridViewRow();
					row.Cells.AddRange(cellX, cellY);
					_table.Rows.Add(row);
				}
			}
		}
	}
}
