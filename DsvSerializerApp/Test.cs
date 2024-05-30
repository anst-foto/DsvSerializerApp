namespace DsvSerializerApp;

public class Test
{
    [Dsv(ColumnName = "name")]
    public string Name { get; set; }
    public int Age { get; set; }
    protected string Password { get; set; } = "123456";
    private string Email { get; set; } =  "123@123.com";
    public bool Active  { get; private set; } =  true;
    
    [Dsv]
    public string Address { get; init; }
    public string City { private get; init; }
}