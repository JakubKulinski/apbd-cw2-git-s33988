namespace apbd_cw2_git_s33988;

public class Service
{
    public List<User> Users { get; set; }
    public List<Equipment> EquipmentList { get; set; }
    public List<Renting> RentingList { get; set; }

    public Service()
    {
        Users = new List<User>();
        EquipmentList = new List<Equipment>();
        RentingList = new List<Renting>();
    }
}