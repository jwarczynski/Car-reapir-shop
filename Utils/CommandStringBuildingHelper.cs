﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarsztatSamochodowy.Utils
{
    internal class CommandStringBuildingHelper
    {
        private static string buildNonEqualsPattern(List<string> args, string separator, string bindingCharacter, bool skipFirst)
        {
            StringBuilder patternBuilder = new StringBuilder();
            bool firstItem = true;
            foreach (string arg in args)
            {
                if (firstItem && skipFirst)
                {
                    patternBuilder.Append(bindingCharacter + arg);
                    firstItem= false;
                } else
                {
                    patternBuilder.Append(" ," + bindingCharacter + arg);
                }
            }
            return patternBuilder.ToString();
        }
        public static string buildUpdatePattern(string prefix, List<string> args, bool skipPrefixForFirstItem, char identyfingCharacter) {
            StringBuilder patternBuilder = new StringBuilder();
            bool firstItem = true;
            foreach (var arg in args)
            {
                if (skipPrefixForFirstItem && firstItem)
                {
                    patternBuilder.Append(arg + " =@" + identyfingCharacter + arg);
                    firstItem= false;
                } else
                {
                    patternBuilder.Append(" " + prefix + " " + arg + " =@" + identyfingCharacter + arg);
                }
            }
            return patternBuilder.ToString();
        }
        public static string buildEqualsPattern(string prefix, List<string> args, bool skipPrefixForFirstItem)
        {
            StringBuilder patternBuilder = new StringBuilder();
            bool firstItem = true;
            foreach (var arg in args)
            {
                if (skipPrefixForFirstItem && firstItem)
                {
                    patternBuilder.Append(arg + " =@" + arg);
                    firstItem= false;
                } else
                {
                    patternBuilder.Append(" " + prefix + " " + arg + " =@" + arg);
                }
            }
            return patternBuilder.ToString();
        }
        public static string buildInsertIntoPattern(List<string> args)
        {
            return buildNonEqualsPattern(args, ",", "", true);
        }
        public static string buildInsertValuesPattern(List<string> args) 
        {
            return buildNonEqualsPattern(args, ",", "@", true);
        }
    }
}