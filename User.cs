namespace apbd_cw2_git_s33988;

public abstract class User
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public abstract int MaxRentals { get; }
    public abstract string UserType { get; }
    
    public static int IdCounter = 1;

    public User( string name, string surname)
    {
        Id = IdCounter++;
        Name = name;
        Surname = surname;
    }
}