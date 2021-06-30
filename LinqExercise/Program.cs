using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sum = numbers.Sum();
            var average = numbers.Average();
            //Order numbers in ascending order and decsending order. Print each to console.
            var numUp = numbers.OrderBy(num => num);
            var numDown = numbers.OrderByDescending(num => num);
            foreach(int num in numUp)
			{
                Console.WriteLine(num);
			}
            Console.WriteLine("");
            foreach(int num in numDown)
			{
                Console.WriteLine(num);
			}
            Console.WriteLine("");
            //Print to the console only the numbers greater than 6
            var aboveSix = numbers.Where(num => num > 6);
            foreach(int num in aboveSix)
			{
                Console.WriteLine(num);
			}
            Console.WriteLine("");
            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            foreach (var num in numUp.Take(4))
			{
                Console.WriteLine(num);
			}
            Console.WriteLine("");
            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 36;
            foreach (var num in numbers.OrderByDescending(num => num))
			{
                Console.WriteLine(num);
			}
            Console.WriteLine("");
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var filtered = employees.Where(name => name.FirstName.StartsWith('C') || name.FirstName.StartsWith('S')).OrderBy(name => name.FirstName);

            foreach(var name in filtered)
			{
                Console.WriteLine(name.FullName);
			}
            Console.WriteLine("");
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(name => name.Age > 26).OrderBy(name => name.Age).ThenBy(name => name.FirstName);
            foreach(var name in overTwentySix)
			{
				Console.WriteLine($"{name.FullName}, {name.Age}");
			}
            Console.WriteLine("");
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var experience = employees.Where(name => name.YearsOfExperience <= 10 && name.Age > 35);
            var sumExperience = experience.Sum(name => name.YearsOfExperience);
            var avg = experience.Average(name => name.YearsOfExperience);
            Console.WriteLine($"{sumExperience}, {avg}");
            Console.WriteLine("");

            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("first", "lastName", 54, 2)).ToList(); 

            foreach(var name in employees)
			{
                Console.WriteLine($"{name.FirstName} {name.Age}");
			}
            
            //Console.WriteLine();

            //Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
