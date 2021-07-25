using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace july_2021.Util
{
    class DataGenerator
    {
        static string a1 = "abcdefghijklmnoprstuvwxyz";
        static string a2 = "ABCDEFGHIJKLMNOPRSTUVWXYZ";
        static string num = "0123456789";
        public static string Randomstring(int len = 10)
        {
            return TestContext.CurrentContext.Random.GetString(len, $"{a1}{a2}");
        }
        public static string RandomstringInt(int len = 10)
        {
            return TestContext.CurrentContext.Random.GetString(len, $"{num}");
        }
        public static string FullName =  Faker.Name.FullName();
        }
    }


