using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Presentation_Interfaces;
using TuneTrove_Logic.Services;

namespace TuneTrove_presentation.Pages
{
    public class BandPageModel : PageModel
    {
        private IBandService _bandService;
        private ISetlistService _setlistService;
        private INummerService _nummerService;
        private IMuzikantService _muzikantService;

        public BandPageModel(
            IBandService bandService,
            ISetlistService setlistService,
            IMuzikantService muzikantService,
            INummerService nummerService)
        {
            _bandService = bandService;
            _setlistService = setlistService;
            _nummerService = nummerService;
            _muzikantService = muzikantService;
        }

        public List<Band> bands;

        public Band temporaryBand;

        public string title;

        public void OnGet()
        {
            title = "All bands";

            bands = new List<Band>();
            foreach (Band band in _bandService.GetAllBands())
            {
                bands.Add(band);
            }
        }

        public void OnPost()
        {

        }
    }
}
