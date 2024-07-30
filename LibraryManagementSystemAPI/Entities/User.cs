﻿namespace LibraryManagementSystemAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public List<Book> Books { get; set; }
        public bool IsAdmin { get; set; }

    }
}