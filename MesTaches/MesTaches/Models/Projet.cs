using System;
using System.ComponentModel.DataAnnotations;

namespace MesTaches.Models
{
    public class Projet
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public String Name { get; set; }
    }
}