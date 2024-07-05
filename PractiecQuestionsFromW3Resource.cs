using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LINQ
{
    internal class PractiecQuestionsFromW3Resource
    {
        //question which are solved are from here: https://www.w3resource.com/csharp-exercises/linq/index.php
        private void DisplayList(List<int> obj)
        {
            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
        }
        private void Questin1()
        {
            //Write a program in C# Sharp to show how the three parts of a query operation execute.
            //Expected Output:
            //The numbers which produce the remainder 0 after divided by 2 are:
            //0 2 4 6 8
            int[] n1 = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
            var output = (from n in n1
                          where n % 2 == 0
                          select n).ToList();
            this.DisplayList(output);
        }
        private void Questin2()
        {
            //Write a program in C# Sharp to find the +ve numbers from a list of numbers using two where conditions in LINQ Query.
            //Expected Output:
            //The numbers within the range of 1 to 11 are :
            //1 3 6 9 10
            int[] n1 = [1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14];
            var output = (from n in n1
                          where n > 0
                          where n < 12
                          select n).ToList();
            this.DisplayList(output);
        }
        private void Questin3()
        {
            //Write a program in C# Sharp to find the number of an array and the square of each number.
            //Expected Output:
            //{ Number = 9, SqrNo = 81 }
            //{ Number = 8, SqrNo = 64 }
            //{ Number = 6, SqrNo = 36 }
            //{ Number = 5, SqrNo = 25 }
            int[] arr1 = [3, 9, 2, 8, 6, 5];
            var output = from n in arr1
                         let square = n * n
                         where square > 20
                         select new { Number = n, SquareOfNumber = square };
            foreach (var item in output)
            {
                Console.WriteLine($"Number: {item.Number}, SquareOfNumber : {item.SquareOfNumber}");
            }
        }
        private void Questin4()
        {
            //Write a program in C# Sharp to display the number and frequency of a given number from an array.
            //Expected Output :
            //The number and the Frequency are :
            //Number 5 appears 3 times
            //Number 9 appears 2 times
            //Number 1 appears 1 times
            //. . . .
            int[] arr1 = [5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2];
            var output = arr1.GroupBy(number => number).Select(group => new { Number = group.Key, Frequency = group.Count() });
            foreach (var item in output)
            {
                Console.WriteLine($"Number: {item.Number}, SquareOfNumber : {item.Frequency}");
            }
        }
        private void Questin5()
        {
            //Write a program in C# Sharp to display the characters and frequency of each character in a given string.
            //Test Data:
            //Input the string: apple
            //Expected Output:
            //The frequency of the characters are :
            //Character a: 1 times
            //Character p: 2 times
            //Character l: 1 times
            //Character e: 1 times
            Console.Write("Entr a string:");
            string? inputstring = Console.ReadLine() ?? "";
            var output = inputstring.ToArray()
                                    .GroupBy(myChar => myChar)
                                    .Select(characterGroup => new { Character = characterGroup.Key, Frequency = characterGroup.Count() });
            foreach (var item in output)
            {
                Console.WriteLine($"Number: {item.Character}, SquareOfNumber : {item.Frequency}");
            }
        }
        private void Questin7()
        {
            //Write a program in C# Sharp to display numbers, multiplication of numbers with frequency and the frequency of a number in an array.
            //Test Data:
            //The numbers in the array are:
            //5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2
            //Expected Output :
            //Number Number*Frequency Frequency
            //------------------------------------------------
            //5 15 3
            //1 1 1
            //9 9 1
            //2 4 2
            //. . . . . . . .
            int[] arr1 = [5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2];
            var output = arr1.GroupBy(number => number).Select(group => new { Number = group.Key, Frequency = group.Count(), NumberFrequencyProduct = group.Key * group.Count() });
            foreach (var item in output)
            {
                Console.WriteLine($"Number: {item.Number}, SquareOfNumber : {item.Frequency}, NumberFrequencyProduct :{item.NumberFrequencyProduct}");
            }
        }
        public void Question8()
        {
            //Write a program in C# Sharp to find a string that starts and ends with a specific character.
            //Test Data:
            //The cities are: 'ROME','LONDON','NAIROBI','CALIFORNIA','ZURICH','NEW DELHI','AMSTERDAM','ABU DHABI','PARIS'
            //Input starting character for the string : N
            //Input ending character for the string : I
            //Expected Output :
            //The city starting with A and ending with M is : AMSTERDAM
            List<string> cityNames = ["ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS"];
            char startingChar = 'N';
            char endingChar = 'I';
            var outpout = cityNames.Where(city => city.StartsWith(startingChar) && city.EndsWith(endingChar)).ToList();
            outpout.ForEach(city => Console.WriteLine(city));
        }
        public void Question11()
        {
            //Write a program in C# Sharp to display the top n-th records.
            //Test Data:
            //The members of the list are :
            // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            //7
            //How many records you want to display ? : 3
            //Expected Output :
            //The top 3 records from the list are:
            //0, 1, 2
            int[] n1 = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
            var output = n1.Take(3).ToList();
            output.ForEach(number => Console.WriteLine(number));
        }
        public void Question17()
        {
            //Write a program in C# Sharp to remove items from list using remove function by passing the object.
            //Test Data:
            //Here is the list of items :
            //Char: m
            //Char: n
            //Char: o
            //Char: p
            //Char: q
            //Expected Output:
            //Here is the list after removing the item 'o' from the list :
            //Char: m
            //Char: n
            //Char: p
            //Char: q
            List<char> myList = ['m', 'n', 'o', 'p', 'q'];
            char characterToRemove = 'o';
            myList.Remove(characterToRemove);
            myList.ForEach(character => Console.WriteLine(character));
        }
        //___________________________________________________________________________________________
        //_______________________________________Joins_______________________________________________
        //___________________________________________________________________________________________
        // Creating a list of Item_mast objects with ItemId and ItemDes properties
        private readonly static List<Item_mast> itemlist =
               [
               new () { ItemId = 1, ItemDes = "Biscuit  " },
                new () { ItemId = 2, ItemDes = "Chocolate" },
                new () { ItemId = 3, ItemDes = "Butter   " },
                new () { ItemId = 4, ItemDes = "Brade    " },
                new () { ItemId = 5, ItemDes = "Honey    " }
               ];

        // Creating a list of Purchase objects with InvNo, ItemId, and PurQty properties
        private readonly static List<Purchase> purchlist =
            [
                new () { InvNo=100, ItemId = 3,  PurQty = 800 },
                    new () { InvNo=101, ItemId = 2,  PurQty = 650 },
                    new () { InvNo=102, ItemId = 3,  PurQty = 900 },
                    new () { InvNo=103, ItemId = 4,  PurQty = 700 },
                    new () { InvNo=104, ItemId = 3,  PurQty = 900 },
                    new () { InvNo=105, ItemId = 4,  PurQty = 650 },
                    new () { InvNo=106, ItemId = 1,  PurQty = 458 }
            ];
        public void Questin25()
        {
            //Write a program in C# Sharp to generate an Inner Join between two data sets.


            var output1 = (from item in itemlist
                           join purchase in purchlist on item.ItemId equals purchase.ItemId
                           select new
                           {
                               ItemId = item.ItemId,
                               ItemName = item.ItemDes,
                               Invoice = purchase.InvNo,
                               PurchaseQuantity = purchase.PurQty,
                           }).ToList();
            foreach (var item in output1)
            {
                Console.WriteLine($"{item.ItemId} {item.ItemName} {item.Invoice} {item.PurchaseQuantity}");
            }
            //var output2 = output1.GroupBy(item => item.ItemId).ToList();
            //foreach (var item in output2)
            //{
            //    foreach (var innerItem in item)
            //    {
            //        Console.WriteLine($"{innerItem} {innerItem.ItemName} {innerItem.Invoice} {innerItem.PurchasaeQuantity}");
            //    }
            //    Console.WriteLine("_____________________________________");
            //}
        }

        public void Questin26()
        {
            //Write a program in C# Sharp to generate a Left Join between two data sets.
            var outpout = (from item in itemlist
                           join purchase in purchlist
                           on item.ItemId equals purchase.ItemId into outputData
                           from data in outputData.DefaultIfEmpty()
                           select new
                           {
                               ItemId = item.ItemId,
                               ItemName = item.ItemDes,
                               Invoice = data != null ? data.InvNo.ToString() : "NA",
                               PurchasaeQuantity = data != null ? data.PurQty.ToString() : "NA",
                           }).ToList();
            foreach (var item in outpout)
            {
                Console.WriteLine($"{item.ItemId} {item.ItemName} {item.Invoice} {item.PurchasaeQuantity}");
            }
        }
        public void Questin27()
        {
            //Write a program in C# Sharp to generate a Right Outer Join between two data sets.
            var outpout = (from purchase in purchlist
                           join item in itemlist
                           on purchase.ItemId equals item.ItemId into outputData
                           from data in outputData.DefaultIfEmpty()
                           select new
                           {
                               ItemId = data != null ? data.ItemId.ToString() : "NA",
                               ItemName = data != null ? data.ItemDes : "NA",
                               Invoice = purchase.InvNo.ToString(),
                               PurchaseQuantity = purchase.PurQty.ToString()
                           }).OrderBy(item => item.ItemId);
            foreach (var item in outpout)
            {
                Console.WriteLine($"{item.ItemId} {item.ItemName} {item.Invoice} {item.PurchaseQuantity}");
            }
        }
        public void Test()
        {
            //this.Questin1();
            //this.Questin2();            
            //this.Questin3();
            //this.Questin4();
            //this.Questin5();
            //this.Questin7();
            //this.Question8();
            //this.Question11();
            //this.Question17();
            ////joins
            //this.Questin25();
            //this.Questin26();
            //this.Questin27();
        }
    }
}
