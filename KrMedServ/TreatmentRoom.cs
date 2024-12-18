using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrMedServ
{
    // Treatment room at the dispensary.
    internal class TreatmentRoom
    {
        private int id;
        private string name;        
        private QualificMedPersons qualificMedPerson;
        List<MedProcedure> listMedProcedures;        

        public override string ToString()
        {
            string strComma = ",";

            StringBuilder sbConcatGuest = new StringBuilder();

            sbConcatGuest.AppendFormat($"Id: {Id}", Id).Append(strComma)
                .AppendFormat($"Name: {Name}", Name).Append(strComma)
                .AppendFormat($"Qualification: {QualificMedPerson}", QualificMedPerson).Append(strComma);
                
            return sbConcatGuest.ToString();
        }

        public string ToStringCSV()
        {
            string strComma = ",";

            StringBuilder sbConcatGuest = new StringBuilder();

            sbConcatGuest.Append(Id).Append(strComma)
                .Append(Name).Append(strComma)
                .Append(qualificMedPerson).Append(strComma);

            return sbConcatGuest.ToString();
        }

        public string ToStringListMedProc()
        {
            string strComma = ",";

            StringBuilder sbConcatGuest = new StringBuilder();

            foreach (MedProcedure proc in listMedProcedures)
            {
                sbConcatGuest.AppendFormat($"Id TrRoom: {Id}").Append(strComma)
                .AppendFormat($"Id Proc : {proc.Id}").Append(strComma)
                .AppendFormat($"Name: {proc.Name}").Append(strComma)
                .AppendFormat($"Qualification: {proc.QualificMedPerson}").Append(strComma)
                .AppendFormat($"CostServices: {proc.CostServices.ToString(CultureInfo.InvariantCulture)}")
                .AppendLine();
            }

            return sbConcatGuest.ToString();
        }

        public string ToStringListMedProcCSV()
        {
            string strComma = ",";

            StringBuilder sbConcatGuest = new StringBuilder();

            foreach (MedProcedure proc in listMedProcedures)
            {
                sbConcatGuest.AppendFormat($"{Id}").Append(strComma)
                .AppendFormat($"{proc.Id}").Append(strComma)
                .AppendFormat($"{proc.Name}").Append(strComma)
                .AppendFormat($"{proc.QualificMedPerson}").Append(strComma)
                .AppendLine();
            }

            return sbConcatGuest.ToString();
        }

        public TreatmentRoom()
        {
            this.id = 0;
            this.name = "Treatment room " + id;
            this.qualificMedPerson = QualificMedPersons.Nurse;
            this.listMedProcedures = new List<MedProcedure>();
        }

        public TreatmentRoom(int id)
        {
            this.id = id;
            this.name = "Treatment room " + id;
            this.qualificMedPerson = QualificMedPersons.Nurse;
            this.listMedProcedures = new List<MedProcedure>();
        }

        public TreatmentRoom(int id, QualificMedPersons qualificMedPerson)
        {
            this.id = id;
            this.name = "Treatment room " + id;
            this.qualificMedPerson = qualificMedPerson;
            this.listMedProcedures = new List<MedProcedure>();
        }

        public TreatmentRoom(int id, string name, QualificMedPersons qualificMedPerson)
        {
            this.id = id;
            this.name = name;
            this.qualificMedPerson = qualificMedPerson;
            this.listMedProcedures = new List<MedProcedure>();
        }

        public TreatmentRoom(int id, string name, QualificMedPersons qualificMedPerson, List<MedProcedure> listMedProcedures) : this(id, name, qualificMedPerson)
        {
            this.listMedProcedures = listMedProcedures;
        }

        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        public string Name 
        { 
            get { return name; }
            set { this.name = value; }
        }

        public QualificMedPersons QualificMedPerson
        {
            get { return qualificMedPerson; }
            set { qualificMedPerson = value; }
        }

        public List<MedProcedure> ListMedProcedures
        {
            get { return listMedProcedures; }            
        }

        public void ListMedProc_Add(MedProcedure medProc)
        {
            listMedProcedures.Add(medProc);
        }
        public void ListMedProc_Remove(MedProcedure medProc)
        {
            listMedProcedures.Remove(medProc);
        }

       

    }
}
