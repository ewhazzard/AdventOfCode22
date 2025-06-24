using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Reflection;
using System.Linq;

using AdventOfCode24;
using System.Text.RegularExpressions;

public class Day03 {
    private readonly string _inputPath = "/Users/evanhazzard/AdventOfCode2024/AdventOfCode2024/InputFiles/Day03Input.txt";
    private String _input = "";
    public Day03(){
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
        String pattern = @"mul\(\d+,\d+\)";
        Regex rx = new Regex(pattern);
        MatchCollection matchedExpression = rx.Matches(inputText);
        int sum = 0;
        int firstNum = 0;
        int secondNum = 0;
        for(int i = 0; i < matchedExpression.Count; i++){
            firstNum = Int32.Parse(matchedExpression[i].ToString().Split(",")[0].Substring(4));
            secondNum = Int32.Parse(matchedExpression[i].ToString().Split(",")[1].Trim(')'));
            sum += firstNum * secondNum;
        }
        return sum;
    }

    public static int PartTwo(String inputText){
        int sum = 0;
        int firstNum = 0;
        int secondNum = 0;
        bool instructionEnabled = true;
        String pattern = @"mul\(\d+,\d+\)|(do\(\)|don't\(\))";
        Regex rx = new Regex(pattern);
        MatchCollection matchedExpression = rx.Matches(inputText);
        for(int i = 0; i < matchedExpression.Count; i++){
            Console.WriteLine("Match: " + matchedExpression[i]);
            if(matchedExpression[i].ToString().Equals("do()")){
                instructionEnabled = true;
            }
            else if (matchedExpression[i].ToString().Equals("don't()")){
                instructionEnabled = false;
            }
            else if (instructionEnabled) {
                firstNum = Int32.Parse(matchedExpression[i].ToString().Split(",")[0].Substring(4));
                secondNum = Int32.Parse(matchedExpression[i].ToString().Split(",")[1].Trim(')'));
                sum += firstNum * secondNum;
            }
        }
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