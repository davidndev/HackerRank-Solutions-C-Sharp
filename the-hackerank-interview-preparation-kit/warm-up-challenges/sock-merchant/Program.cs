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

        //This 
    }


    static int sockMerchant_V2(int n, int[] ar) {
        int previousSock;
        int totalPairs;

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
