using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PermissionManagement.Model.Entities
{
    public class Permission : BaseEntity, ISoftDeleteEntity, IAuditEntity
    {
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [Required]
        public string EmployeeFirstName { get; set; }
        [Required]
        public string EmployeeLastName { get; set; }
        public virtual PermissionType PermissionType { get; set; }
        [Required]
        [ForeignKey("PermissionType")]
        public int PermissionTypeId { get; set; }
        [Required]
        public DateTime PermissionDate { get; set; }
        
    }
}
