using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrMedServ
{
    internal enum MenuTreatmentRooms
    {
        Exit = 0,
        LoadListTreatmentRoomFromFile,
        LoadListProceduresFromFile,
        ListTreatmentRoom,        
        ListMedProcedures,
        SaveListTreatmentRoomToFile,        
        SaveListMedProceduresToFile
    }

    internal class UIMenuTreatmentRoom
    {
        public static MenuTreatmentRooms ShowMenuTreatmentRooms()
        {
            Console.WriteLine("Treatment rooms (select number)");

            foreach (MenuTreatmentRooms menu in Enum.GetValues(typeof(MenuTreatmentRooms)))
            {
                Console.WriteLine("({0}) {1}", (int)menu, menu);
            }

            string str = Console.ReadLine();

            bool rez = int.TryParse(str, out int intMenu);

            bool find = false;
            MenuTreatmentRooms findMenu = MenuTreatmentRooms.Exit;

            if (rez)
            {
                string name = Enum.GetName(typeof(MenuTreatmentRooms), intMenu);

                //Console.WriteLine("{1}", intMenu, name);

                int i = 0;
                foreach (MenuTreatmentRooms menu in Enum.GetValues(typeof(MenuTreatmentRooms)))
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
