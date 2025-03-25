namespace DataAccess.models;

public class BaseEntity
{
    public int id { get; set; } //PK
    public int createdBy { get; set; } // user id
    public DateTime createdOn { get; set; }
    public int lastModifiedBy { get; set; } //user id
    public DateTime? lastModifiedOn { get; set; }
    public bool isDeleted { get; set; } // soft delete 
}