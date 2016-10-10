using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppSyncDiagram.ModelViews
{
    public class GroepViewModel
    {
        public Int32 Id { get; set; }
        public Int32? IdParent { get; set; }
        public String Naam { get; set; }
        public List<GebruikerViewModel> Gebruikers { get; set; }

        public GroepViewModel()
        {
            Gebruikers = new List<GebruikerViewModel>();
        }
    }

    public class GebruikerViewModel
    {
        public Guid Id { get; set; }
        public String Naam { get; set; }
    }
}