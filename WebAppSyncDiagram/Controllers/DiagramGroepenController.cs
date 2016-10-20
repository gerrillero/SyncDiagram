using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppSyncDiagram.ModelViews;

namespace WebAppSyncDiagram.Controllers
{
    public class DiagramGroepenController : Controller
    {
        public ActionResult Index()
        {
            var groepen = GetGroepen();

            List<DiagramNodeViewModel> model = new List<DiagramNodeViewModel>();

            foreach (var groep in groepen)
            {
                DiagramNodeViewModel node = new DiagramNodeViewModel
                {
                    Id = groep.Id.ToString(),
                    IdParent = groep.IdParent.ToString(),
                    Naam = groep.Naam,
                    Kleur = "orange"
                };

                model.Add(node);

                foreach (var gebruiker in groep.Gebruikers)
                {
                    DiagramNodeViewModel node2 = new DiagramNodeViewModel
                    {
                        Id = gebruiker.Id.ToString(),
                        IdParent = groep.Id.ToString(),
                        Naam = gebruiker.Naam,
                        Kleur = "blue"
                    };


                    model.Add(node2);
                }
            }
            

            return View(model);
        }

        private List<GroepViewModel> GetGroepen()
        {
            List<GroepViewModel> groepen = new List<GroepViewModel>();
            groepen.Add(new GroepViewModel { Id = 1, Naam = "Parent groep" });
            groepen.Add(new GroepViewModel { Id = 2, Naam = "Groep 2", IdParent = 1 });
            groepen.Add(new GroepViewModel { Id = 3, Naam = "Groep 3", IdParent = 1 });
            groepen.Add(new GroepViewModel { Id = 4, Naam = "Groep 4", IdParent = 1 });

            Random random = new Random();
            for (int i = 1; i < 10; i++)
            {
                GebruikerViewModel gebruiker = new GebruikerViewModel { Id = Guid.NewGuid(), Naam = "Gebruiker " + i };
                Int32 randomNumber = random.Next(groepen.Count);
                groepen.Find(x => x.Id == randomNumber + 1).Gebruikers.Add(gebruiker);
            }

            return groepen;
        }
    }
}