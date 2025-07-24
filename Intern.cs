using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПодготовкаНаПрограммиста
{
    class Intern : Employee
    {
        private int durationMonths;
        public int DurationMonths
        {
            get { return durationMonths; }
            set { durationMonths = value; }
        }
        public Intern(string name, int age, decimal baseSalary, int durationMonths)
           : base(name, age, baseSalary) { DurationMonths = durationMonths; }
        public override decimal CalculateSalary()
        {
            return durationMonths < 6 ? BaseSalary - (100 * (6 - durationMonths)) : BaseSalary;
        }
    }
}
