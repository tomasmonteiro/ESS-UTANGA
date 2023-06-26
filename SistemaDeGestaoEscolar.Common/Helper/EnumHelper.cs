using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SistemaDeGestaoEscolar.Common
{
    public static class EnumHelper
    {
        public static Dictionary<int, string> GetEnumValues<T>() where T : Enum
        {
            var ordens = new Dictionary<int, string>();

            ((T[])Enum.GetValues(typeof(T))).ToList().ForEach(valor => ordens.Add(Convert.ToInt32(valor), GetEnumDescription(valor)));

            return ordens;
        }

        public static string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[]);

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}