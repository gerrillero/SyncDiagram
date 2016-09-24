using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppSyncDiagram.ModelViews;

namespace WebAppSyncDiagram.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<DiagramNodeViewModel> model = new List<DiagramNodeViewModel>();

            // AS - get de persoon
            PersoonViewModel persoon = new PersoonViewModel();
            persoon.Id = Guid.NewGuid();
            persoon.Naam = "Persoon";

            // AS - get de relaties
            List<RelatieViewModel> relaties = new List<RelatieViewModel>();

            Array values = Enum.GetValues(typeof(TypeRelatie));
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                RelatieViewModel relatie = new RelatieViewModel
                {
                    Id = Guid.NewGuid(),
                    Naam = "Relatie " + i,
                    typeRelatie = (TypeRelatie)values.GetValue(random.Next(values.Length))
                };

                relaties.Add(relatie);   
            }

            persoon.Relaties = relaties;


            // AS - build de model
            model.Add(new DiagramNodeViewModel
            {
                Id = persoon.Id.ToString(),
                Naam = persoon.Naam,
                Kleur = "orange"
                
            });

            Boolean isFamilieGemaakt = false;
            Boolean isProfesioneel = false;
            Boolean isSpecialist = false;
            foreach (var item in persoon.Relaties.OrderByDescending(r => r.typeRelatie))
            {
                if (item.typeRelatie == TypeRelatie.Familie && isFamilieGemaakt == false)
                {
                    model.Add(new DiagramNodeViewModel
                    {
                        Id = TypeRelatie.Familie.ToString(),
                        IdParent = persoon.Id.ToString(),
                        Naam = "Familie",
                        Kleur = "green"
                    });

                    isFamilieGemaakt = true;
                }

                if (item.typeRelatie == TypeRelatie.Profesioneel && isProfesioneel == false)
                {
                    model.Add(new DiagramNodeViewModel
                    {
                        Id = TypeRelatie.Profesioneel.ToString(),
                        IdParent = persoon.Id.ToString(),
                        Naam = "Profesioneel",
                        Kleur = "blue"
                    });

                    isProfesioneel = true;
                }

                if (item.typeRelatie == TypeRelatie.Specialist && isSpecialist == false)
                {
                    model.Add(new DiagramNodeViewModel
                    {
                        Id = TypeRelatie.Specialist.ToString(),
                        IdParent = persoon.Id.ToString(),
                        Naam = "Specialist",
                        Kleur = "red"
                    });

                    isSpecialist = true;
                }

                model.Add(new DiagramNodeViewModel
                {
                    Id = item.Id.ToString(),
                    IdParent = item.typeRelatie.ToString(),
                    Naam = item.Naam,
                    Kleur = "#333333"
                });
            }

            return View(model);
        }

    }
}