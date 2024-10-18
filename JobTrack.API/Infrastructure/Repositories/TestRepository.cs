using Domain.IRepositories;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class TestRepository : ITestRepository
{
    private readonly ApplicationDbContext _context;

    public TestRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Create(Test entity)
    {
        _context.Tests.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var test =  _context.Tests.Find(id);
        if (test != null)
        {
            _context.Tests.Remove(test); 
            _context.SaveChangesAsync();
        }
    }

    public Test Get(Guid id)
    {
        return  _context.Tests.Find(id);
    }

    public List<Test> GetAll()
    {
        return  _context.Tests.ToList();
    }

    public void Update(Test entity)
    {
        _context.Tests.Update(entity);
        _context.SaveChangesAsync();
    }
}