using apbd_cw2_git_s33988;

Service service = new Service();

Equipment laptop1 = new Laptop("Dell", 16, "Intel i5");
Equipment laptop2 = new Laptop("Lenovo", 8, "Intel i3");
Equipment projector1 = new Projector("Epson", 1500, "1280 x 720");
Equipment camera1 = new Camera("Canon", "3840 x 2160", true);

service.AddEquipment(laptop1);
service.AddEquipment(laptop2);
service.AddEquipment(projector1);
service.AddEquipment(camera1);

Console.WriteLine("Added equipment:");
service.ShowAllEquipment();
Console.WriteLine();

User student1 = new Student("Jan", "Kowalski");
User student2 = new Student("Anna", "Nowak");
User employee1 = new Employee("Piotr", "Wiśniewski");

service.AddUser(student1);
service.AddUser(student2);
service.AddUser(employee1);

Console.WriteLine("Users added.\n");

Console.WriteLine("Correct rental:");
service.RentEquipment(student1.Id, laptop1.Id, 7);
Console.WriteLine();

Console.WriteLine("Invalid rental attempt - unavailable equipment:");
service.RentEquipment(student2.Id, laptop1.Id, 5);
Console.WriteLine();

Console.WriteLine("Invalid rental attempt - student exceeds limit:");
service.RentEquipment(student1.Id, laptop2.Id, 5);
service.RentEquipment(student1.Id, projector1.Id, 5);
service.RentEquipment(student1.Id, camera1.Id, 5);
Console.WriteLine();

Console.WriteLine("Return on time:");
service.ReturnEquipment(laptop1.Id);
Console.WriteLine();

Console.WriteLine("Late return with penalty:");
service.RentEquipment(employee1.Id, camera1.Id, 1);

var lateRenting = service.RentingList
    .FirstOrDefault(r => r.Equipment.Id == camera1.Id && r.IsActive);

if (lateRenting != null)
{
    lateRenting.DateEnd = DateTime.Now.AddDays(-3);
}

service.ReturnEquipment(camera1.Id);
Console.WriteLine();

Console.WriteLine("Final report:");
service.ShowReport();