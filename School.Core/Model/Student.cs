﻿namespace School.Core.Model;

public class Student
{
    public Student(string firstName, string lastName, string middleName, DateTime birthDate, Sex sex)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        BirthDate = birthDate;
        Sex = sex;
        Id = Guid.NewGuid();
    }
    public Student(Guid id, string firstName, string lastName, string middleName, DateTime birthDate, Sex sex)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        BirthDate = birthDate;
        Sex = sex;
        Id = id;
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<Parent> Parents { get; set; } = [];
    public Sex Sex { get; set; }
}