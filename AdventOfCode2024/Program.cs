//Advent of Code 2024
//By Evan Hazzard

using System;

namespace AdventOfCode24 {
    public class Program {
        public static void Main(string [] args){
            Console.WriteLine("Specify Day to Get Solution");
            var day = Console.ReadLine();

            switch(day) {
                case "1":
                    var day1 = new Day01();
                    Console.WriteLine(day1.GetResults());
                    break;
                case "2":
                    var day2 = new Day02();
                    Console.WriteLine(day2.GetResults());
                    break;
                case "3":
                    var day3 = new Day03();
                    Console.WriteLine(day3.GetResults());
                    break;
                case "4":
                    var day4 = new Day04();
                    Console.WriteLine(day4.GetResults());
                    break;
                default:
                    Console.WriteLine("Not Found");
                    break;
            }
        }
    }
}

