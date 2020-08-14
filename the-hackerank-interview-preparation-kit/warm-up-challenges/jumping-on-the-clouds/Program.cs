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

    // Complete the jumpingOnClouds function below.
    static int jumpingOnClouds(int[] c) {
        int numOfClouds = c.Length - 1; // -1 to match 0 index for array
        int totalJumps = 0;

        for(int i = 0; i < numOfClouds; i++){
            var lookAheadIndex = SetLookAheadIndex(i, numOfClouds);

            if(c[lookAheadIndex] == 0){
                i++;
                totalJumps++;
            }else{
                totalJumps++;
            }
        }
        return totalJumps;
    }

/* 
Implement a function that only allows us to jump ahead if 
there are clouds to jump ahead to.
*/
    static int SetLookAheadIndex(int currentIndex, int arrayLength){
        int cloudsLeft = arrayLength - currentIndex;
        if(cloudsLeft >= 2){
            return currentIndex + 2;
        }else if (cloudsLeft == 1){
            return currentIndex + 1;
        }else{
            return currentIndex;
        }
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int result = jumpingOnClouds(c);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
