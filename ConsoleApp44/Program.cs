using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using YamlDotNet.Serialization;

[Serializable]
public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Salary { get; set; }

    public Employee(string name, int age, double salary)
    {
        Name = name;
        Age = age;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Salary: {Salary:C}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an Employee object
        Employee emp = new Employee("John Doe", 30, 50000.0);

        // Binary serialization
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms = new MemoryStream();
        bf.Serialize(ms, emp);
        byte[] binaryData = ms.ToArray();
        Console.WriteLine($"Binary data: {BitConverter.ToString(binaryData)}");

        // JSON serialization
        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Employee));
        ms = new MemoryStream();
        js.WriteObject(ms, emp);
        string jsonData = System.Text.Encoding.UTF8.GetString(ms.ToArray());
        Console.WriteLine($"JSON data: {jsonData}");

        // YAML serialization
        Serializer serializer = new Serializer();
        string yamlData = serializer.Serialize(emp);
        Console.WriteLine($"YAML data: {yamlData}");

        // XML serialization
        XmlSerializer xs = new XmlSerializer(typeof(Employee));
        ms = new MemoryStream();
        xs.Serialize(ms, emp);
        string xmlData = System.Text.Encoding.UTF8.GetString(ms.ToArray());
        Console.WriteLine($"XML data: {xmlData}");
    }
}
