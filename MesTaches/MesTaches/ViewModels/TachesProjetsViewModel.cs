using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MesTaches.ViewModels
{
    public class TachesProjetsViewModel
    {

        public List<MesTaches.Models.Projet> Projets { get; set; }

        public IEnumerable<MesTaches.Models.Tache> Taches { get; set; }

    }
}