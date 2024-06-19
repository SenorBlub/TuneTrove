using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.IServices;

namespace TuneTrove_presentation.Pages
{
    public class CreateMuzikantModel : PageModel
    {
	    private readonly IMuzikantService _muzikantService;
		private readonly IBandService _bandService;
		private readonly INummerService _nummerService;
		private readonly ISetlistService _setlistService;

		public CreateMuzikantModel(IMuzikantService muzikantService, IBandService bandService, ISetlistService setlistService, INummerService nummerService)
		{
			_muzikantService = muzikantService;
			_bandService = bandService;
			_setlistService = setlistService;
			_nummerService = nummerService;
		}

		public int MuzikantId { get; set; }

		[BindProperty]
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }

		[BindProperty]
		[Required(ErrorMessage = "Instrument is required")]
		public string Instrument { get; set; }

		[BindProperty]
		[Required(ErrorMessage = "Bands are required")]
		public List<int> AvailableBandIds { get; set; }
		[BindProperty]
		[Required(ErrorMessage = "Setlists are required")]
		public List<int> AvailableSetlistIds { get; set; }
		[BindProperty]
		[Required(ErrorMessage = "Nummers are required")]
		public List<int> AvailableNummerIds { get; set; }

		public List<BandDTO> Bands { get; set; }
		public List<SetlistDTO> Setlists { get; set; }
		public List<NummerDTO> Nummers { get; set; }

        public void OnGet()
        {
	        LoadAvailables();
		}

        public IActionResult OnPostCreate()
        {
	        LoadAvailables();
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

		        return Page();
	        }

	        var setlists = Setlists.Where(s => AvailableSetlistIds.Contains(s.Id)).ToList();
	        var bands = Bands.Where(b => AvailableBandIds.Contains(b.Id)).ToList();
	        var nummers = Nummers.Where(n => AvailableNummerIds.Contains(n.Id)).ToList();

	        if (!bands.Any() || !setlists.Any() || !Nummers.Any())
	        {
		        ModelState.AddModelError(string.Empty, "Invalid selection for Band Leader, Setlists, or Muzikanten.");
		        LoadAvailables();
		        return Page();
	        }

	        GenerateRandomMuzikantId();
	        var newMuzikant = new MuzikantDTO
	        (
		        MuzikantId,
				Name,
				Instrument,
				bands,
				nummers,
				setlists
	        );

	        _muzikantService.AddMuzikant(newMuzikant);

	        return RedirectToPage("/MuzikantPage");
        }

		private void LoadAvailables()
        {
	        Bands = _bandService.GetAllBands();
	        Setlists = _setlistService.GetAllSetlists();
	        Nummers = _nummerService.GetAllNummers();
        }

        private void GenerateRandomMuzikantId()
        {
	        Random random = new Random();
	        List<int> existingIds = _muzikantService.GetAllMuzikanten().Select(m => m.Id).ToList();
	        int newId;
	        do
	        {
		        newId = random.Next(1, int.MaxValue);
	        } while (existingIds.Contains(newId) && newId != 0 && newId != 1);

	        MuzikantId = newId;
        }
	}
}
