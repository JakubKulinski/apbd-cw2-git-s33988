namespace ConsoleApp2;

public abstract class User
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public static int IdCounter = 1;

    public User( string name, string surname)
    {
        Id = IdCounter++;
        Name = name;
        Surname = surname;
    }
}