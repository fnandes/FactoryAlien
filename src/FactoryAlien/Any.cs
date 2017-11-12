﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryAlienDotNet
{
    /// <summary>
    /// Generates any random value.
    /// </summary>
    /// <example>
    /// string myString = Any.String(length: 20);
    /// </example>
    public class Any
    {
        public static Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        static DateTime startDate = System.DateTime.Now.AddMonths(-6);

        /// <summary>
        /// Generates a random string.
        /// </summary>
        /// <param name="length">Generated string length.</param>
        public static string String(int length = 20)
        {
            var randomCharArray = Enumerable.Repeat(chars, 20)
                                            .Select(s => s[random.Next(s.Length)])
                                            .ToArray();

            return new string(randomCharArray);
        }

        /// <summary>
        /// Generates a random integer (Int32) number.
        /// </summary>
        /// <param name="minValue">Minimum value to generate the number.</param>
        /// <param name="maxValue">Maximum value to generate the number.</param>
        public static int Int(int minValue = 1, int maxValue = int.MaxValue)
        {
            return random.Next(minValue, maxValue);
        }

        /// <summary>
        /// Generates a random short (Int16) number.
        /// </summary>
        /// <param name="minValue">Minimum value to generate the number.</param>
        /// <param name="maxValue">Maximum value to generate the number.</param>
        public static short Short(short minValue = 1, short maxValue = short.MaxValue)
        {
            return (short)random.Next(minValue, maxValue);
        }

        /// <summary>
        /// Generates a random byte from 1 to 255.
        /// </summary>
        /// <param name="minValue">Minimum value to generate the byte.</param>
        /// <param name="maxValue">Maximum value to generate the byte.</param>
        public static byte Byte(byte minValue = 0, byte maxValue = byte.MaxValue)
        {
            return (byte)random.Next(minValue, maxValue);
        }

        /// <summary>
        /// Generates a random long (Int64) number.
        /// </summary>
        /// <param name="minValue">Minimum value to generate the number.</param>
        /// <param name="maxValue">Maximum value to generate the number.</param>
        public static long Long(long minValue = 0, long maxValue = long.MaxValue)
        {
            long result = random.Next((int)(minValue >> 32), (int)(maxValue >> 32));
            result = (result << 32);
            return result = result | (long)random.Next((int)minValue, (int)maxValue);
        }

        /// <summary>
        /// Generates a random datetime between six months ago and today.
        /// </summary>
        public static DateTime DateTime()
        {
            int range = (System.DateTime.Today - startDate).Days;

            return startDate.AddDays(random.Next(range));
        }

        /// <summary>
        /// Generates a random datetime between startDate and finalDate.
        /// </summary>
        public static DateTime DateTime(DateTime startDate, DateTime finalDate)
        {
            int range = (finalDate - startDate).Days;

            return startDate.AddDays(random.Next(range));
        }

        /// <summary>
        /// Generates a random boolean value.
        /// </summary>
        public static bool Boolean()
        {
            return random.Next(0, 1) == 1;
        }

        /// <summary>
        /// Generates a random decimal number.
        /// </summary>
        public static decimal Decimal(decimal minValue = 1, decimal maxValue = decimal.MaxValue)
        {
            return (decimal)random.NextDouble() * (maxValue - minValue) + minValue;
        }

        /// <summary>
        /// Generates a random double-precision floating-point number.
        /// </summary>
        public static double Double(double minValue = 1, double maxValue = double.MaxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }

        /// <summary>
        /// Generates a random single-precision floating-point number.
        /// </summary>
        /// <returns></returns>
        public static float Float(float minValue = 1, float maxValue = float.MaxValue)
        {
            return (float) (random.NextDouble() * (maxValue - minValue) + minValue);
        }

        /// <summary>
        /// Generates a random value from the enum.
        /// </summary>
        /// <param name="enumType">Enum type to gets a random value.</param>
        public static object Enum(Type enumType)
        {
            var enumValues = System.Enum.GetValues(enumType);

            var randomIndex = random.Next(0, enumValues.Length - 1);

            return enumValues.GetValue(randomIndex);
        }
    }
}
