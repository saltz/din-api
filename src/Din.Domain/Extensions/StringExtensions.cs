﻿using System;
using System.Linq;

namespace Din.Domain.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        ///     Calculate percentage similarity of two strings
        ///     <param name="source">Source String to Compare with</param>
        ///     <param name="target">Targeted String to Compare</param>
        ///     <returns>Return Similarity between two strings from 0 to 1.0</returns>
        /// </summary>
        public static double CalculateSimilarity(this string source, string target)
        {
            if (string.IsNullOrEmpty(source))
                return string.IsNullOrEmpty(target) ? 1 : 0;

            if (string.IsNullOrEmpty(target))
                return string.IsNullOrEmpty(source) ? 1 : 0;

            double stepsToSame = ComputeLevenshteinDistance(source, target);
            return 1.0 - stepsToSame / Math.Max(source.Length, target.Length);
        }

        public static string GenerateRandomString(this string source, int length)
        {
            var random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        ///     Returns the number of steps required to transform the source string
        ///     into the target string.
        /// </summary>
        private static int ComputeLevenshteinDistance(this string source, string target)
        {
            if (string.IsNullOrEmpty(source))
                return string.IsNullOrEmpty(target) ? 0 : target.Length;

            if (string.IsNullOrEmpty(target))
                return string.IsNullOrEmpty(source) ? 0 : source.Length;

            var sourceLength = source.Length;
            var targetLength = target.Length;

            var distance = new int[sourceLength + 1, targetLength + 1];

            // Step 1
            for (var i = 0; i <= sourceLength; distance[i, 0] = i++)
            {
            }

            for (var j = 0; j <= targetLength; distance[0, j] = j++)
            {
            }

            for (var i = 1; i <= sourceLength; i++)
            for (var j = 1; j <= targetLength; j++)
            {
                // Step 2
                var cost = target[j - 1] == source[i - 1] ? 0 : 1;

                // Step 3
                distance[i, j] = Math.Min(
                    Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                    distance[i - 1, j - 1] + cost);
            }

            return distance[sourceLength, targetLength];
        }
    }
}