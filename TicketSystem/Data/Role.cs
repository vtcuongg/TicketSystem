﻿using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Data
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [Required, StringLength(50)]
        public string RoleName { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
