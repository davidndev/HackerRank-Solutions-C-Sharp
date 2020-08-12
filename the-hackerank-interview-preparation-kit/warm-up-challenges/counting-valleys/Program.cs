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

    // Complete the countingValleys function below.
    static int countingValleys(int n, string s) {
        int garyPostionY = 0;
        bool inAValley = false; //To keep track if Gary
        int totalValleys = 0;

        //I love foreach loops. I'm looping through each char in the string.
        foreach(char step in s)
        { 
            // **Call our new function
            garyPostionY = UpdateGaryPositionY(garyPostionY, step); 

            //Make a note if Gary position is negative
            if(garyPostionY < 0)
            {
                inAValley = true; //Gary is in a valley
            }
            //Make a note if Gary return to sea level surface
            else if (garyPostionY == 0){
                if(inAValley){ // If gary was in a valley
                    totalValleys++; //Update count to reflect Gary been through a valley
                    inAValley = false; // Gary is now on the surface, so turn this to false
                }
            }
            else{
                //We don't care if Gary is in the mountains. Do nothing
            }
        }

        return totalValleys;
    }
    /*
    I see we can break out the code to convert U to +1 and D to -1. So let's do that.
    This function take 2 arguements and will return gary's new position.

    garyCurrentPosition - We need to know Gary current position in order to update it.
    step - We'll also need Gary current step to know whether he is going up or down
    */
    int UpdateGaryPositionY(int garyCurrentPosition, char currentStep){

        if(currentStep == 'U')
        {
            garyCurrentPosition++; // +1 to gary position if it's U
        }
        else if(currentStep == 'D')
        {
            garyCurrentPosition--; // -1 to gary position if it's D
        }
        else 
        {
            //Not an expect input. Do nothing
        }

        return garyCurrentPosition;
    }


    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        int result = countingValleys(n, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
