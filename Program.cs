using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

            IEnumerable<string> LFruits = from fruit in fruits 
                where fruit[0] == 'L' 
                select fruit;
            Console.WriteLine(string.Join(" ", LFruits));

            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> fourSixMultiples =  from num in numbers
                where num % 6 == 0 || num % 4 == 0
                select num;
            Console.WriteLine(string.Join(" ", fourSixMultiples));

            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre" 
            };

            IEnumerable<string> descend = from name in names   
                orderby name descending
                select name;
            Console.WriteLine(string.Join(", ", descend));

            // Build a collection of these numbers sorted in ascending order
            List<int> numbers2 = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> ascend = from num in numbers2 
                orderby num ascending
                select num;
            Console.WriteLine(string.Join(", ", ascend));

            // Output how many numbers are in this list
            List<int> numbers3 = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            Console.WriteLine(numbers3.Count() + " numbers in numbers3");

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
            Console.WriteLine($"We made {purchases.Sum()}");

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };
            Console.WriteLine($"Max price is {prices.Max()}");

            /*
                Store each number in the following List until a perfect square
                is detected.

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };
            IEnumerable<int> squares = from num in wheresSquaredo
                where Math.Sqrt(num) % 1 == 0
                select num;
            Console.WriteLine(string.Join(", ", squares));

            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };
             // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };
            
            var bankCounts = from c in customers
                where c.Balance >= 1000000
                group c.Name by c.Bank into g
                select new {Cust = g, Bank = g.Key};

            foreach (var g in bankCounts) 
            { 
                Console.WriteLine($"Bank {g.Bank} has {g.Cust.Count()} millionaires"); 
                Console.WriteLine(string.Join(", ", g.Cust));
            }
            
            var grouped = customers.Where(c => c.Balance >= 1000000)
                                .GroupBy(d => d.Bank);
            foreach(var potato in grouped) {
                Console.WriteLine($"{potato.Key} {potato.Count()}");
            }

            var millionaireReport = from c in customers
                where c.Balance >= 1000000
                orderby c.Name[c.Name.IndexOf(" ") + 1] ascending
                join b in banks on c.Bank equals b.Symbol
                select new {Bank = b.Name, Name = c.Name};

            foreach (var customer in millionaireReport)
            {
                Console.WriteLine($"{customer.Name} at {customer.Bank}");
            }
        }
    }
}

// Build a collection of customers who are millionaires
public class Customer
{
    public string Name { get; set; }
    public double Balance { get; set; }
    public string Bank { get; set; }
}
public class Bank
{
    public string Symbol { get; set; }
    public string Name { get; set; }
}