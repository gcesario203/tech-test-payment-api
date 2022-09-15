using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace implementation.Utils.Helpers
{
    public static class ReflectionHelpers
    {
        public static T? GetValue<T>(object value, string propertyName = null)
        {
            if(value.GetType().IsEnum)
                return (T)value;
            
            if(string.IsNullOrEmpty(propertyName))
                return (T)value.GetType().GetProperties().FirstOrDefault().GetValue(value);

            return (T)value.GetType().GetProperty(propertyName).GetValue(value);
        }
    }
}