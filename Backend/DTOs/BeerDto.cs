﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DTOs
{
    public class BeerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public decimal Alcohol { get; set; }
    }
}
