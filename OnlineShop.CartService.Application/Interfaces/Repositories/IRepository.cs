namespace OnlineShop.CartService.Application.Interfaces.Repositories;

public interface IRepository<Type>
{
    void Add(Type item);
    void Remove(Type item);
}