namespace DsvSerializerApp;

public class DsvAttribute : Attribute
{
    private readonly string? _columnName;

    public string? ColumnName
    {
        get => _columnName;
        init =>
            _columnName = string.IsNullOrWhiteSpace(value) 
                ? throw new ArgumentNullException($"{nameof(ColumnName)} in {nameof(DsvAttribute)} is null or empty")  
                : value;
    }
}