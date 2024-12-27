namespace StudentService_CRUD.Domain.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }

        public string? Email { get; set; }
        public Relative? Relatives { get; set; }
        public Address? Address { get; set; }

        public AuditLog AuditLogs { get; set; }

    }
}
