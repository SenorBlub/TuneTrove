using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Presentation_Interfaces;

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

		public void OnGet()
		{
			LoadAvailableIds();
			SelectRandomBandLeiderId();
			GenerateRandomBandId();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				LoadAvailableIds();
				return Page();
			}
			GenerateRandomBandId();
			var newBand = new Band
			{
				Id = BandId,
				Name = Name,
				BandLeiderId = BandLeiderId,
				SetlistIds = SetlistIds,
				MuzikantIds = MuzikantIds
			};

			_bandService.PostBand(newBand);

			return RedirectToPage("/BandPage");
		}

		private void LoadAvailableIds()
		{
			AvailableBandLeiderIds = _muzikantService.GetAllMuzikanten().Select(m => m.Id).ToList();
			AvailableSetlistIds = _setlistService.GetAllSetlists().Select(s => s.Id).ToList();
			AvailableMuzikantIds = _muzikantService.GetAllMuzikanten().Select(m => m.Id).ToList();
		}

		private void SelectRandomBandLeiderId()
		{
			Random random = new Random();

			if (AvailableBandLeiderIds.Any())
			{
				BandLeiderId = AvailableBandLeiderIds[random.Next(AvailableBandLeiderIds.Count)];
			}
		}

		private void GenerateRandomBandId()
		{
			Random random = new Random();
			List<int> existingIds = _bandService.GetAllBands().Select(b => b.Id).ToList();
			int newId;
			do
			{
				newId = random.Next(1, int.MaxValue);
			} while (existingIds.Contains(newId));

			BandId = newId;
		}
	}
}
