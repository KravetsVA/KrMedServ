using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrMedServ
{
    internal enum MenuGuests
    {
        Exit = 0,
        LoadListGuestFromFile,
        ListGuest,        
        SaveListGuestToFile,
    }

    internal static class UIMenuGuests
    {
        public static MenuGuests ShowMenuGuests()
        {
            Console.WriteLine("Guests (select number)");

            foreach (MenuGuests menu in Enum.GetValues(typeof(MenuGuests)))
            {
                Console.WriteLine("({0}) {1}", (int)menu, menu);
            }

            string str = Console.ReadLine();

            bool rez = int.TryParse(str, out int intMenu);

            bool find = false;
            MenuGuests findMenu = MenuGuests.Exit;

            if (rez)
            {
                string name = Enum.GetName(typeof(MenuGuests), intMenu);                
                
                //Console.WriteLine("{1}", intMenu, name);

                int i = 0;
                foreach (MenuGuests menu in Enum.GetValues(typeof(MenuGuests)))
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
                // Console.WriteLine("Value {0} does not number");                         
                throw new ArgumentException($"Please, enter an integer value");
            }

            Console.WriteLine("");
            return findMenu;
        }

    }
}
