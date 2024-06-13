namespace TuneTrove_Logic.IRepositories;

public interface INummerSetlistRepository
{
    public void ConnectNummerToSetlist(int nummerId, int setlistId);
    public void ConnectNummersToSetlist(List<int> nummerIds, int setlistId);
    public void ConnectNummerToSetlists(int nummerId, List<int> setlistIds);
    public void DisconnectNummerFromSetlist(int nummerId, int setlistId);
    public void DisconnectNummersFromSetlist(List<int> nummerIds, int setlistId);
    public void DisconnectNummerFromSetlists(int nummerId, List<int> setlistIds);
    public void DisconnectAllFromNummer(int nummerId);
    public void DisconnectFromAllNummers(int setlistId);
}