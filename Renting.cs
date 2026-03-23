namespace apbd_cw2_git_s33988;

public class Renting
{
    public int Id { get; }
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public DateTime? ReturnDate { get; set; }

    private static int _idCounter = 1;
    
    public bool IsActive => ReturnDate == null;

    public Renting(User user, Equipment equipment, int days)
    {
        Id = _idCounter++;
        User = user;
        Equipment = equipment;
        DateStart = DateTime.Now;
        DateEnd = DateStart.AddDays(days);
    }

    public void Return()
    {
        ReturnDate = DateTime.Now;
    }
}