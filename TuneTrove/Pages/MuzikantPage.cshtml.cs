using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.IServices;

namespace TuneTrove_presentation.Pages
{
    public class MuzikantPageModel : PageModel
    {
        private readonly IMuzikantService _muzikantService;

        public MuzikantPageModel(IMuzikantService muzikantService)
        {
            _muzikantService = muzikantService;
        }
        public List<MuzikantDTO> MuzikantPage { get; set; }

        [BindProperty]
        public int PageIndex { get; set; } = 0;
        [BindProperty]
        public int PageSize { get; set; } = 10;

        public IActionResult OnGet()
        {
            if (!int.TryParse(Request.Query["page"], out int page))
            {
                page = 0;
            }

            PageIndex = page;
            LoadMuzikanten();

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
            LoadMuzikanten();
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
            LoadMuzikanten();
            return PageIndex;
        }

        public IActionResult OnPostDelete(int muzikantId)
        {
            _muzikantService.RemoveMuzikant(muzikantId);
            LoadMuzikanten();
            return Page();
        }

        private void LoadMuzikanten()
        {
            MuzikantPage = _muzikantService.GetMuzikantPage(PageIndex, PageSize);
        }
    }
}
