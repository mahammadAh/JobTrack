using Domain.IRepositories;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class VacancyRepository : IVacancyRepository
{
    
    private readonly ApplicationDbContext _context;

    public VacancyRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Create(Vacancy entity)
    {
        _context.Vacancies.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var vacancy =  _context.Vacancies.Find(id);
        if (vacancy != null)
        {
            _context.Vacancies.Remove(vacancy); 
            _context.SaveChangesAsync();
        }
    }

    public Vacancy Get(Guid id)
    {
        return  _context.Vacancies.Find(id);
    }

    public List<Vacancy> GetAll()
    {
        return  _context.Vacancies.ToList();
    }

    public void Update(Vacancy entity)
    {
        _context.Vacancies.Update(entity);
         _context.SaveChangesAsync();
    }
}