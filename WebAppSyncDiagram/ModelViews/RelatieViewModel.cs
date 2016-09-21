using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppSyncDiagram.ModelViews
{
    public class RelatieViewModel
    {
        public Guid Id { get; set; }
        public String Naam { get; set; }
        public TypeRelatie typeRelatie { get; set; }
        public String Kleur { get; set; }

    }

    public enum TypeRelatie
    {
        Specialist,
        Profesioneel,
        Familie
    }
}