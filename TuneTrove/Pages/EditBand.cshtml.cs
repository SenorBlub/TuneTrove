using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.IServices;
using TuneTrove_Logic.DTOs;

namespace TuneTrove_presentation.Pages
{
    public class EditBandModel : PageModel
    {
        private readonly IBandService _bandService;
        private readonly IMuzikantService _muzikantService;
        private readonly ISetlistService _setlistService;

        public EditBandModel(IBandService bandService, IMuzikantService muzikantService, ISetlistService setlistService)
        {
            _bandService = bandService;
            _muzikantService = muzikantService;
            _setlistService = setlistService;
            LoadAvailableIds();
        }

        [BindProperty]
        [Required(ErrorMessage = "Band name is required.")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Band Leader is required.")]
        public int BandLeiderId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Setlists are required.")]
        public List<int> SetlistIds { get; set; } = new List<int>();

        [BindProperty]
        [Required(ErrorMessage = "Muzikanten are required.")]
        public List<int> MuzikantIds { get; set; } = new List<int>();

        [BindProperty]
        public int BandId { get; set; }

        public List<MuzikantDTO> AvailableBandLeiders { get; set; }
        public List<SetlistDTO> AvailableSetlists { get; set; }
        public List<MuzikantDTO> AvailableMuzikanten { get; set; }
        public IActionResult OnGet()
        {
            // Read the ID from the URL
            if (!int.TryParse(Request.Query["id"], out int id))
            {
                return RedirectToPage("/BandPage");
            }

            var request = HttpContext.Request;
            var url = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}";

            var band = _bandService.GetBand(id);
            if (band == null)
            {
                return RedirectToPage("/BandPage");
            }

            BandId = band.Id;
            Name = band.Name;
            if(band.Bandleider != null)
                BandLeiderId = band.Bandleider.Id;
            if(band.Setlists != null)
                SetlistIds = band.Setlists.Select(s => s.Id).ToList();
            if(band.Muzikanten != null)
                MuzikantIds = band.Muzikanten.Select(m => m.Id).ToList();

            LoadAvailableIds();

            return Page();
        }

        public IActionResult OnPostEdit()
        {
            if (!ModelState.IsValid)
            {
                LoadAvailableIds();
                return Page();
            }

            var bandLeider = AvailableBandLeiders.FirstOrDefault(m => m.Id == BandLeiderId);
            var setlists = AvailableSetlists.Where(s => SetlistIds.Contains(s.Id)).ToList();
            var muzikanten = AvailableMuzikanten.Where(m => MuzikantIds.Contains(m.Id)).ToList();

            if (bandLeider == null || !setlists.Any() || !muzikanten.Any())
            {
                ModelState.AddModelError(string.Empty, "Invalid selection for Band Leader, Setlists, or Muzikanten.");
                LoadAvailableIds();
                return Page();
            }

            var updatedBand = new BandDTO
            (
                BandId,
                Name,
                bandLeider,
                muzikanten,
                setlists
            );

            _bandService.UpdateBand(updatedBand);

            return RedirectToPage("/BandPage");
        }

        private void LoadAvailableIds()
        {
            AvailableBandLeiders = _muzikantService.GetAllMuzikanten();
            AvailableSetlists = _setlistService.GetAllSetlists();
            AvailableMuzikanten = _muzikantService.GetAllMuzikanten();
        }
    }
}