using System;
using task1.Beverages;
using task1.Condiments;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
			{
				var latte = new Latte(LatteType.Double);
				var cinnamon = new Cinnamon(latte);
				var lemon = new Lemon(cinnamon, 2);
				var iceCubes = new IceCubes(lemon, 2, IceCubeType.Dry);
				var beverage = new ChocolateCrumbs(iceCubes, 2);

				Console.WriteLine(beverage.GetDescription() + " costs " + beverage.GetCost());
			}

			{
				var beverage =
					new ChocolateCrumbs(          // Внешний слой: шоколадная крошка
						new IceCubes(             // | под нею - кубики льда
							new Lemon(            // | | еще ниже лимон
								new Cinnamon(     // | | | слоем ниже - корица
									new Latte(LatteType.Standart)), // | | |   в самом сердце - Латте
								2),                         // | | 2 дольки лимона
							2, IceCubeType.Dry),           // | 2 кубика сухого льда
						2);                                 // 2 грамма шоколадной крошки

				Console.WriteLine(beverage.GetDescription() + " costs " + beverage.GetCost());
			}

			{
				var capuccino = new Cappuccino(CappuccinoType.Standart);
				var chocolateSlice = new ChocolateSlice(capuccino, 6);
				var liquor = new Liquor(chocolateSlice, LiquorType.Nut);
				var beverage = new Cream(liquor);

				Console.WriteLine(beverage.GetDescription() + " costs " + beverage.GetCost());
			}

			{
				var milkshake = new Milkshake(MilkshakeType.Big);
				var chocolateSlice = new ChocolateSlice(milkshake, 4);
				var liquor = new Liquor(chocolateSlice, LiquorType.Chocolate);
				var beverage = new Cream(liquor);

				Console.WriteLine(beverage.GetDescription() + " costs " + beverage.GetCost());
			}
		}
    }
}
