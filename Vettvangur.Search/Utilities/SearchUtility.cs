using System;

namespace Vettvangur.Search.Utilities
{
    public static class SearchUtility
    {
        public static string FieldCultureName(this string fieldName, string culture = null)
        {
            return string.IsNullOrEmpty(culture) ? fieldName : fieldName + "_" + culture.ToLowerInvariant();
        }

        internal static bool IsBoolean(this string value)
        {
            if (!string.IsNullOrEmpty(value) && value == "1" || value.Equals("true", StringComparison.InvariantCultureIgnoreCase) || value.Equals("on", StringComparison.InvariantCultureIgnoreCase) || value.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
