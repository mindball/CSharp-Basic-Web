﻿namespace SIS.HTTP.DiffApproach.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string str) => char.ToUpper(str[0]) + str.Substring(1);
        
    }
}
