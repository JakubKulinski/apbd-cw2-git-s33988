namespace apbd_cw2_git_s33988;

public class Laptop : Equipment
{
    public int RamGb { get; set; }
    public string Processor { get; set; }
    public Laptop(string name, int ramGb, string processor) : base(name)
    {
        RamGb = ramGb;
        Processor = processor;
    }
}