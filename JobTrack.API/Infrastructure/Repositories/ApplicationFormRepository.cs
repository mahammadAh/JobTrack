using Domain.IRepositories;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ApplicationFormRepository : IApplicationFormRepository
{
      
    private readonly ApplicationDbContext _context;

    public ApplicationFormRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Create(ApplicationForm entity)
    {
        _context.ApplicationForms.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var applicationForm =  _context.ApplicationForms.Find(id);
        if (applicationForm != null)
        {
            _context.ApplicationForms.Remove(applicationForm); 
            _context.SaveChangesAsync();
        }
    }

    public ApplicationForm Get(Guid id)
    {
        return  _context.ApplicationForms.Find(id);
    }

    public List<ApplicationForm> GetAll()
    {
        return  _context.ApplicationForms.ToList();
    }

    public void Update(ApplicationForm entity)
    {
        _context.ApplicationForms.Update(entity);
        _context.SaveChangesAsync();
    }
}