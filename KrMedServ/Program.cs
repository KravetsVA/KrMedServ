using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrMedServ
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Guest> listGuest = new List<Guest> { };
            List<TreatmentRoom> listTreatmentRoom = new List<TreatmentRoom> { };
            List<MedCard> listMedCards = new List<MedCard> { };

            // TEST
            //Guest guest = new Guest(1, "Vladimir", "Kravets");
            //Console.WriteLine(guest.ToString());
            // listGuest.Add(guest);

            // TEST
            //MedCard medCard = new MedCard(guest);
            //Console.WriteLine(medCard.ToString());

            // TEST
            //TreatmentRoom treatmentRoom = new TreatmentRoom(1, "BBBB", QualificMedPersons.Cardiologist);
            //listTreatmentRoom.Add(treatmentRoom);

            // TEST
            /*
            MedProcedure medProc1 = new MedProcedure(1, "Exam", QualificMedPersons.Nurse);
            MedProcedure medProc2 = new MedProcedure(2, "Urine sample", QualificMedPersons.Nurse);
            MedProcedure medProc3 = new MedProcedure(3, "Blood sample", QualificMedPersons.Nurse);
            treatmentRoom.ListMedProc_Add(medProc1);
            treatmentRoom.ListMedProc_Add(medProc2);
            treatmentRoom.ListMedProc_Add(medProc3);
            
            Console.WriteLine(treatmentRoom.ToStringListMedProc());
            Console.WriteLine();
            Console.WriteLine(treatmentRoom.ToStringListMedProcCSV());
            */

            UIMenu menu = new UIMenu();
                        
            while (!menu.FlgExitMenu)
            {
                menu.ShowCurrentMenu();

                if (menu.FlgExitMenu)
                    break;

                // Function processing

                if (menu.CurMenu == CurrentMenu.MenuGuests)
                {
                    switch (menu.SelMenuGuests)
                    {
                        case MenuGuests.LoadListGuestFromFile:
                            listGuest = GuestOper.LoadListGuestFromFile();                            
                            break;
                        case MenuGuests.SaveListGuestToFile:
                            GuestOper.SaveListGuestToFile(listGuest);                            
                            break;
                        case MenuGuests.ListGuest:
                            GuestOper.ListGuest(listGuest);                            
                            break;                        
                        default:
                            break;
                    }
                }

                if (menu.CurMenu == CurrentMenu.MenuTreatmentRooms)
                {
                    switch (menu.SelMenuTreatmentRooms)
                    {
                        case MenuTreatmentRooms.LoadListTreatmentRoomFromFile:
                            listTreatmentRoom = TreatmentRoomOper.LoadListTreatmentRoomFromFile();
                            break;
                        case MenuTreatmentRooms.LoadListProceduresFromFile:
                            listTreatmentRoom = TreatmentRoomOper.LoadListMedProcFromFile();
                            break;
                        case MenuTreatmentRooms.SaveListTreatmentRoomToFile:
                            TreatmentRoomOper.SaveListTreatmentRoomToFile(listTreatmentRoom);
                            break;
                        case MenuTreatmentRooms.ListTreatmentRoom:
                            TreatmentRoomOper.ListTreatmentRoom(listTreatmentRoom);
                            break;
                        case MenuTreatmentRooms.SaveListMedProceduresToFile:
                            TreatmentRoomOper.SaveListMedProcToFile(listTreatmentRoom);
                            break;
                        case MenuTreatmentRooms.ListMedProcedures:
                            TreatmentRoomOper.ListMedProc(listTreatmentRoom);
                            break;
                        default:
                            break;
                    }
                }

                if (menu.CurMenu == CurrentMenu.MenuMedCards)
                {
                    switch (menu.SelMenuMedCards)
                    {
                        case MenuMedCards.CreateMedCards:
                            listMedCards = MedCardsOper.CreateMedCards(listGuest, listTreatmentRoom);
                            break;
                        case MenuMedCards.PrintMedCards:
                            MedCardsOper.PrintMedCards(listMedCards);
                            break;                        
                        default:
                            break;
                    }
                }


            }
            
        }
    }
}
