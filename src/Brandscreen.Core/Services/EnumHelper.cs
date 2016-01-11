using System;

namespace Brandscreen.Core.Services
{
    public class EnumHelper
    {
        public static bool HasStringEnum<T>(string value) where T : struct, IConvertible
        {
            if (!typeof (T).IsEnum || string.IsNullOrEmpty(value)) return false;
            T result;
            return Enum.TryParse(value, true, out result);
        }

        public static bool AssertStringEnum<T>(string value, T expectedValue) where T : struct, IConvertible
        {
            if (!typeof (T).IsEnum || string.IsNullOrEmpty(value)) return false;
            T result;
            return Enum.TryParse(value, true, out result) && result.Equals(expectedValue);
        }

        public static T Parse<T>(string value) where T : struct, IConvertible
        {
            T result;
            if (Enum.TryParse(value, true, out result)) return result;
            throw new NotSupportedException($"cannot parse {value} to enum type {typeof (T).Name}");
        }
    }
}