using System.Data;
using System.Drawing;

namespace FortuneTellerApi.Utility
{
    public static class Validator
    {
        public static bool HasData(this DataTable table)
        {
            return table != null && table.Rows != null && table.Rows.Count > 0;
        }
        public static bool HasData<T>(this IEnumerable<T> collection)
        {
            return collection != null && collection.Count() > 0;
        }
        public static bool IsEmptyOrNull<T>(this IEnumerable<T> list)
        {
            return (list?.Count() ?? 0) == 0;
        }
        public static bool HasAny(this DataTable table)
        {
            return table?.Rows?.Count > 0;
        }
        public static bool HasAny<T>(this IEnumerable<T> collection)
        {
            return collection?.Any() ?? false;
        }
        public static bool HasAny<T>(this IEnumerable<T> collection, Func<T, bool> function)
        {
            return collection?.Any(function) ?? false;
        }
        public static void ForEach<T>(this T[] items, Action<T> action)
        {
            var list = items.ToList();
            list.ForEach(action);
        }
        public static bool IsValid(this object obj)
        {
            return obj != null;
        }
        public static bool IsInvalid(this object obj)
        {
            return obj == null;
        }
        public static bool IsValid(this Color color)
        {
            return color != Color.Empty;
        }
        public static bool IsInvalid(this Color color)
        {
            return color == Color.Empty;
        }
        public static bool IsValid(this int digit)
        {
            return digit > 0;
        }
        public static bool IsInvalid(this int digit)
        {
            return !IsValid(digit);
        }
        public static bool IsMinus(this int digit)
        {
            return digit < 0;
        }
        public static bool IsMinus(this double digit)
        {
            return digit < 0;
        }
        public static int Regulate(this int? data)
        {
            return data.HasValue ? data.Value : 0;
        }
        public static int Regulate(this byte? data)
        {
            return data.HasValue ? data.Value : 0;
        }
        public static double Regulate(this double? data)
        {
            return data.HasValue ? data.Value : 0;
        }
        public static bool Regulate(this bool? data)
        {
            return data.HasValue ? data.Value : false;
        }
        public static string Regulate(this string data)
        {
            return data.IsValid() ? data : string.Empty;
        }
        public static bool IsZero(this int data)
        {
            return data == 0;
        }
        public static bool IsZero(this double data)
        {
            return data == 0;
        }
        public static bool IsZero(this decimal data)
        {
            return data == 0;
        }
    }
}
