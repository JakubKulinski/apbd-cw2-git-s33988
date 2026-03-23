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
        if (currentRenting >= user.MaxRentals)
        {
            Console.WriteLine("User exceeded rental limit.");
            return;
        }
        
        var renting = new Renting(user, equipment, days);
        RentingList.Add(renting);
        equipment.Status = EquipmentStatus.Unavailable;
    }
    
    public void ReturnEquipment(int equipmentId)
    {
        var renting = RentingList.FirstOrDefault(r => r.Equipment.Id == equipmentId && r.IsActive);
        if (renting == null)
        {
            Console.WriteLine("Active rental not found");
            return;
        }

        var penalty = renting.Return();
        renting.Equipment.Status = EquipmentStatus.Available;
        Console.WriteLine("Equipment returned. Penalty: " + penalty);
    }
    
    public void ChangeEquipmentStatus(int equipmentId, EquipmentStatus status)
    {
        var equipment = EquipmentList.FirstOrDefault(e => e.Id == equipmentId);
        if (equipment == null)
        {
            Console.WriteLine("Equipment not found.");
            return;
        }
        var renting = RentingList.FirstOrDefault(r => r.Equipment.Id == equipmentId && r.IsActive);
        if (renting != null)
        {
            Console.WriteLine("Changing equipment status failed. Equipment currently rented.");
            return;
        }
        equipment.Status = status;
    }
    
    public void ShowUserRentings(int userId)
    {
        foreach (var renting in RentingList.Where(renting => renting.User.Id == userId && renting.IsActive))
        {
            Console.WriteLine(renting);
        }
    }

    public void ShowOverdueRentings()
    {
        foreach (var renting in RentingList.Where(r => r.IsActive && r.DateEnd < DateTime.Now))
        {
            Console.WriteLine(renting);
        }
    }

    public void ShowReport()
    {
        Console.WriteLine("Users: " + Users.Count);
        Console.WriteLine("Equipment: " + EquipmentList.Count);
        Console.WriteLine("Available: " + EquipmentList.Count(e => e.Status == EquipmentStatus.Available));
        Console.WriteLine("Active rentings: " + RentingList.Count(r => r.IsActive));
    }
}