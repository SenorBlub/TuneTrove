using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.IServices;

namespace TuneTrove_presentation.Pages
{
    public class NummerPageModel : PageModel
    {
	    private readonly INummerService _nummerService;

	    public NummerPageModel(INummerService nummerService)
	    {
			_nummerService = nummerService;
	    }

	    [BindProperty]
	    public int PageIndex { get; set; } = 0;
	    [BindProperty]
	    public int PageSize { get; set; } = 10;

	    public List<NummerDTO> NummerPage { get; set; }

	    public IActionResult OnGet()
		{
			if (!int.TryParse(Request.Query["page"], out int page))
			{
				page = 0;
			}

			PageIndex = page;
			LoadNummers();

			return Page();
		}

		public int NextPage()
		{
			if (!int.TryParse(Request.Query["page"], out int page))
			{
				page = 0;
			}

			PageIndex = page;
			PageIndex++;
			LoadNummers();
			return PageIndex;
		}

		public int PrevPage()
		{
			if (!int.TryParse(Request.Query["page"], out int page))
			{
				page = 0;
			}

			PageIndex = page;
			if (PageIndex > 0)
			{
				PageIndex--;
			}
			else
			{
				PageIndex = 0;
			}
			LoadNummers();
			return PageIndex;
		}

		public IActionResult OnPostDelete(int nummerId)
		{
			_nummerService.RemoveNummer(nummerId);
			LoadNummers();
			return Page();
		}

		private void LoadNummers()
		{
			NummerPage = _nummerService.GetNummerPage(PageIndex, PageSize);
		}
	}
}
