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
                default:
                    Console.WriteLine("Not Found");
                    break;
            }
        }
    }
}

