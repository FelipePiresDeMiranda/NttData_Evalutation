using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// A Customer with Sales
    /// </summary>
    public class Customer : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public bool IsTrial { get; set; }
        public bool IsActive { get; set; }        

        public virtual ICollection<Sale> Sales { get; set; }

    }




}
