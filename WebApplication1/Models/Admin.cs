﻿namespace Book_Web.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool Enabled { get; set; }
    }
}
