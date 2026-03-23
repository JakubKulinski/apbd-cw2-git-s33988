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
    
    public void AddUser(User user)
    {
        Users.Add(user);
    }
    public void AddEquipment(Equipment equipment)
    {
        EquipmentList.Add(equipment);
    }

    public void ShowAllEquipment()
    {
        foreach (var item in EquipmentList)
        {
            Console.WriteLine(item);
        }
    }

    public void ShowAvailableEquipment()
    {
        foreach (var item in EquipmentList)
        {
            if (item.Status == EquipmentStatus.Available)
            {
                Console.WriteLine(item);
            }
        }
    }
    
    public void RentEquipment(int userId, int equipmentId, int days)
    {
        var user = Users.FirstOrDefault(u => u.Id == userId);
        var equipment = EquipmentList.FirstOrDefault(e => e.Id == equipmentId);

        if (equipment == null || user == null)
        {
            Console.WriteLine("User or  equipment not found");
            return;
        }

        if (!equipment.Status.Equals(EquipmentStatus.Available))
        {
            Console.WriteLine("Equipment is not available");
            return;
        }

        var currentRenting = RentingList.Count(r => r.User.Id == user.Id);
        if (currentRenting >= 3)
        {
            Console.WriteLine("User exceeded rental limit.");
            return;
        }
        
        var renting = new Renting(user, equipment, days);
        RentingList.Add(renting);
        equipment.Status = EquipmentStatus.Unavailable;
    }
}