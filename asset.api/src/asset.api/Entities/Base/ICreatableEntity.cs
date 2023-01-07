namespace asset.api.Entities.Base;

public interface ICreatableEntity
{
    DateTime CreatedOn { get; set; }
    Guid CreatedBy { get; set; }
}