using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MesTaches.ViewModels
{
    public class TacheFormViewModel
    {

        public int Id { get; set; }

        public TacheFormViewModel()
        {

        }

        [Required]
        public string Name { get; set; }

        [Required]
        [ValidateDates]
        public string CreateDate { get; set; }
        public string CreateTime { get; set; }

        public string EndDate { get; set; }
        public string EndTime { get; set; }

        public string FinalDate { get; set; }
        public string FinalTime { get; set; }

        
        public DateTime getCreateDT()
        {
            return DateTime.Parse(string.Format("{0} {1}", CreateDate, CreateTime)); 
        }

        public DateTime? getEndDT()
        {
            DateTime? res = null;
            try
            {
                res = DateTime.Parse(string.Format("{0} {1}", EndDate, EndTime));
            }
            catch { }
            finally { }
            return res;
        }

        public DateTime? getFinalDT()
        {
            DateTime? res = null;
            try
            {
                res = DateTime.Parse(string.Format("{0} {1}", FinalDate, FinalTime));
            }
            catch { }
            finally { }
            return res;
        }

        [Required]
        public int Projet { get; set; }
        public IEnumerable<Models.Projet> Projets { get; set; }
    }
}