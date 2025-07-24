using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПодготовкаНаПрограммиста
{
    public class Manager : Employee
    {
        private int teamSize;
        public int TeamSize
        {
            get { return teamSize; }
            set { teamSize = value; }
        }
        public Manager(string name, int age, decimal baseSalary, int teamSize)
            : base(name, age, baseSalary) { TeamSize = teamSize; }

        public override decimal CalculateSalary()
        {
            return BaseSalary + TeamSize * 50;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Размер команды: {teamSize}");
        }
    }
}