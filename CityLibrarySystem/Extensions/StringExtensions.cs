namespace CityLibrarySystem.Extensions
{
    internal static class StringExtensions
    {
        public static string NormalizeID(this string value)
        {
            return value?.Trim().ToUpperInvariant() ?? string.Empty;
        }
    }
}
