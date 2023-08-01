using Application.Repositries;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CustomerRepository : AsyncRepository<Customer>, ICustomerRepository
{
    private readonly ApplicationDbContext _dbContext;
    public CustomerRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Customer> CheckEmail(string email)
    {
        return await GetAsync(s => s.Email == email.ToLower());
    }

    public async Task<Customer> CheckInfo(string firstname, string lastname, DateTime birthdate)
    {
        return await GetAsync(s => s.FirstName == firstname && s.LastName == lastname && s.DateOfBirth == birthdate);
    }
}
