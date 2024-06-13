namespace TuneTrove_Logic.IRepositories;

public interface IMuzikantSetlistRepository
{
    public void ConnectMuzikantToSetlist(int muzikantId, int setlistId);
    public void ConnectMuzikantenToSetlist(List<int> muzikantIds, int setlistId);
    public void ConnectMuzikantToSetlists(int muzikantId, List<int> setlistIds);
    public void DisconnectMuzikantFromSetlist(int muzikantId, int setlistId);
    public void DisconnectMuzikantenFromSetlist(List<int> muzikantIds, int setlistId);
    public void DisconnectMuzikantFromSetlists(int muzikantId, List<int> setlistIds);
    public void DisconnectAllFromMuzikant(int muzikantId);
    public void DisconnectFromAllMuzikanten(int setlistId);
}