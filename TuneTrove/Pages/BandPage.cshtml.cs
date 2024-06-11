using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Presentation_Interfaces;
using TuneTrove_Logic.Services;

namespace TuneTrove_presentation.Pages
{
	public class BandPageModel : PageModel
	{
		private readonly IBandService _bandService;
		private readonly ISetlistService _setlistService;
		private readonly INummerService _nummerService;
		private readonly IMuzikantService _muzikantService;

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

			Bands = _bandService.GetAllBands()?.ToList() ?? new List<Band>();
			BandPage = new List<Band>();
		}

		public List<Band> Bands { get; set; }
		public List<Band> BandPage { get; set; }

		[TempData]
		public int PageIndex { get; set; }

		public void OnGet()
		{
			if (!TempData.ContainsKey("PageIndex"))
			{
				PageIndex = 0;
			}
			else
			{
				PageIndex = (int)TempData["PageIndex"];
			}

			LoadBandPage();
			TempData.Keep("PageIndex");
		}

		public IActionResult OnPostNextPage()
		{
			PageIndex++;
			TempData["PageIndex"] = PageIndex;
			LoadBandPage();
			return Page();
		}

		public IActionResult OnPostPrevPage()
		{
			if (PageIndex > 0)
			{
				PageIndex--;
				TempData["PageIndex"] = PageIndex;
			}

			LoadBandPage();
			return Page();
		}

		private void LoadBandPage()
		{
			BandPage.Clear();

			int startIndex = PageIndex * 10;
			Band[] bandArray = Bands.ToArray();
			for (int i = startIndex; i < startIndex + 10 && i < bandArray.Length; i++)
			{
				BandPage.Add(_bandService.PopulateBand(bandArray[i]));
			}
		}
	}
}
