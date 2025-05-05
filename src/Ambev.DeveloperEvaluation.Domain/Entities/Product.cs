using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// A Product with or without items
    /// </summary>
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string SKU { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public bool IsTrial { get; set; }
        public bool IsActive { get; set; }
        public DateTime SetActive { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public float Price { get; set; } = 0;

        public virtual ICollection<Item> Items { get; set; }

    }




}
