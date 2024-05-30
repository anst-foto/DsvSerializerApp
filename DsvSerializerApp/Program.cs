using DsvSerializerApp;

var test = new Test()
{
    Name = "test",
    Age = 10,
    Address = "address",
    City  =  "city"
};

var dsv = DsvSerializer.Serialize(test);
Console.WriteLine(dsv);