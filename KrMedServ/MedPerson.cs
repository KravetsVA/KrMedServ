using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrMedServ
{
    // Medical staff
    internal class MedPerson : Person
    {
        private QualificMedPersons qualificMedPerson;
        private double salary;

        public MedPerson()
        {
            this.Id = 0;
            this.FirstName = "None";
            this.LastName = "None";
            this.Age = 0;
            this.PassportDetails = "None";
            this.qualificMedPerson = QualificMedPersons.None;
            this.salary = 0;
        }

        public MedPerson(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = 0;
            this.PassportDetails = "None";
            this.qualificMedPerson = QualificMedPersons.Nurse;
            this.salary = 0;
        }

        public MedPerson(int id, string firstName, string lastName, string passportDetails)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = 0;
            this.PassportDetails = passportDetails;
            this.qualificMedPerson = QualificMedPersons.Nurse;
            this.salary = 0;
        }

        public QualificMedPersons QualificMedPerson
        {
            get { return qualificMedPerson; }
            set { qualificMedPerson = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

    }
}
