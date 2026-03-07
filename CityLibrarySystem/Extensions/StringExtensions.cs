namespace CityLibrarySystem.Extensions
{
    internal static class StringExtensions
    {
        public static string NormalizeID(this string value)
        {
            return value?.Trim().ToUpperInvariant() ?? string.Empty;
        }

        /// <summary>
        /// Checks if a string is a valid email by verifying it contains '@' and '.'.
        /// Example: "ahmed@email.com".IsValidEmail() → true
        /// </summary>
        public static bool IsValidEmail(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            bool hasAt = false;
            bool hasDot = false;

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '@')
                    hasAt = true;
                if (value[i] == '.')
                    hasDot = true;
            }

            return hasAt && hasDot;
        }

        /// <summary>
        /// Checks if a string contains at least one digit character.
        /// Example: "Copy001".ContainsDigit() → true
        /// </summary>
        public static bool ContainsDigit(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsDigit(value[i]))
                    return true;
            }

            return false;
        }
    }
}
