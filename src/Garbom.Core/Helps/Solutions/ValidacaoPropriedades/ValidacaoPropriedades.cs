using System;
using System.Reflection;

namespace Garbom.Core.Helps.Solutions.ValidacaoPropriedades
{
    public static class ValidacaoPropriedades
    {
        public static string TemPropriedadesValida<T>(string fields)
        {
            if (string.IsNullOrWhiteSpace(fields))
                throw new ArgumentNullException(nameof(ValidacaoPropriedades));

            var fieldsAfterSplit = fields.Split(",");

            foreach (var field in fieldsAfterSplit)
            {
                var propertyName = field.Trim();
                var propertyInfo = typeof(T).GetProperty(propertyName,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (propertyInfo == null)
                    return propertyName;
            }

            return string.Empty;
        }
    }
}
