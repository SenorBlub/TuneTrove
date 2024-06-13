using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.IRepositories;

public interface IBandRepository
{
    public List<Band> GetAllBands();
    public List<Band> GetBandPage(int pageNum, int pageSize);
    public Band GetBand(int bandId);
    public List<Band> GetBandsByMuzikantId(int muzikantId);
    public List<Band> GetBandsBySetlistId(int setlistId);
    public void UpdateBand(Band newBand, int bandId);
    public void DeleteBand(int bandId);
    public void AddBand(Band newBand);
}