using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПодготовкаНаПрограммиста
{
    public class Developer : Employee
    {
        private int linesOfCodePerDay;
        public int LinesOfCodePerDay
        {
            get { return linesOfCodePerDay; }
            set { linesOfCodePerDay = value; }
        }
        public Developer(string name, int age, decimal baseSalary, int linesOfCodePerDay)
            : base(name, age, baseSalary) { LinesOfCodePerDay = linesOfCodePerDay; }
        public override decimal CalculateSalary()
        {
            return BaseSalary + LinesOfCodePerDay * 0.1m;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Написано строк кода: {linesOfCodePerDay}");
        }
    }
}
