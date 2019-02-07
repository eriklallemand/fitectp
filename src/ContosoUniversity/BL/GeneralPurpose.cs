using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.BL
{
    public static class GeneralPurpose
    {
        public static List<int> IntRange(int minValue,int maxValue)
        {
            List<int> output = new List<int>();
            for(int i=minValue; i<maxValue; i++)
            {
                output.Add(i);
            }
            return output;
        }
    }
}