using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Reflection;
using System.Linq;

namespace AdventOfCode24;
public class Day01{
    // private string _inputPath = Path.Combine("AdventOfCode2024","InputFiles/Day01Input.txt");
    private readonly string _inputPath = "/Users/evanhazzard/AdventOfCode2024/AdventOfCode2024/InputFiles/Day01Input.txt";
    private List<String> _input = new List<String>();
    public Day01(){
        _input = InputReader(_inputPath);
    }

        public string GetResults()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("Day 1 Part 1 Solution: " + PartOne(_input,0).ToString());
        stringBuilder.Append("\nDay 1 Part 2 Solution: " + PartTwo(_input).ToString());

        return stringBuilder.ToString();

    }
    public static int PartOne(List<String> input, int distanceSum) {
        Console.WriteLine("Part 1 Solution: ");
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();
        
        for(var i = 0; i < input.Count; i++){
            leftList.Add(Int32.Parse(input[i].Split("  ")[0]));
            rightList.Add(Int32.Parse(input[i].Split("  ")[1]));
        }

        leftList.Sort();
        rightList.Sort();

        for(var i = 0; i < leftList.Count; i++){
            distanceSum += Math.Abs(leftList[i] - rightList[i]);
        }
        return distanceSum;
    }

    public static int PartTwo(List<String> input){
        Console.WriteLine("Part 1 Solution: ");
        int similarityScore = 0;
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();
        
        for(var i = 0; i < input.Count; i++){
            leftList.Add(Int32.Parse(input[i].Split("  ")[0]));
            rightList.Add(Int32.Parse(input[i].Split("  ")[1]));
        }

        leftList.Sort();
        rightList.Sort();

        for(var i = 0; i < leftList.Count;i++){
            int occurences = rightList.Where(x => x.Equals(leftList[i])).Count();
            similarityScore += leftList[i] * occurences;
        }

        return similarityScore;
    }
    private List<String> InputReader(string inputPath)
    {
        var inputList = new List<String>();
        var fileStream = File.OpenRead(inputPath);
        var streamReader = new StreamReader(fileStream);
        string line;
        while((line = streamReader.ReadLine()) != null)
        {
            inputList.Add(line);
        }
        
        return inputList;
    }
}