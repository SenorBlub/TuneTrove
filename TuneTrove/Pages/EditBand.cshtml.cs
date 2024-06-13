using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http.Extensions;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.IServices;

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
        }

        [BindProperty]
        [Required(ErrorMessage = "Band name is required.")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Band Leader ID is required.")]
        public int? BandLeiderId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Setlist IDs are required.")]
        public List<int> SetlistIds { get; set; } = new List<int>();

        [BindProperty]
        [Required(ErrorMessage = "Muzikant IDs are required.")]
        public List<int> MuzikantIds { get; set; } = new List<int>();

        [BindProperty]
        public int BandId { get; set; }

        public List<int> AvailableBandLeiderIds { get; set; }
        public List<int> AvailableSetlistIds { get; set; }
        public List<int> AvailableMuzikantIds { get; set; }

        public IActionResult OnGet()
        {
            // Read the ID from the URL
            if (!int.TryParse(Request.Query["id"], out int id))
            {
                return RedirectToPage("/BandPage");
            }

/*            var request = HttpContext.Request;
            var url = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}";*/

            /*var band = _bandService.GetBandById(id);
            if (band == null)
            {
                return RedirectToPage("/BandPage");
            }*/

            /*BandId = band.Id;
            Name = band.Name;
            BandLeiderId = band.BandLeiderId;
            SetlistIds = band.SetlistIds ?? new List<int>();
            MuzikantIds = band.MuzikantIds ?? new List<int>();*/

            LoadAvailableIds();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                LoadAvailableIds();
                return Page();
            }

            /*var updatedBand = new Band
            {
                Id = BandId,
                Name = Name,
                BandLeiderId = BandLeiderId,
                SetlistIds = SetlistIds,
                MuzikantIds = MuzikantIds
            };

            _bandService.EditBand(updatedBand);*/

            return RedirectToPage("/BandPage");
        }

        private void LoadAvailableIds()
        {
            AvailableBandLeiderIds = _muzikantService.GetAllMuzikanten().Select(m => m.Id).ToList();
            AvailableSetlistIds = _setlistService.GetAllSetlists().Select(s => s.Id).ToList();
            AvailableMuzikantIds = _muzikantService.GetAllMuzikanten().Select(m => m.Id).ToList();
        }
    }
}
