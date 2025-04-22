namespace Data.Models.Shared;

public class BaseEntity
{
    public int Id { get; set; } //PK
    public int CreatedBy { get; set; } // user id
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public int LastModifiedBy { get; set; } //user id
    public DateTime? LastModifiedOn { get; set; }
    public bool IsDeleted { get; set; } // soft delete 

}