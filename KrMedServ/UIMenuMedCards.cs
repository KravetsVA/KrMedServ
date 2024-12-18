using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrMedServ
{
    internal enum MenuMedCards
    {
        Exit = 0,
        CreateMedCards,
        PrintMedCards
    }

    internal class UIMenuMedCards
    {
        public static MenuMedCards ShowMenuMedCards()
        {
            Console.WriteLine("Med cards (select number)");

            foreach (MenuMedCards menu in Enum.GetValues(typeof(MenuMedCards)))
            {
                Console.WriteLine("({0}) {1}", (int)menu, menu);
            }

            string str = Console.ReadLine();

            bool rez = int.TryParse(str, out int intMenu);

            bool find = false;
            MenuMedCards findMenu = MenuMedCards.Exit;

            if (rez)
            {
                string name = Enum.GetName(typeof(MenuMedCards), intMenu);                

                int i = 0;
                foreach (MenuMedCards menu in Enum.GetValues(typeof(MenuMedCards)))
                {
                    if (i == intMenu)
                    {
                        find = true;
                        findMenu = menu;
                    }
                    i++;
                }
            }
            else
            {                
                throw new ArgumentException($"Please, enter an integer value");
            }

            Console.WriteLine("");
            return findMenu;
        }
    }
}
