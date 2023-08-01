using Domain.Entities;

namespace Application.Repositries;

public interface ICustomerRepository : IAsyncRepository<Customer>
{
    Task<Customer> CheckInfo(string firstname , string lastname , DateTime birthdate);

    Task<Customer> CheckEmail(string email);
}
