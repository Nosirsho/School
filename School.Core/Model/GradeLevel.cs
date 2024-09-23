namespace School.Core.Model;

public class GradeLevel
{
    public Guid Id { get; set; }
    public string TypeName { get; set; } = string.Empty;
    public DateTime EntryYear { get; set; } = DateTime.Today;
    public List<Student> Students { get; set; } = new List<Student>();
    public Teacher Teacher { get; set; }
}