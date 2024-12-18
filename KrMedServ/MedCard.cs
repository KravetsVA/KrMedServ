using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrMedServ
{
    // Medical card
    internal class MedCard
    {
        private Guest guest;
        private List<MedProcedure> listMedProcedures; // plan
        private List<MedService> listMedServices; // fact
        private double totalCostServices;

        public MedCard(Guest guest)
        {
            this.guest = guest;
            this.listMedProcedures = new List<MedProcedure>();
            this.listMedServices = new List<MedService>();
            this.totalCostServices = 0;
        }

        public MedCard(Guest guest, List<MedProcedure> listMedProcedures, List<MedService> listMedServices)
        {
            this.guest = guest;
            this.listMedProcedures = listMedProcedures;
            this.listMedServices = listMedServices;
            this.totalCostServices = 0;
        }

        public Guest Guest
        {
            get { return guest; }
            set { guest = value; }
        }

        public List<MedProcedure> ListMedProcedures
        {
            get { return listMedProcedures; }
            set { listMedProcedures = value; }
        }

        public List<MedService> ListMedServices
        {
            get { return listMedServices; }
            set { listMedServices = value; }
        }

        public double TotalCostServices
        {
            get 
            {
                double _costServ = 0;
                foreach (MedService medService in listMedServices)
                {
                    _costServ += medService.MedProcedure.CostServices;                    
                }
                return _costServ; 
            }
            //set { totalCostServices = value; } // read only
        }

        public override string ToString()
        {
            string strComma = ",";

            StringBuilder sbMedServ = new StringBuilder();

            sbMedServ.AppendFormat("----------------------------------------------------------------------------")
                .AppendLine()
                .AppendFormat($"Med Card: {Guest.FirstName} {Guest.LastName}")
                .AppendLine()
                .AppendFormat("----------------------------------------------------------------------------")
                .AppendLine();

            foreach (MedService medServ in ListMedServices)
            {
                sbMedServ.AppendFormat(medServ.ToString());
            }
            
            sbMedServ.AppendFormat($"Total price: {TotalCostServices}")
                .AppendLine();

            return sbMedServ.ToString();

        }


    }
}
