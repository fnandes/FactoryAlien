using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryAlienDotNet
{
    public class Randomizer
    {
        public static Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        static DateTime startDate = System.DateTime.Now.AddMonths(-6);

        public static string String()
        {
            var randomCharArray = Enumerable.Repeat(chars, 20)
                                            .Select(s => s[random.Next(s.Length)])
                                            .ToArray();

            return new string(randomCharArray);
        }

        public static int Int()
        {
            return random.Next(1, int.MaxValue);
        }

        public static short Short()
        {
            return (short)random.Next(1, short.MaxValue);
        }

        public static byte Byte()
        {
            return (byte)random.Next(1, byte.MaxValue);
        }

        public static long Long()
        {
            return (long)random.Next(1, int.MaxValue);
        }

        public static object DateTime()
        {
            int range = (System.DateTime.Today - startDate).Days;

            return startDate.AddDays(random.Next(range));
        }

        public static bool Boolean()
        {
            return random.Next(0, 1) == 1;
        }

        public static decimal Decimal()
        {
            int integerPart = Int();
            return (decimal)(integerPart + random.NextDouble());
        }

        public static double Double()
        {
            return random.NextDouble();
        }

        public static float Float()
        {
            double mantissa = (random.NextDouble() * 2.0);
            double exponent = Math.Pow(2.0, random.Next(1, 128));
            return (float)(mantissa * exponent);
        }

        internal static object Enum(Type enumType)
        {
            var enumValues = System.Enum.GetValues(enumType);

            var randomIndex = random.Next(0, enumValues.Length - 1);

            return enumValues.GetValue(randomIndex);
        }
    }
}
