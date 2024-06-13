using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.IRepositories;

public interface INummerRepository
{
    public List<Nummer> GetAllNummers();
    public List<Nummer> GetNummerPage(int pageNum, int pageSize);
    public Nummer GetNummer(int id);
    public List<Nummer> GetNummersByMuzikantId(int muzikantId);
    public List<Nummer> GetNummersBySetlistId(int setlistId);
    public void UpdateNummer(Nummer newNummer, int nummerId);
    public void DeleteNummer(int id);
    public void AddNummer(Nummer newNummer);
}