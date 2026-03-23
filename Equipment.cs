namespace apbd_cw2_git_s33988;

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
    
    public override string ToString()
    {
        return "[" + Id + "] " + Name + " | Status: " + Status;
    }
}