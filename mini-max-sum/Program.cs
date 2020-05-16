using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

//https://www.hackerrank.com/challenges/mini-max-sum/problem

class Solution {

    // Complete the miniMaxSum function below.
    static void miniMaxSum(int[] arr) {

        //Convert Array to IEnumberable so we can use Take()
        var listOfNumbers = arr.OfType<int>();

        //Get the 4 smallest numbers and 4 largest numbers
        var smallNumbers = listOfNumbers.OrderBy(x => x).Take(4);
        var bigNumbers = listOfNumbers.OrderByDescending(x => x).Take(4);
        
        //Get the sums
        long smallOutput = smallNumbers.Sum(x => Convert.ToInt64(x));
        long bigOutput = bigNumbers.Sum(x => Convert.ToInt64(x));

        //Output the result
        Console.WriteLine($"{smallOutput} {bigOutput}");
    }

    static void miniMaxSumV2(int[] arr) {
        long min = 0, max = 0, sum = 0;
        min = arr[0];
        max = min;
        sum = min;

        for(int i = 1; i <arr.Length; i++){
            sum += arr[i];
            if(arr[i] < min){
                min = arr[i];
            }
            if(arr[i] > max){
                max = arr[i];
            }
        }
        
        Console.WriteLine($"{sum - max} {sum - min}");
    }

    static void Main(string[] args) {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

        miniMaxSum(arr);
    }
}
