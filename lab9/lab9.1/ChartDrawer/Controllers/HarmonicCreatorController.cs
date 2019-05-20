using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab9._1.ChartDrawer.Models;

namespace lab9._1.ChartDrawer.Controllers
{
	public sealed class HarmonicCreatorController : IHarmonicCreatorController
	{
		private IMainWindow _mainWindow;

		public HarmonicCreatorController(IMainWindow mainWindow)
		{
			_mainWindow = mainWindow;
		}

		public void AddNewHarmonic(IHarmonic harmonic)
		{
			_mainWindow.AddNewHarmonic(harmonic);
		}
	}
}
