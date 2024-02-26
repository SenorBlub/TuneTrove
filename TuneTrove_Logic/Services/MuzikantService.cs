using TuneTrove_Logic.DAL_Interfaces;
using TuneTrove_Logic.Models;
using TuneTrove_Logic.Presentation_Interfaces;

namespace TuneTrove_Logic.Services;

public class MuzikantService : IMuzikantService
{
    private IMuzikantRepository _repository;
    public List<Muzikant> GetAllMuzikanten()
    {
        List<Muzikant> MuzikantList = new List<Muzikant>();
        foreach (MuzikantDTO muzikantDto in _repository.GetAllMuzikanten())
        {
            MuzikantList.Add(new Muzikant(muzikantDto));
        }
        return MuzikantList;
    }

    public Muzikant GetMuzikantById(int id)
    {
        return new Muzikant(_repository.GetMuzikantById(id));
    }

    public void PostMuzikant(Muzikant muzikant)
    {
        _repository.PostMuzikant(new MuzikantDTO(muzikant));
    }

    public void RemoveMuzikant(int id)
    {
        _repository.RemoveMuzikant(id);
    }

    public void EditMuzikant(Muzikant muzikant)
    {
        _repository.EditMuzikant(new MuzikantDTO(muzikant));
    }

    public List<Muzikant> SearchMuzikant(string query)
    {
        List<Muzikant> MuzikantList = new List<Muzikant>();
        foreach (MuzikantDTO muzikantDto in _repository.SearchMuzikant(query))
        {
            MuzikantList.Add(new Muzikant(muzikantDto));
        }
        return MuzikantList;
    }
}