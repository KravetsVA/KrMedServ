using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace KrMedServ
{
    // Guest - this is a patient at the dispensary.
    internal class Guest : Person
    {
        private int numberHotelRoom;        

        public Guest()
        {
            this.Id = 0;
            this.FirstName = "None";
            this.LastName = "None";
            this.Age = 0;
            this.PassportDetails = "None";
            this.NumberHotelRoom = 0;        
        }

        public Guest(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = 0;
            this.PassportDetails = "None";
            this.NumberHotelRoom = 0;            
        }

        public Guest(int id, string firstName, string lastName, int numberHotelRoom, int totalCostServices)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = 0;
            this.PassportDetails = "None";
            this.NumberHotelRoom = 0;            
        }

        public Guest(int id, string firstName, string lastName, int age, string passportDetails)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.PassportDetails = passportDetails;
            this.NumberHotelRoom = 0;            
        }

        public int NumberHotelRoom
        {
            get { return numberHotelRoom; }
            set { numberHotelRoom = value; }
        }

        public override string ToString()
        {
            string strComma = ",";

            StringBuilder sbConcatGuest = new StringBuilder();

            sbConcatGuest.AppendFormat($"Id: {Id}", Id).Append(strComma)
                .AppendFormat($"FirstName: {FirstName}", FirstName).Append(strComma)
                .AppendFormat($"LastName: {LastName}", LastName).Append(strComma)
                .AppendFormat($"Age: {Age}", Age).Append(strComma)
                .AppendFormat($"PassportDetails: {PassportDetails}", PassportDetails).Append(strComma)
                .AppendFormat($"NumberHotelRoom: {NumberHotelRoom}", NumberHotelRoom);
            
            return sbConcatGuest.ToString();
        }

        public string ToStringCSV()
        {
            string strComma = ",";

            StringBuilder sbConcatGuest = new StringBuilder();

            sbConcatGuest.Append(Id).Append(strComma)
                .Append(FirstName).Append(strComma)
                .Append(LastName).Append(strComma)
                .Append(Age).Append(strComma)
                .Append(PassportDetails).Append(strComma)
                .Append(NumberHotelRoom).Append(strComma);

            return sbConcatGuest.ToString();
        }

    }
}
