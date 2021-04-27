using GitTracker.Domain.Contracts.Infrastructure;
using System.Reflection;
using System.Threading.Tasks;

namespace GitTracker.Infrastructure.Helpers
{
    public class EndPointParser : IEndPointParser
    {
        public async Task<string> ParseEndpoint(object values, string endPoint, string parentTypeName = "")
        {
            var objectType = values.GetType();
            PropertyInfo[] properties = objectType.GetProperties();

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(values, null);

                if (property.PropertyType.Assembly == objectType.Assembly)
                    endPoint = await ParseEndpoint(propertyValue, endPoint, property.Name);
                else
                {
                    var propertyName = GetPropertyName(property, parentTypeName);
                    var value = propertyValue?.ToString();

                    endPoint = endPoint.Replace(propertyName, value ?? string.Empty);
                }
            }

            return endPoint;
        }

        private static string GetPropertyName(PropertyInfo propertyInfo, string parentTypeName = "")
        {
            return string.IsNullOrWhiteSpace(parentTypeName)
                ? $"{{{propertyInfo.Name}}}"
                : $"{{{parentTypeName}.{propertyInfo.Name}}}";
        }
    }
}