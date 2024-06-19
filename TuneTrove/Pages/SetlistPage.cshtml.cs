using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.IServices;

namespace TuneTrove_presentation.Pages
{
	public class SetlistPageModel : PageModel
	{
		private readonly ISetlistService _SetlistService;

		public SetlistPageModel(ISetlistService SetlistService)
		{
			_SetlistService = SetlistService;
		}

		[BindProperty]
		public int PageIndex { get; set; } = 0;
		[BindProperty]
		public int PageSize { get; set; } = 10;

		public List<SetlistDTO> SetlistPage { get; set; }

		public IActionResult OnGet()
		{
			if (!int.TryParse(Request.Query["page"], out int page))
			{
				page = 0;
			}

			PageIndex = page;
			LoadSetlists();

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
			LoadSetlists();
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
			LoadSetlists();
			return PageIndex;
		}

		public IActionResult OnPostDelete(int SetlistId)
		{
			_SetlistService.RemoveSetlist(SetlistId);
			LoadSetlists();
			return Page();
		}

		private void LoadSetlists()
		{
			SetlistPage = _SetlistService.GetSetlistPage(PageIndex, PageSize);
		}
	}
}