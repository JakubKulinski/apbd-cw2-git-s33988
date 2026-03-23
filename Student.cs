namespace apbd_cw2_git_s33988;

public class Student : User
{
    public Student(string name, string surname) : base(name, surname) { }
    public override int MaxRentals => 2;
    public override string UserType => "Student";
}