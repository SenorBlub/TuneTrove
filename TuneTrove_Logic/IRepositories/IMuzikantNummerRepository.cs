namespace TuneTrove_Logic.IRepositories;

public interface IMuzikantNummerRepository
{
    public void ConnectMuzikantToNummer(int muzikantId, int nummerId);
    public void ConnectMuzikantenToNummer(List<int> muzikantIds, int nummerId);
    public void ConnectMuzikantToNummers(int muzikantId, List<int> nummerIds);
    public void DisconnectMuzikantFromNummer(int muzikantId, int nummerId);
    public void DisconnectMuzikantenFromNummer(List<int> muzikantIds, int nummerId);
    public void DisconnectMuzikantFromNummers(int muzikantId, List<int> nummerIds);
    public void DisconnectAllFromMuzikant(int muzikantId);
    public void DisconnectFromAllMuzikanten(int nummerId);
}