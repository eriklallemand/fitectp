using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.BL
{
    //static class for providing general-purpose static methods
    public static class GeneralPurpose
    {
        //returns a List containing all integers between minValue (included) and maxValue (included)
        public static List<int> IntRange(int minValue,int maxValue)
        {
            List<int> output = new List<int>();
            for(int i=minValue; i<=maxValue; i++)
            {
                output.Add(i);
            }
            return output;
        }
    }
}