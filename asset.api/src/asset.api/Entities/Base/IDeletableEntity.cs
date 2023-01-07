namespace asset.api.Entities.Base;

public interface IDeletableEntity
{
    bool IsDeleted { get; set; }
}