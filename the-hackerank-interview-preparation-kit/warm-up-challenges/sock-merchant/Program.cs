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

class Solution {

    // Complete the sockMerchant function below.
    // https://www.hackerrank.com/challenges/sock-merchant
    static int sockMerchant(int n, int[] ar) {
        int previousSock = 0;
        int totalPairs = 0;

        //Sort socks
        Array.Sort(ar);
        
        //Count the pairs in each piles
        foreach(int sock in ar){
            if(previousSock == sock){ //Compare the previous sock with the current sock
                totalPairs++; //If they are the same. It is a pair. Update total pairs
            }else{
                previousSock = sock; //If not, set sock to previous sock and move on
            }
        }

        //return total pairs
        return totalPairs;

        //This failed. My output is 5, the correct answer is 3 pairs. So I'm over counting.
        //I think I know the problem. It's counting the odd sock since I'm not clearing out
        //previous sock when I update total pairs. Let's try again, see V2.
    }

    static int sockMerchant_V2(int n, int[] ar) {
        int previousSock = 0;
        int totalPairs = 0;

        //Sort socks
        Array.Sort(ar);
        
        //Count the pairs in each piles
        foreach(int sock in ar){
            if(previousSock == sock){ //Compare the previous sock with the current sock
                totalPairs++; //If they are the same. It is a pair. Update total pairs
                previousSock = 0; // **Once it finds a pair, reset previous sock
            }else{
                previousSock = sock; //If not, set sock to previous sock and move on
            }
        }

        //return total pairs
        return totalPairs;

        // This works! The code actually ends up being simpler than I thought. Also, it's only
        // running through the array once so that should be O(n). Array.Sort() is using QuickSort
        // which is O(n log n) on average. Overall I'm pretty happy with the results.
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp))
        ;
        int result = sockMerchant(n, ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
