using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// A Sale with items
    /// </summary>
    public class Sale : BaseEntity
    {             
        [StringLength(255)]
        public string Description { get; set; }
        public bool IsTrial { get; set; }
        public bool IsActive { get; set; }

        [Required]
        [StringLength(30)]
        public string Number { get; set; }
        //Total Amounts by items
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public float TotalAmounts { get; set; } = 0;
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public float Discounts { get; set; } = 0;

        public virtual ICollection<Item> Items { get; set; }
    }
}
