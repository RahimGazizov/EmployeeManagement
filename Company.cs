using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ПодготовкаНаПрограммиста
{
    public class Company
    {
        private List<Employee> employees = new List<Employee>();
        private int currentId = 0;
        public void AddEmployee(Employee employee)
        {
            currentId++;
            employee.Id = currentId;
            employees.Add(employee);
            Console.WriteLine("Сотрудник добавлен");
        }
        public void ShowAllEmployees()
        {
            if (employees.Count > 0)
            {
                Console.WriteLine("+----+----------------------+--------+--------------+----------------------------+");
                Console.WriteLine("| ID | Имя                  | Возраст| Зарплата     | Доп. информация            |");
                Console.WriteLine("+----+----------------------+--------+--------------+----------------------------+");

                foreach (var emp in employees)
                {
                    string extraInfo = "";

                    if (emp is Developer dev)
                        extraInfo = $"Строк кода: {dev.LinesOfCodePerDay}";
                    else if (emp is Manager man)
                        extraInfo = $"Команда: {man.TeamSize}";
                    else if (emp is Intern intern)
                        extraInfo = $"Стажировка: {intern.DurationMonths} мес.";

                    decimal salary = emp.CalculateSalary();

                    Console.WriteLine($"| {emp.Id,-2} | {emp.Name,-20} | {emp.Age,-6} | {salary,-12} | {extraInfo,-26} |");
                }

                Console.WriteLine("+----+----------------------+--------+--------------+----------------------------+");
            }
            else
            {
                Console.WriteLine("Список пуст");
            }
        }

        public void ShowTotalSalary()
        {
            if (employees.Count > 0)
            {
                decimal salary = 0;
                foreach (var employee in employees)
                {
                    salary += employee.CalculateSalary();
                }
                Console.WriteLine($"Общая сумма зарплат: {salary}");
            }
            else
                Console.WriteLine("Списко пуст");
        }
        public void DeleteEmployee(string employee)
        {
            int id;
            bool isId = int.TryParse(employee.Trim(), out id);
            Employee employee2;
            if (isId)
            {
                employee2 = employees.FirstOrDefault(x => x.Id == id);
                if (employee2 != null)
                {
                    employees.Remove(employee2);
                    Console.WriteLine("Сотрудник удален");
                }
                else
                    Console.WriteLine("Сотрудник не найден");
            }
            else
            {
                employee2 = employees.FirstOrDefault(x => x.Name.ToLower().Trim() == employee.ToLower().Trim());
                if (employee2 != null)
                {
                    employees.Remove(employee2);
                    Console.WriteLine("Сотрудник удален");
                }
                else
                    Console.WriteLine("Сотрудник не найден");
            }

        }
        public void EditEmployee(int id, string file)
        {
            Employee employee2;
            string name = "";
            int age = 0;
            decimal salary = 0;
            employee2 = employees.FirstOrDefault(x => x.Id == id);
            if (employee2 != null)
            {
                Console.Write("Что вы хотите изменить?\n1 - Имя\n2 - Возраст\n3 - Зарплату\n4 - Доп.данные\n5 - Отмена\n>" + " ");
                while (true)
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            Console.Write("Введите имя\n>" + " ");
                            name = Console.ReadLine();
                            employee2.Name = name;
                            break;
                        case 2:
                            Console.Write("Введите возраст\n>" + " ");
                            age = Convert.ToInt32(Console.ReadLine());
                            employee2.Age = age;
                            break;
                        case 3:
                            Console.Write("Введите зарплату\n>" + " ");
                            salary = Convert.ToDecimal(Console.ReadLine());
                            employee2.BaseSalary = salary;
                            break;
                        case 4:
                            if (employee2 is Developer developer)
                            {
                                Console.Write("Введите количество строк кода\n>" + " ");
                                int code = Convert.ToInt32(Console.ReadLine());
                                developer.LinesOfCodePerDay = code;
                            }
                            else if (employee2 is Manager manager)
                            {
                                Console.Write("Введите количество команд\n>" + " ");
                                int team = Convert.ToInt32(Console.ReadLine());
                                manager.TeamSize = team;
                            }
                            else if (employee2 is Intern intern)
                            {
                                Console.Write("Срок стажировки в месяцах\n>" + " ");
                                int month = Convert.ToInt32(Console.ReadLine());
                                intern.DurationMonths = month;
                            }

                            break;
                        case 5:
                            return;
                    }
                    Console.WriteLine("Сотрудник обновлен");
                    DownloadFile(file);
                }

            }
            else
                Console.WriteLine("Сотрудник не найден");
        }
        public void DownloadFile(string file)
        {
            string json = JsonConvert.SerializeObject(employees, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented,
            });
            File.WriteAllText(file, json);
        }
        public void LoadFile(string file)
        {
            if (File.Exists(file))
            {
                try
                {
                    string json = File.ReadAllText(file);
                    employees.Clear();
                    employees.AddRange(JsonConvert.DeserializeObject<List<Employee>>(json, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    }));
                    if (employees.Count > 0)
                    {
                        currentId = employees.Max(e => e.Id);
                    }
                    else
                        currentId = 0;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Файл пуст");
                }
            }
            else
                Console.WriteLine("Файл не найден");
        }
        public Employee GetEmployeeInfo(int id)
        {
            return employees.FirstOrDefault(x => x.Id == id);
        }
    }
}
