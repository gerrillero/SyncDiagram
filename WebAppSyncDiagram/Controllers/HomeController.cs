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
            PersoonViewModel model = new PersoonViewModel(Guid.NewGuid());

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

            model.Relaties = relaties;

            return View(model);
        }

    }
}