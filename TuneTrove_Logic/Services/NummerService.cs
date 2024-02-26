using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Presentation_Interfaces;

namespace TuneTrove_Logic.Services;

public class NummerService : INummerService
{
    private INummerRepository _repository;
    public List<Nummer> GetAllNummers()
    {
        List<Nummer> NummerList = new List<Nummer>();
        foreach (NummerDTO nummerDto in _repository.GetAllNummers())
        {
            NummerList.Add(new Nummer(nummerDto));
        }
        return NummerList;
    }

    public Nummer GetNummerById(int id)
    {
        return new Nummer(_repository.GetNummerById(id));
    }

    public void PostNummer(Nummer nummer)
    {
        _repository.PostNummer(new NummerDTO(nummer));
    }

    public void RemoveNummer(int id)
    {
        _repository.RemoveNummer(id);
    }

    public void EditNummer(Nummer nummer)
    {
        _repository.EditNummer(new NummerDTO(nummer));
    }

    public List<Nummer> SearchNummer(string query)
    {
        List<Nummer> NummerList = new List<Nummer>();
        foreach (NummerDTO nummerDto in _repository.SearchNummer(query))
        {
            NummerList.Add(new Nummer(nummerDto));
        }
        return NummerList;
    }
}