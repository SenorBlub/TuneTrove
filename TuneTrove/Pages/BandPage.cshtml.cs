using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Presentation_Interfaces;
using System.Collections.Generic;

namespace TuneTrove_presentation.Pages
{
    public class BandPageModel : PageModel
    {
        private readonly IBandService _bandService;

        public BandPageModel(IBandService bandService)
        {
            _bandService = bandService;
        }

        public List<Band> BandPage { get; set; }

        [BindProperty]
        public int PageIndex { get; set; } = 0;

        public void OnGet()
        {
            LoadBands();
        }

        public void OnPostNextPage()
        {
            PageIndex++;
            LoadBands();
        }

        public void OnPostPrevPage()
        {
            if (PageIndex > 0)
            {
                PageIndex--;
            }
            LoadBands();
        }

        public IActionResult OnPostDelete(int bandId)
        {
            _bandService.RemoveBand(bandId);
            LoadBands();
            return Page();
        }

        private void LoadBands()
        {
            BandPage = new List<Band>(); 
            foreach (Band band in _bandService.GetAllBands())
            {
                BandPage.Add(_bandService.PopulateBand(band));
            } 
        }
    }
}