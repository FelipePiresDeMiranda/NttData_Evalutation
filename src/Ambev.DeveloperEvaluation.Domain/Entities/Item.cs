using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// An Item is a kind of Product
    /// </summary>
    public class Item : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string Number { get; set; }
        
        [StringLength(255)]
        public string Description { get; set; }
        public bool IsTrial { get; set; }
        public bool IsActive { get; set; }
        public DateTime SetActive { get; set; }

        [Required]
        public virtual Product Product { get; set; }

    }




}
