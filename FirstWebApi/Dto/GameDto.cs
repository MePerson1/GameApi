﻿using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.Dto
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Developer { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
