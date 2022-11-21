using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDMS_WebApp1._0.Utilities
{
    public class AddShiftModel
    {
        public string Date { get; set; }
        public string Shift { get; set; }
        public string Crew { get; set; }

        public string ShiftTechnician { get; set; }
        public string T2Technician { get; set; }
        public string ContractStaff1 { get; set; }
        public string ContractStaff2 { get; set; }
        public string ContractStaff3 { get; set; }

        public string Physicist1 { get; set; }
        public string Physicist1Notes { get; set; }
        public string Physicist2 { get; set; }
        public string Physicist2Notes { get; set; }

        public string PhysicistRSD { get; set; }
    }
}