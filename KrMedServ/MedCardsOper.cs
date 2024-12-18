using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrMedServ
{
    internal static class MedCardsOper
    {

        public static List<MedCard> CreateMedCards(List<Guest> listGuest, List<TreatmentRoom> listTreatmentRoom)
        {
            List<MedCard> listMedCards = new List<MedCard>();

            foreach (Guest guest in listGuest)
            {
                MedCard medCard = new MedCard(guest);
                
                Random rng = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int idMedProc = rng.Next(11);

                    bool findMedProc = false;

                    foreach (TreatmentRoom room in listTreatmentRoom)
                    {
                        List<MedProcedure> listMedProc = room.ListMedProcedures;
                     
                        foreach (MedProcedure medProc in listMedProc)
                        {
                            if (idMedProc == medProc.Id)
                            {                                 
                                medCard.ListMedProcedures.Add(medProc);
                                
                                DateTime dateMedServ1 = new DateTime(2024, 12, i + 1);
                                
                                MedService medServ1 = new MedService(guest, dateMedServ1, room, medProc);
                                
                                medCard.ListMedServices.Add(medServ1);

                                findMedProc = true;                                
                            }
                            if (findMedProc)
                                break;
                        }
                        if (findMedProc)
                            break;
                    }

                }

                listMedCards.Add(medCard); 
            }
            
            return listMedCards;
        }

        public static void PrintMedCards(List<MedCard> listMedCards)
        {
            foreach (MedCard medCard in listMedCards)
            {
                Console.WriteLine(medCard.ToString());
            }
        }
    }

}
