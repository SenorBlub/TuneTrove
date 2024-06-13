using TuneTrove_Logic.DTOs;
using TuneTrove_Logic.Models;

namespace TuneTrove_Logic.IServices;

public interface INummerService
{
    public void AddNummer(NummerDTO nummer);
    public void RemoveNummer(int id);
    public void RemoveNummer(Nummer nummer);
    public void RemoveNummer(NummerDTO nummer);
    public void UpdateNummer(Nummer nummer);
    public void UpdateNummer(NummerDTO nummer);
    public NummerDTO GetNummer(int id);
    public List<NummerDTO> GetAllNummers();
    public List<NummerDTO> GetNummerPage(int pageSize, int pageNum);

}