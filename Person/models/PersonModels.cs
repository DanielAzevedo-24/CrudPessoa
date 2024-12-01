namespace Person.models;
public class PersonModels
{
    public PersonModels(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }
    public Guid Id { get; init;}
    public string Name{ get; private set;}
}