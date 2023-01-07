namespace asset.api.Entities.Base;

public interface IUpdateableEntity
{
    DateTime? UpdatedOn { get; set; }
    Guid? UpdatedBy { get; set; }
}