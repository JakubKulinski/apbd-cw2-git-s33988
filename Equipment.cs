namespace ConsoleApp2;

public abstract class Equipment
{
    
    public int Id { get; }
    public string Name { get; set; }
    public EquipmentStatus Status {get; set;}
    public static int IdCounter = 1;

    public Equipment(string name)
    {
        Name = name;
        Id = IdCounter++;
        Status = EquipmentStatus.Available;
    }
}