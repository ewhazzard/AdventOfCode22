using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Reflection;
using System.Linq;

using AdventOfCode24;
using System.Text.RegularExpressions;

public class Day04 {
    private readonly string _inputPath = "/Users/evanhazzard/AdventOfCode2024/AdventOfCode2024/InputFiles/Day04Input.txt";
    private String _input = "";
    public Day04(){
        _input = InputReader(_inputPath);
    }

    public string GetResults()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("Day 1 Part 1 Solution: " + PartOne(_input));
        stringBuilder.Append("\nDay 1 Part 2 Solution: " + PartTwo(_input));
        return stringBuilder.ToString();

    }

    public static int PartOne(String inputText){
        int NumberOfXmasFound = 0;
        Console.WriteLine(inputText);
        return sum;
    }

    public static int PartTwo(String inputText){
        int sum = 0;
        return sum;
    }

    private String InputReader(string inputPath) {
        var fileStream = File.OpenRead(inputPath);
        var streamReader = new StreamReader(fileStream);
        string line;
        string outputString = "";
        while((line = streamReader.ReadLine()) != null)
        {
            outputString += line;
        }
        
        return outputString;
    }

}