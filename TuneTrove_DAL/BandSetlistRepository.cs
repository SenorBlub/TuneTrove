using TuneTrove_Logic.DAL_Interfaces;

namespace TuneTrove_DAL;

public class BandSetlistRepository : IBandSetlistRepository
{
    public List<int> GetBands(int setlistId)
    {
        throw new NotImplementedException();
    }

    public List<int> GetSetlists(int bandId)
    {
        throw new NotImplementedException();
    }

    public void PostConnection(int setlistId, int bandId)
    {
        throw new NotImplementedException();
    }

    public void RemoveConnection(int setlistId, int bandId)
    {
        throw new NotImplementedException();
    }
}