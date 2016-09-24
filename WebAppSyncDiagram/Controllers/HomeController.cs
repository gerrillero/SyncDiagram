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
            PersoonViewModel persoon = new PersoonViewModel(Guid.NewGuid());
            persoon.Naam = "Persoon";

            // AS - get de relaties
            List<RelatieViewModel> relaties = new List<RelatieViewModel>();

            Array values = Enum.GetValues(typeof(TypeRelatie));
            Random random = new Random();

            for (int i = 0; i < 30; i++)
            {
                RelatieViewModel relatie = new RelatieViewModel
                {
                    Id = Guid.NewGuid(),
                    Naam = "Relatie " + i,
                    typeRelatie = (TypeRelatie)values.GetValue(random.Next(values.Length))
                };

                switch (relatie.typeRelatie)
                {
                    case TypeRelatie.Specialist:
                        relatie.Kleur = "red";
                        break;
                    case TypeRelatie.Profesioneel:
                        relatie.Kleur = "blue";
                        break;
                    case TypeRelatie.Familie:
                        relatie.Kleur = "green";
                        break;
                    default:
                        break;
                }
                relaties.Add(relatie);   
            }

            persoon.Relaties = relaties;

            // AS - build de model
            model.Add(new DiagramNodeViewModel
            {
                Id = persoon.Id.ToString(),
                Naam = persoon.Naam,
                
            });

            Boolean isFamilieGemaakt = false;
            foreach (var item in persoon.Relaties.OrderByDescending(r => r.typeRelatie))
            {
                if (item.typeRelatie == TypeRelatie.Familie && isFamilieGemaakt == false)
                {
                    model.Add(new DiagramNodeViewModel
                    {

                    });

                    isFamilieGemaakt = true;
                }
            }

            return View(model);
        }

    }
}