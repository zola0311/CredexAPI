﻿namespace CredexAPI.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Users>? Users { get; set; }

    }
}
