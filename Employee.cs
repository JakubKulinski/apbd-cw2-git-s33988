namespace apbd_cw2_git_s33988;

public class Employee : User
{
    public Employee(string name, string surname) : base(name, surname) { }
    public override int MaxRentals => 5;
    public override string UserType => "Employee";
}