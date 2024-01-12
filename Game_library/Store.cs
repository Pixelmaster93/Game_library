namespace Game_library;

public class Store
{
    public string Name { get; }
    public string Description { get; }
    public Uri? WebSite{ get; }

    public Store(string name, string? description, Uri? webSite)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description ?? name; //se description è null assumerà name come parametro
        WebSite = webSite;
    }
}
