namespace MesTaches.Models
{
    public class Association
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public Projet Projet { get; set; }
    }
}