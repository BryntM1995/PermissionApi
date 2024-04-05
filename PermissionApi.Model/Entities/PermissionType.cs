using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PermissionManagement.Model.Entities
{
    public class PermissionType : BaseEntity, ISoftDeleteEntity, IAuditEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
