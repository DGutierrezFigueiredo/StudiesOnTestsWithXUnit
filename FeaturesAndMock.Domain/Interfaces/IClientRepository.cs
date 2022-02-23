using FeaturesAndMock.Domain.Entities;
using FeaturesAndMock.Infrastructure;

namespace FeaturesAndMock.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Client GetByEmail(string email);
    }
}
