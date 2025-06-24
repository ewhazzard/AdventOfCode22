using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Reflection;
using System.Linq;

using AdventOfCode24;

public class Day02{

    private readonly string _inputPath = "/Users/evanhazzard/AdventOfCode2024/AdventOfCode2024/InputFiles/Day02Input.txt";
    private List<String> _input = new List<String>();
    public Day02(){
        _input = InputReader(_inputPath);
    }

     public string GetResults()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("Day 1 Part 1 Solution: " + PartOne(_input));
        stringBuilder.Append("\nDay 1 Part 2 Solution: " + PartTwo(_input));

        return stringBuilder.ToString();

    }

    public static int PartOne(List<String> inputReports){
        int safeReports = 0;
        for(int i = 0; i < inputReports.Count; i++){
            if (isReportSafePartOne(inputReports[i])){
                Console.WriteLine("Safe report: " + inputReports[i]);
                safeReports++;
            } else {
                Console.WriteLine("Unsafe report: " + inputReports[i]);
            }

        }
        return safeReports;
    }

    public static int PartTwo(List<String> inputReports){
        int safeReports = 0;
        for(int i = 0; i < inputReports.Count; i++){
            if (isReportSafePartTwo(inputReports[i])){
                // Console.WriteLine("Safe report: " + inputReports[i]);
                safeReports++;
            } else {
                Console.WriteLine("Unsafe report: " + inputReports[i]);
            }
        }
        return safeReports;
    }

    public static bool isReportSafePartOne(String report){
        List<int> reportList = report.Split().Select(c => Convert.ToInt32(c)).ToList();
        bool reportIsSafe = true;
        bool isAscending = reportList[0] - reportList[1] < 0;
        int i = 0;
        while(i < reportList.Count - 1 & reportIsSafe){
            int levelDistance = reportList[i] - reportList[i+1];
            if (((reportList[i] < reportList[i+1] & isAscending)|(reportList[i] > reportList[i+1] & !isAscending)) & Math.Abs(reportList[i] - reportList[i+1]) <= 3 & Math.Abs(reportList[i] - reportList[i+1]) != 0){
                
            }
            else {
                reportIsSafe = false;
                Console.WriteLine("Unsafe condition " + reportList[i] + reportList[i + 1]);
            }
            i++;
        }
        return reportIsSafe;
    }

    public static bool isReportSafePartTwo(String report){
        List<int> reportList = report.Split().Select(c => Convert.ToInt32(c)).ToList();
        bool reportIsSafe = true;
        bool isSecondAttempt = false;
        bool isAscending = reportList[0] - reportList[1] < 0;
        if (reportList[0] == reportList[1]){
            isAscending = reportList[0] - reportList[2] < 0;
        }
        int i = 0;
        while(i < reportList.Count - 2 & reportIsSafe){
            int levelDistance = reportList[i] - reportList[i+1];
            if ((levelDistance <= 3 & levelDistance >= 1 & !isAscending) | (levelDistance >= -3 & levelDistance <= -1 & isAscending)) {
                
            }
            else if (isSecondAttempt){
                Console.WriteLine("Another unsafe condition found. Aborting");
                return false;
            }
            else {
                Console.WriteLine("Unsafe condition: " + reportList[i] + " " + reportList[i + 1]);
                isSecondAttempt = true;
                // List<int> tempReportList = reportList;
                // tempReportList.RemoveAt(i);
                // string refinedListString = String.Join(" ", tempReportList);
                // bool isRefinedListSafe = isReportSafePartOne(refinedListString);
                // if (isRefinedListSafe){
                //     Console.WriteLine("Removing object at i made the list safe!");
                // }
                // else {
                //     tempReportList = reportList;
                //     tempReportList.RemoveAt(i + 1);
                //     refinedListString = String.Join(" ", reportList);
                //     return isReportSafePartOne(refinedListString);
                // }
                if (i >= reportList.Count - 2){
                    Console.WriteLine("We are at the end of the list, removing the second number");
                    reportList.RemoveAt(i+1);
                    return true;
                }                
                else if (i == 0){
                    Console.WriteLine("We are at the start of the list, removing the first number");
                    reportList.RemoveAt(i);
                }
                //Remove whatever is at i + 1
                else if ((reportList[i] - reportList[i + 2] <= 3 & reportList[i] - reportList[i + 2] >= 1 & !isAscending) | (reportList[i] - reportList[i + 2] >= -3 & reportList[i] - reportList[i + 2] <= -1 & isAscending)){
                    Console.WriteLine("Removing " + reportList[i+1] + " resolved the unsafe report!");
                    reportList.RemoveAt(i+1);
                }
                //Remove whatever is at I
                else if ((reportList[i-1] - reportList[i + 1] <= 3 & reportList[i-1] - reportList[i + 1] >= 1 & !isAscending) | (reportList[i-1] - reportList[i + 1] >= -3 & reportList[i-1] - reportList[i + 1] <= -1 & isAscending)){
                    Console.WriteLine("Removing " + reportList[i] + " resolved the unsafe report!");
                    reportList.RemoveAt(i);
                }
                else {
                    return false;
                }
            }
            i++;
        }
       return reportIsSafe;
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