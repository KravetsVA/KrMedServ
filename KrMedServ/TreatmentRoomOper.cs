using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KrMedServ
{
    internal static class TreatmentRoomOper
    {
        const string FILE_NAME_LISTTREATMENROOMS = "ListTreatmentRoom.txt";
        const string FILE_NAME_LISTMEDPROCEDURES = "ListMedProcedure.txt";

        #region SaveToFile

        public static void SaveListTreatmentRoomToFile(List<TreatmentRoom> listTreatmentRoom)
        {
            string fileName = "..\\..\\..\\" + FILE_NAME_LISTTREATMENROOMS;

            using (FileStream fsOut = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                StreamWriter wrtr = new StreamWriter(fsOut);

                foreach (var treatmentRoom in listTreatmentRoom)
                {
                    wrtr.WriteLine("{0}", treatmentRoom.ToStringCSV());
                }

                wrtr.Flush();
            }

            Console.WriteLine($"Save ListTreatmentRoom to file: {FILE_NAME_LISTTREATMENROOMS}", FILE_NAME_LISTTREATMENROOMS);
            Console.WriteLine();
        }

        public static void SaveListMedProcToFile(List<TreatmentRoom> listTreatmentRoom)
        {            
            string fileName = "..\\..\\..\\" + FILE_NAME_LISTMEDPROCEDURES;

            using (FileStream fsOut = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                StreamWriter wrtr = new StreamWriter(fsOut);

                foreach (var treatmentRoom in listTreatmentRoom)
                {
                    wrtr.WriteLine("{0}", treatmentRoom.ToStringListMedProcCSV());
                }

                wrtr.Flush();
            }

            Console.WriteLine($"Save ListMedProc to file: {FILE_NAME_LISTMEDPROCEDURES}", FILE_NAME_LISTMEDPROCEDURES);
            Console.WriteLine();
        }
        #endregion

        #region LoadFromFile

        public static List<TreatmentRoom> LoadListTreatmentRoomFromFile()
        {
            string strId = "";
            string strName = "";
            string strQualificMedPerson = "";

            List<TreatmentRoom> listTreatmentRoom = new List<TreatmentRoom> { };

            string fileName = "..\\..\\..\\" + FILE_NAME_LISTTREATMENROOMS;

            using (FileStream fsOut = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                StreamReader redr = new StreamReader(fsOut);

                while (!redr.EndOfStream)
                {
                    var line = redr.ReadLine();
                    var values = line.Split(',');
                    
                    TreatmentRoom treatmentRoom = new TreatmentRoom();

                    int sch = 0;
                    foreach (var value in values)
                    {
                        switch (sch)
                        {
                            case 0:
                                strId = value; break;
                            case 1:
                                strName = value; break;
                            case 2:
                                strQualificMedPerson = value; break;                            
                            default:
                                break;

                        }
                        sch++;
                    }

                    bool rez = int.TryParse(strId, out int Id);
                    if (rez)
                    {
                        treatmentRoom.Id = Id;
                    }
                
                    var valuesQualMedPersons = Enum.GetValues(typeof(QualificMedPersons));
                    foreach (QualificMedPersons value in valuesQualMedPersons)
                    {                        
                        if (Enum.GetName(typeof(QualificMedPersons), value) == strQualificMedPerson)
                            treatmentRoom.QualificMedPerson = value;
                    }
                    
                    treatmentRoom.Name = strName;

                    listTreatmentRoom.Add(treatmentRoom);
                }

            }

            Console.WriteLine($"Load ListTreatmentRoom from file: {FILE_NAME_LISTTREATMENROOMS}", FILE_NAME_LISTTREATMENROOMS);
            Console.WriteLine();

            return listTreatmentRoom;
        }

        public static List<TreatmentRoom> LoadListMedProcFromFile()
        {
            string strIdTrRoom  = "";
            string strIdMedProc = "";
            string strName = "";
            string strQualificMedPerson = "";
            string strCostServices = "";

            List<TreatmentRoom> listTreatmentRoom = LoadListTreatmentRoomFromFile();

            string fileName = "..\\..\\..\\" + FILE_NAME_LISTMEDPROCEDURES;

            using (FileStream fsOut = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                StreamReader redr = new StreamReader(fsOut);

                while (!redr.EndOfStream)
                {
                    var line   = redr.ReadLine();
                    var values = line.Split(',');
                    
                    MedProcedure medProc = new MedProcedure();

                    int sch = 0;
                    foreach (var value in values)
                    {
                        switch (sch)
                        {
                            case 0:
                                strIdTrRoom = value; break;
                            case 1:
                                strIdMedProc = value; break;
                            case 2:
                                strName = value; break;
                            case 3:
                                strQualificMedPerson = value; break;
                            case 4:
                                strCostServices = value; break;
                            default:
                                break;

                        }
                        sch++;
                    }

                    TreatmentRoom trRoom = null;

                    bool rez = int.TryParse(strIdTrRoom, out int IdTrRoom);
                    if (rez)
                    {
                        // treatmentRoom.Id = IdTrRoom;
                        foreach(TreatmentRoom treatmentRoom in listTreatmentRoom)
                        {
                            if(treatmentRoom.Id == IdTrRoom)
                            {
                                trRoom = treatmentRoom;
                                break;
                            }
                        }
                    }

                    if (trRoom != null)
                    {
                        rez = int.TryParse(strIdMedProc, out int IdMedProc);
                        if (rez)
                        {
                            medProc.Id = IdMedProc;
                        }

                        var valuesQualMedPersons = Enum.GetValues(typeof(QualificMedPersons));
                        foreach (QualificMedPersons value in valuesQualMedPersons)
                        {
                            if (Enum.GetName(typeof(QualificMedPersons), value) == strQualificMedPerson)
                                medProc.QualificMedPerson = value;
                        }

                        double costServices = double.Parse(strCostServices, CultureInfo.InvariantCulture);
                        medProc.CostServices = costServices;
                        
                        medProc.Name = strName;

                        trRoom.ListMedProcedures.Add(medProc);
                    }

                    
                }

            }

            Console.WriteLine($"Load ListMedProcedure from file: {FILE_NAME_LISTMEDPROCEDURES}", FILE_NAME_LISTMEDPROCEDURES);
            Console.WriteLine();

            return listTreatmentRoom;
        }

        #endregion

        #region List

        public static void ListTreatmentRoom(List<TreatmentRoom> listTreatmentRoom)
        {
            foreach (TreatmentRoom treatmentRoom in listTreatmentRoom)
            {
                Console.WriteLine(treatmentRoom.ToString());
            }

            Console.WriteLine("");
        }

        public static void ListMedProc(List<TreatmentRoom> listTreatmentRoom)
        {
            foreach (TreatmentRoom treatmentRoom in listTreatmentRoom)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine(treatmentRoom.ToString());
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine(treatmentRoom.ToStringListMedProc());
                Console.WriteLine();
            }

            Console.WriteLine("");
        }

        public static List<MedProcedure> ListMedProc(TreatmentRoom treatmentRoom)
        {
            return treatmentRoom.ListMedProcedures;            

        }

        #endregion

    }
}
