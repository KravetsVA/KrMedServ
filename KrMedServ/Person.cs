using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KrMedServ
{
    internal class Person
    {
        private int id;
        private string firstName;
        private string lastName;
        private int age;
        private string passportDetails;

        public Person()
        {
            this.id = 0;
            this.firstName = "None";
            this.lastName = "None";
            this.age = 0;
            this.passportDetails = "None";
        }

        public Person(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = 0;
            this.passportDetails = "None";
        }

        public Person(int id, string firstName, string lastName, int age, string passportDetails)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.passportDetails = passportDetails;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string FirstName
        { 
            get { return this.firstName; } 
            set { this.firstName = value; } 
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public int Age 
        { 
            get { return this.age; } 
            set { this.age = value; } 
        }
        public string PassportDetails
        {
            get { return this.passportDetails; }
            set { this.passportDetails = value; }
        }

    }
}
