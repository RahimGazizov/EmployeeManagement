using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ПодготовкаНаПрограммиста
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = true;
            Company company = new Company();
            string file = @"C:\Users\Gaziz\OneDrive\Desktop\классы(ООП)\employees.json";

            company.LoadFile(file);
            while (exit)
            {
                Console.Write("Выберите действие\n1 - Добавить сотрудника\n2 - Показать всех сотрудников" +
                    "\n3 - Показать суммарную зарплату\n4 - Удалить сотрудника\n5 - Редоктировать сотрудника" +
                    "\n6 - Вывести информацию по сотруднику\n7 - Выход\n>" + " ");
                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            int id = 0;
                            string name = "";
                            int age = 0;
                            decimal salary = 0;
                            AddEmploee(out name, out age, out salary);
                            Console.Write("\n1 - Добавить разработчика\n2 - Добавить менеджера\n3 - Добавить стажера\n>" + " ");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    int linesOfCode;
                                    while (true)
                                    {
                                        Console.WriteLine("Введите количество строк кода");
                                        if (int.TryParse(Console.ReadLine(), out linesOfCode))
                                        {
                                            Developer developer = new Developer(name, age, salary, linesOfCode);
                                            company.AddEmployee(developer);
                                            company.DownloadFile(file);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Введите число");
                                            Console.ReadKey();
                                        }
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "2":
                                    Console.WriteLine("Введите размер команды");
                                    int teamSize = Convert.ToInt32(Console.ReadLine());
                                    Manager manager = new Manager(name, age, salary, teamSize);
                                    company.AddEmployee(manager);
                                    company.DownloadFile(file);
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "3":
                                    Console.WriteLine("Срок стажировки в месяцах");
                                    int durationMonth = Convert.ToInt32(Console.ReadLine());
                                    Intern intern = new Intern(name, age, salary, durationMonth);
                                    company.AddEmployee(intern);
                                    company.DownloadFile(file);
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                default:
                                    Console.WriteLine("Введите число от 1 до 3");
                                    return;
                            }
                            break;
                        case 2:
                            company.ShowAllEmployees();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            company.ShowTotalSalary();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 4:
                            while (true)
                            {
                                Console.WriteLine("Введите имя сотрудника или айди");
                                string employee = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(employee))
                                {
                                    company.DeleteEmployee(employee);
                                    break;
                                }
                                else
                                    Console.WriteLine("Вы не вели данные");
                            }

                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 5:
                            while (true)
                            {
                                Console.WriteLine("Введите айди");
                                if (int.TryParse(Console.ReadLine(), out id))
                                {
                                    if (id > 0)
                                    {
                                        company.EditEmployee(id, file);
                                        break;
                                    }
                                    else
                                        Console.WriteLine("Введите айди больше 0");
                                }
                                else
                                    Console.WriteLine("Айди должно быть числом");
                            }

                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 6:
                            Console.WriteLine("Введите айди сотрудника");
                            id = Convert.ToInt32(Console.ReadLine());
                            var emloyee = company.GetEmployeeInfo(id);
                            if(emloyee != null)
                                Console.WriteLine($"Имя сотрудника: {emloyee.Name}\nВозраст: {emloyee.Age}\nЗарплата: {emloyee.BaseSalary}");
                            else
                                Console.WriteLine("Сотрудник не найден");
                            Console.ReadKey();
                            Console.Clear();

                            break;
                        case 7:
                            exit = false;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите число от 1 до 4");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        static void AddEmploee(out string name, out int age, out decimal salary)
        {
            Console.Write("Введите имя\n>" + " ");
            name = Console.ReadLine();
            while (true)
            {
                Console.Write("Введите возраст\n>" + " ");
                string Age = Console.ReadLine();
                Console.Write("Введите зарплату\n>" + " ");
                string Salary = Console.ReadLine();
                bool isAgeValid = int.TryParse(Age, out age);
                bool isSalaryValid = decimal.TryParse(Salary, out salary);
                if (isAgeValid && isSalaryValid) { break; }
                else
                {
                    if (!isAgeValid)
                        Console.WriteLine("Возраст должен быть числом");
                    if (!isSalaryValid)
                        Console.WriteLine("Зарплата должна быть числом");
                }
                Console.ReadKey();
            }
        }
    }
}