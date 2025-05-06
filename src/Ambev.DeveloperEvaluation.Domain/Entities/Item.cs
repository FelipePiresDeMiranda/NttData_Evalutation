using Ambev.DeveloperEvaluation.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// An Item is a kind of Product
    /// </summary>
    public class Item : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string Number { get; set; } = string.Empty;

        [StringLength(255)]
        public string Description { get; set; } = string.Empty;
        public bool IsTrial { get; set; }
        public bool IsActive { get; set; }
        public DateTime SetActive { get; set; }

        [Required]
        public virtual Product Product { get; set; } = new Product();

    }




}
