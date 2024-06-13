using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.IServices;

public interface IBandService
{
    public void AddBand(BandDTO band);
    public void RemoveBand(int bandId);
    public void RemoveBand(Band band);
    public void RemoveBand(BandDTO band); 
    public void UpdateBand(BandDTO band);
    public void UpdateBand(Band band);
    public BandDTO GetBand(int bandId);
    public List<BandDTO> GetAllBands();
    public List<BandDTO> GetBandPage(int pageSize, int pageNum);
}