using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.IServices;
using System.Collections.Generic;
using System.Diagnostics;
using TuneTrove_Logic.DTOs;

namespace TuneTrove_presentation.Pages
{
    public class BandPageModel : PageModel
    {
        private readonly IBandService _bandService;

        public BandPageModel(IBandService bandService)
        {
            _bandService = bandService;
        }

        public List<BandDTO> BandPage { get; set; }

        [BindProperty]
        public int PageIndex { get; set; } = 0;
        [BindProperty]
        public int PageSize { get; set; } = 10;

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


            BandPage = _bandService.GetBandPage(PageSize, PageIndex);

        }
    }
}