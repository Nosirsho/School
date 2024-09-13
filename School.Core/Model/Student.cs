namespace School.Core.Model;

public class Student
{
    public Student(string firstName, string lastName, string middleName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        BirthDate = birthDate;
        Id = Guid.NewGuid();
    }
    public Student(Guid id, string firstName, string lastName, string middleName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        BirthDate = birthDate;
        Id = id;
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime BirthDate { get; set; }
}