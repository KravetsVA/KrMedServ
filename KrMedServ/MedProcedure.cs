using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrMedServ
{
    // These are therapeutic medical procedures.
    internal class MedProcedure
    {
        private int id;
        private string name;
        private QualificMedPersons qualificMedPerson ;
        private double costServices;

        public MedProcedure() 
        {
            this.id = 0;
            this.name = "None";
            this.qualificMedPerson = QualificMedPersons.Nurse;
            this.CostServices = 200;
        }

        public MedProcedure(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.qualificMedPerson = QualificMedPersons.Nurse;
            this.CostServices = 200;
        }

        public MedProcedure(int id, string name, QualificMedPersons qualMedPerson)
        {
            this.id = id;
            this.name = name;
            this.qualificMedPerson = qualMedPerson;
            this.CostServices = 200;
        }

        public int Id 
        {  
            get { return this.id; } 
            set { this.id = value; }        
        } 

        public string Name 
        {  
            get { return this.name; } 
            set { this.name = value; } 
        }
        public  QualificMedPersons QualificMedPerson 
        {
            get { return this.qualificMedPerson; }
            set { this.qualificMedPerson = value; }
        }
        public double CostServices
        {
            get { return this.costServices; }
            set { this.costServices = value; }
        }

    }
}
