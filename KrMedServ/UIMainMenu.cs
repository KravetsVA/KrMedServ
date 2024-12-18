using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KrMedServ
{
    internal enum MainMenu
    {
        Exit = 0,
        Guests,
        TreatmentRooms,                
        MedCards,
        // MedPersons
    }
    
    internal static class UIMainMenu
    {
        public static MainMenu ShowMainMenu()
        {        
            string strMainMenu = "| ";

            foreach (MainMenu menu in Enum.GetValues(typeof(MainMenu)))
            {
                strMainMenu += string.Format(" {0} {1} | ", (int)menu, menu);                
            }
            
            Console.WriteLine(strMainMenu + " (select number)");
            Console.WriteLine("---------------------------------------------------------");

            string str = Console.ReadLine();

            bool rez = int.TryParse(str, out int intMenu);

            bool find = false;
            MainMenu findMenu = MainMenu.Exit;
            
            if (rez)
            {
                string name = Enum.GetName(typeof(MainMenu), intMenu);
                
                // Console.WriteLine("Selected {0}) {1}", intMenu, name);
                // Console.WriteLine("{1}", intMenu, name);

                int i = 0;
                foreach (MainMenu menu in Enum.GetValues(typeof(MainMenu)))
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

            return findMenu;
        }        

    }
}
