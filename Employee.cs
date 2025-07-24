using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПодготовкаНаПрограммиста
{
    public abstract class Employee
    {
        
            private int id;
            private string name;
            private int age;
            private decimal baseSalary;

            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public int Age
            {
                get { return age; }
                set { age = value; }
            }
            public decimal BaseSalary
            {
                get { return baseSalary; }
                set { baseSalary = value; }
            }
            public Employee(string name, int age, decimal baseSalary)
            {
                Name = name;
                Age = age;
                BaseSalary = baseSalary;
            }
            public abstract decimal CalculateSalary();
            public virtual void DisplayInfo()
            {
                Console.WriteLine($"Id: {Id}\nИмя сотрудника: {name}\nВозраст сотрудника: {age}\nЗарплата сотрудника: {baseSalary}");
            }
    }
}
