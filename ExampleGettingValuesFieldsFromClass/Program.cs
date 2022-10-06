using System.Reflection;
using ExampleGettingValuesFieldsFromClass;

#region Методы
List<FieldInfo> GetFieldsFromClass(object obj)
{
    return obj.GetType().GetFields().Where(x => x.IsPublic).ToList();
}
#endregion

Console.Write("Введите имя персоны: ");
var currentName = Console.ReadLine();
Console.Write("Введите возраст персоны: ");
var currentAge = Console.ReadLine();

if (!string.IsNullOrEmpty(currentName) && (Convert.ToInt32(currentAge) > 0))
{
    var person = new Person { name = currentName, age = Convert.ToInt32(currentAge) };

    Console.WriteLine("Значения полей класса персона");

    foreach (var fieldClass in GetFieldsFromClass(person))
    {
        if (Convert.GetTypeCode(fieldClass.GetValue(person)) == TypeCode.String)
        {
            Console.Write("- Имя персоны: ");
            Console.WriteLine(fieldClass.GetValue(person));
        }
        else
        {
            Console.Write("- Возраст персоны: ");
            Console.WriteLine(Convert.ToString(fieldClass.GetValue(person)));
        }
    }
}



