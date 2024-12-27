namespace StudentService_CRUD.Domain.Models
{
    public class AuditLog
    {
        public DateTime DateCreated { get; set; }
        public string PerformAction { get; set; }
    }
}
