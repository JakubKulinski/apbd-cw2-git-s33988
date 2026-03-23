namespace apbd_cw2_git_s33988;

public class Projector : Equipment
{
    public int Lumens { get; set; }
    public string Resolution { get; set; }
    public Projector(string name, int lumens, string resolution) : base(name)
    {
        Lumens = lumens;
        Resolution = resolution;
    }
}