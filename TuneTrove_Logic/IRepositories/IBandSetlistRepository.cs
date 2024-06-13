namespace TuneTrove_Logic.IRepositories;

public interface IBandSetlistRepository
{
    public void ConnectBandToSetlist(int bandId, int setlistId);
    public void ConnectBandsToSetlist(List<int> bandIds, int setlistId);
    public void ConnectBandToSetlists(int bandId, List<int> setlistIds);
    public void DisconnectBandFromSetlist(int bandId, int setlistId);
    public void DisconnectBandsFromSetlist(List<int> bandIds, int setlistId);
    public void DisconnectBandFromSetlists(int bandId, List<int> setlistIds);
    public void DisconnectAllFromBand(int bandId);
    public void DisconnectFromAllBands(int setlistId);
}