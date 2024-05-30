using System.Reflection;
using System.Text;

namespace DsvSerializerApp;

public static class DsvSerializer
{
    public static string Serialize(object obj, string delimiter = "|")
    {
        var type = obj.GetType();

        var properties = type.GetProperties();
        if (properties.Length == 0)
        {
            throw new ArgumentException($"Передаваемый объект для сериализации через {nameof(DsvSerializer)} не содержит свойств");
        }

        var listOfTitles = new List<string>();
        var listOfValues  = new List<string>();
        foreach (var propertyInfo in properties)
        {
            if (!propertyInfo.CanRead) continue;
            
            var value  = propertyInfo.GetValue(obj);
            if  (value  is  null) continue;
            
            var attribute  = propertyInfo.GetCustomAttribute<DsvAttribute>();
            var hasDsvAttribute = attribute is not null;
            var name = hasDsvAttribute 
                ? attribute!.ColumnName ?? propertyInfo.Name
                : propertyInfo.Name;
            
            listOfTitles.Add(name!);
            listOfValues.Add(value!.ToString()!);
        }

        var titles = string.Join(delimiter, listOfTitles);
        var values  = string.Join(delimiter, listOfValues);
        
        return $"{titles}\n{values}";
    }
}