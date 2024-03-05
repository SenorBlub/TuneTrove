using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Services;

namespace TuneTrove_presentation.Pages
{
    public class BandPageModel : PageModel
    {
        private BandService _bandService;
        private SetlistService _setlistService;
        private NummerService _nummerService;
        private MuzikantService _muzikantService;

        public BandPageModel(
            BandService bandService,
            SetlistService setlistService,
            MuzikantService muzikantService,
            NummerService nummerService)
        {
            _bandService = bandService;
            _setlistService = setlistService;
            _nummerService = nummerService;
            _muzikantService = muzikantService;
        }

        public Band band;

        public string title;

        public void OnGet()
        {
            title = "All bands";
        }

        public void OnGet(int muzikantId)
        {
            title = "All bands for " + _muzikantService.GetMuzikantById(muzikantId).Name + "";
        }
    }
}
