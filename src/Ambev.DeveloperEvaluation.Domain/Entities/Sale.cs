using Ambev.DeveloperEvaluation.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// A Sale with items
    /// </summary>
    public class Sale : BaseEntity
    {
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;
        public bool IsTrial { get; set; }
        public bool IsActive { get; set; }

        [Required]
        [StringLength(30)]
        public string Number { get; set; } = string.Empty;
        //Total Amounts by items
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public float TotalAmounts { get; set; } = 0;
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public float Discounts { get; set; } = 0;

        //public virtual ICollection<Item> Items { get; set; }

    }




}
