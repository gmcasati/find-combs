using System;

namespace FindCombsApi.Commons.Extensions
{
    public static class DateTimeHelper
    {
        public static void SetRange(DateTime startIn, DateTime endIn, out DateTime startOut, out DateTime endOut) 
        {
            if(startIn == DateTime.MinValue && endIn == DateTime.MinValue) 
            {
                startOut = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                endOut = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day);
            } 
            else if(startIn == DateTime.MinValue) 
            {
                startOut = new DateTime(endIn.Year, endIn.Month, endIn.Day);
                endOut = new DateTime(endIn.AddDays(1).Year, endIn.AddDays(1).Month, endIn.AddDays(1).Day);
            }
            else if(endIn == DateTime.MinValue) 
            {
                startOut = new DateTime(startIn.Year, startIn.Month, startIn.Day);
                endOut = new DateTime(startIn.AddDays(1).Year, startIn.AddDays(1).Month, startIn.AddDays(1).Day);
            } 
            else 
            {
                startOut = startIn.ToUniversalTime();
                endOut = endIn.ToUniversalTime();
            }
        }
    }
}
