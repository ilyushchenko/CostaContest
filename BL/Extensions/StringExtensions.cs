using System;

namespace BL.Extensions
{
    public static class StringExtensions
    {
        internal static string LessOrThrow(this string text, int minLength, string error)
        {
            var clearValue = text.Trim();
            if (clearValue.Length <= minLength)
            {
                throw new Exception(error);
            }
            return clearValue;
        }

        internal static string GreaterOrThrow(this string text, int maxLength, string error)
        {
            var clearValue = text.Trim();
            if (clearValue.Length > maxLength)
            {
                throw new Exception(error);
            }
            return clearValue;
        }
    }
}
