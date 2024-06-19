using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.IServices;
using TuneTrove_Logic.Models;

namespace TuneTrove_presentation.Pages
{
    public class CreateBandModel : PageModel
    {
        private readonly IBandService _bandService;
        private readonly IMuzikantService _muzikantService;
        private readonly ISetlistService _setlistService;

        public CreateBandModel(IBandService bandService, IMuzikantService muzikantService, ISetlistService setlistService)
        {
            _bandService = bandService;
            _muzikantService = muzikantService;
            _setlistService = setlistService;
            AvailableBandLeiders = new List<MuzikantDTO>();
            AvailableSetlists = new List<SetlistDTO>();
            AvailableMuzikanten = new List<MuzikantDTO>();
            GenerateRandomBandId();
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

        public int BandId { get; set; }

        public List<MuzikantDTO> AvailableBandLeiders { get; set; }
        public List<SetlistDTO> AvailableSetlists { get; set; }
        public List<MuzikantDTO> AvailableMuzikanten { get; set; }

        public void OnGet()
        {
            LoadAvailableIds();
        }

        public IActionResult OnPostCreate()
        {
            LoadAvailableIds();
            GenerateRandomBandId();
            if (!ModelState.IsValid)
            {
                // Log ModelState errors
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

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

            GenerateRandomBandId();
            var newBand = new BandDTO
            (
                BandId,
                Name,
                bandLeider,
                muzikanten,
                setlists
            );

            _bandService.AddBand(newBand);

            return RedirectToPage("/BandPage");
        }

        private void LoadAvailableIds()
        {
            AvailableBandLeiders = _muzikantService.GetAllMuzikanten();
            AvailableSetlists = _setlistService.GetAllSetlists();
            AvailableMuzikanten = AvailableBandLeiders;
        }

        private void GenerateRandomBandId()
        {
            Random random = new Random();
            List<int> existingIds = _bandService.GetAllBands().Select(b => b.Id).ToList();
            int newId;
            do
            {
                newId = random.Next(1, int.MaxValue);
            } while (existingIds.Contains(newId) && newId != 0 && newId != 1);

            BandId = newId;
        }
    }
}
