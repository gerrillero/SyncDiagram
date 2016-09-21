using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppSyncDiagram.ModelViews
{
    public class PersoonViewModel
    {
        public Guid Id { get; set; }
        public String Naam { get; set; }
        public List<RelatieViewModel> Relaties { get; set; }

        public PersoonViewModel()
        {
            Relaties = new List<RelatieViewModel>();
        }

        public PersoonViewModel(Guid id)
        {
            Relaties = new List<RelatieViewModel>();
        }
    }
}