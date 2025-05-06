using Ambev.DeveloperEvaluation.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// A Branch does Sales
    /// </summary>
    public class Branch : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(30)]
        public string Email { get; set; } = string.Empty;
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;
        public bool IsTrial { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }




}
