﻿using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Book : Entity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int ReleaseYear { get; set; }
    }
}