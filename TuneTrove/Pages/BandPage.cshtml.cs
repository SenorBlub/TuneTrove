using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            Bands = _bandService.GetAllBands();
            Members = _muzikantService.GetAllMuzikanten();
            Setlists = _setlistService.GetAllSetlists();
        }

        [BindProperty]
        public int CreateBandBandLeider { get; set; }

        [BindProperty]
        public int MemberIds { get; set; }

        [BindProperty]
        public int SetlistIds { get; set; }

        [BindProperty]
        public int Num { get; set; }

        [BindProperty]
        public string Name { get; set; }

        public List<Band> Bands = new List<Band>();

        public Band TemporaryBand;

        public List<Muzikant> Members; // load into here

        public List<Setlist> Setlists; //load into here

        public string title;

        public void OnGet()
        {
	        title = "All bands";

	        var temporaryBandJson = HttpContext.Session.GetString("TemporaryBand");
	        if (!string.IsNullOrEmpty(temporaryBandJson))
	        {
		        TemporaryBand = JsonSerializer.Deserialize<Band>(temporaryBandJson);
	        }
	        else
	        {
		        TemporaryBand = new Band();
	        }

			Bands = _bandService.GetAllBands();

            Setlists = _setlistService.GetAllSetlists();

            Members = _muzikantService.GetAllMuzikanten();
        }

        public void OnPostCreateBand()
        {
			// in partial view for band creation: 
			// add single values
			// add complex objects one by one and save in list
			// post
			var temporaryBandJson = HttpContext.Session.GetString("TemporaryBand");
			if (!string.IsNullOrEmpty(temporaryBandJson))
			{
				TemporaryBand = JsonSerializer.Deserialize<Band>(temporaryBandJson);
			}
			else
			{
				TemporaryBand = new Band();
			}
			Bands = _bandService.GetAllBands();

			Setlists = _setlistService.GetAllSetlists();

			Members = _muzikantService.GetAllMuzikanten();

			TemporaryBand.Id = Num;
            TemporaryBand.Name = Name;

            if (TemporaryBand.BandLeider != null)
            {
	            _bandService.PostBand(TemporaryBand);
	            HttpContext.Session.Remove("TemporaryBand");
            }
            else
            {
	            throw new Exception("Data incorrect");
            }


        }

        public void OnPostCreateBandBandLeider()
        {

	        var temporaryBandJson = HttpContext.Session.GetString("TemporaryBand");
	        if (!string.IsNullOrEmpty(temporaryBandJson))
	        {
		        TemporaryBand = JsonSerializer.Deserialize<Band>(temporaryBandJson);
	        }
	        else
	        {
		        TemporaryBand = new Band();
	        }

			Console.WriteLine(CreateBandBandLeider);
	        TemporaryBand.BandLeider = CreateBandBandLeider;

	        temporaryBandJson = JsonSerializer.Serialize(TemporaryBand);
	        HttpContext.Session.SetString("TemporaryBand", temporaryBandJson);

	        Bands = _bandService.GetAllBands();

	        Setlists = _setlistService.GetAllSetlists();

	        Members = _muzikantService.GetAllMuzikanten();
		}

        public void OnPostCreateBandMembers()
        {
	        var temporaryBandJson = HttpContext.Session.GetString("TemporaryBand");
	        if (!string.IsNullOrEmpty(temporaryBandJson))
	        {
		        TemporaryBand = JsonSerializer.Deserialize<Band>(temporaryBandJson);
	        }
	        else
	        {
		        TemporaryBand = new Band();
	        }

			TemporaryBand.MuzikantIds.Add(MemberIds);

			temporaryBandJson = JsonSerializer.Serialize(TemporaryBand);
			HttpContext.Session.SetString("TemporaryBand", temporaryBandJson);

			Bands = _bandService.GetAllBands();

			Setlists = _setlistService.GetAllSetlists();

			Members = _muzikantService.GetAllMuzikanten();
		}

        public void OnPostCreateBandSetlists()
        {
	        var temporaryBandJson = HttpContext.Session.GetString("TemporaryBand");
	        if (!string.IsNullOrEmpty(temporaryBandJson))
	        {
		        TemporaryBand = JsonSerializer.Deserialize<Band>(temporaryBandJson);
	        }
	        else
	        {
		        TemporaryBand = new Band();
	        }

			TemporaryBand.SetlistIds.Add(SetlistIds);

			temporaryBandJson = JsonSerializer.Serialize(TemporaryBand);
			HttpContext.Session.SetString("TemporaryBand", temporaryBandJson);

			Bands = _bandService.GetAllBands();

			Setlists = _setlistService.GetAllSetlists();

			Members = _muzikantService.GetAllMuzikanten();
		}

	}
}
