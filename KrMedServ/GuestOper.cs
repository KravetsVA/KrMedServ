using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KrMedServ
{
    internal static class GuestOper
    {
        const string FILE_NAME_LISTGUEST = "ListGuest.txt";

        public static void SaveListGuestToFile(List<Guest> listGuest)
        {           
            string fileName = "..\\..\\..\\" + FILE_NAME_LISTGUEST;

            using (FileStream fsOut = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                StreamWriter wrtr = new StreamWriter(fsOut);
          
                foreach (var guest in listGuest)
                {
                    wrtr.WriteLine("{0}", guest.ToStringCSV());
                }

                wrtr.Flush();
            }

            Console.WriteLine($"Save ListGuest to file: {FILE_NAME_LISTGUEST}", FILE_NAME_LISTGUEST);
            Console.WriteLine();
        }

        public static List<Guest> LoadListGuestFromFile()
        {
            string strId = "";                            
            string strFirstName = "";
            string strLastName = "";
            string strAge = "";
            string strPassportDetails = "";
            string strNumberHotelRoom = "";

            int Id = 0;            
            int Age = 0;            
            int NumberHotelRoom = 0;

            List<Guest> listGuest = new List<Guest> { };            

            string fileName = "..\\..\\..\\" + FILE_NAME_LISTGUEST;

            using (FileStream fsOut = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                StreamReader redr = new StreamReader(fsOut);

                while (!redr.EndOfStream)
                {
                    var line = redr.ReadLine();
                    var values = line.Split(',');

                    int sch = 0;
                    Guest guest = new Guest();
                    
                    foreach (var value in values)
                    {
                        switch (sch)
                        {
                            case 0:
                                strId = value; break;
                            case 1:
                                strFirstName = value; break;
                            case 2:
                                strLastName = value; break;
                            case 3:
                                strAge = value; break;
                            case 4:
                                strPassportDetails = value; break;
                            case 5:
                                strNumberHotelRoom = value; break;
                            default:
                                break;

                        }
                        sch++;
                    }

                    bool rez = int.TryParse(strId, out Id);
                    if (rez)
                    {
                        guest.Id = Id;
                    }

                    rez = int.TryParse(strAge, out Age);
                    if (rez)
                    {
                        guest.Age = Age;
                    }
 
                    rez = int.TryParse(strNumberHotelRoom, out NumberHotelRoom);
                    if (rez)
                    {
                        guest.NumberHotelRoom = NumberHotelRoom;
                    }

                    guest.FirstName = strFirstName;
                    guest.LastName = strLastName;
                    guest.PassportDetails = strPassportDetails;

                    listGuest.Add(guest);
                }
                
            }

            Console.WriteLine($"Load ListGuest from file: {FILE_NAME_LISTGUEST}", FILE_NAME_LISTGUEST);
            Console.WriteLine();

            return listGuest;
        }

        public static void ListGuest(List<Guest> listGuest)
        {
            foreach (Guest guest in listGuest)
            {
                Console.WriteLine(guest.ToString());
            }

            Console.WriteLine("");
        }

    }
}
