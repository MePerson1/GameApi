﻿using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public Game Game { get; set; }
    }
}
