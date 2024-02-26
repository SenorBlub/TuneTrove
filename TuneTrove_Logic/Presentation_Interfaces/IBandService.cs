using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.Presentation_Interfaces;

public interface IBandService
{
    List<Band> GetAllBands();
    Band GetBandById(int id);
    void PostBand(Band band);
    void RemoveBand(int id);
    void EditBand(Band band);
}