using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asset.api.Entities.Base;

public class ModifiableEntity : BaseEntity, IModifiableEntity
{
    [Required]
    public virtual DateTime CreatedOn { get; set; }
    [Required, DefaultValue(0)]
    public virtual Guid CreatedBy { get; set; }
    public virtual DateTime? UpdatedOn { get; set; }
    public virtual Guid? UpdatedBy { get; set; }
    [Required, DefaultValue(false)]
    public virtual bool IsDeleted { get; set; }
}