using System;
using System.ComponentModel.DataAnnotations;

namespace MesTaches.Models
{
    public class Tache
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }
        [Required]
        public DateTime CreateDT { get; set; }

        public DateTime? EndDT { get; set; }

        public DateTime? FinalDT { get; set; }

        [Required]
        public int ProjetId { get; set; }

        public Projet Projet { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }


}