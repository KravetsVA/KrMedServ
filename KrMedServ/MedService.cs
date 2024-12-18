using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KrMedServ
{
    // MedService - is a coupon for the provision of medical services.
    // In calculations we use the fact of rendering medical services.
    internal class MedService
    {
        private Guest guest;
        private MedPerson medPerson;
        private DateTime dateMedService;
        private TreatmentRoom treatmentRoom;
        private MedProcedure medProcedure;

        public MedService(Guest guest)
        {
            this.guest = guest;
            this.medPerson = new MedPerson();            

            var thTH = new System.Globalization.CultureInfo("th-TH");
            var cal = thTH.DateTimeFormat.Calendar;
            this.dateMedService = new DateTime(2024, 1, 1, cal);

            this.treatmentRoom = new TreatmentRoom();
            this.medProcedure = new MedProcedure();
        }

        public MedService(Guest guest, DateTime dateMedService, TreatmentRoom treatmentRoom, MedProcedure medProcedure)
        {
            this.guest = guest;
            this.medPerson = new MedPerson();

            /*
            var thTH = new System.Globalization.CultureInfo("th-TH");
            var cal = thTH.DateTimeFormat.Calendar;
            this.dateMedService = new DateTime(2024, 1, 1, cal);
            */
            this.dateMedService = dateMedService;

            this.treatmentRoom = treatmentRoom;
            this.medProcedure = medProcedure;
        }

        public MedService(Guest guest, MedPerson medPerson, DateTime dateMedService, TreatmentRoom treatmentRoom, MedProcedure medProcedure)
        {
            this.guest = guest;
            this.medPerson = medPerson;

            /*
            var thTH = new System.Globalization.CultureInfo("th-TH");
            var cal = thTH.DateTimeFormat.Calendar;
            this.dateMedService = new DateTime(2024, 1, 1, cal);
            */
            this.dateMedService = dateMedService;

            this.treatmentRoom = treatmentRoom;
            this.medProcedure = medProcedure;
        }

        public Guest Guest 
        { 
            get { return guest; } 
            set { guest = value; }
        }

        public MedPerson MedPerson
        {
            get { return medPerson; }
            set { medPerson = value; }
        }

        public DateTime DateMedService
        {
            get { return dateMedService; }
            set { dateMedService = value; }
        }

        public TreatmentRoom TreatmentRoom
        {
            get { return treatmentRoom; }
            set { treatmentRoom = value; }
        }

        public MedProcedure MedProcedure
        {
            get{ return medProcedure; }
            set { medProcedure = value; }
        }

        public override string ToString()
        {
            string strComma = ",";

            StringBuilder sbMedServ = new StringBuilder();
         
            sbMedServ.AppendFormat($"{DateMedService} | ")                
                .AppendFormat($"Treatment room: {treatmentRoom.Id} {treatmentRoom.Name} ")
                .AppendFormat($"Procedure: {medProcedure.Name} Price {MedProcedure.CostServices}")
                .AppendLine();
         
            return sbMedServ.ToString();
        }

    }
}
