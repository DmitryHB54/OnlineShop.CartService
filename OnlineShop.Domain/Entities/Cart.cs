namespace OnlineShop.CartService.Domain.Entities;

public class Cart
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private readonly List<CartItem> _items = [];
    public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

    private Cart() {}

    public Cart(Guid userId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
    }

    public (CartItem Item, bool IsNew) AddItem(Guid productId, string productName, decimal unitPrice, int quantity)
    {
        var existingItem 
            = _items.FirstOrDefault(i => i.ProductId == productId);

        if(existingItem != null)
        {
            existingItem.UpdateQuantity(quantity);
            return (existingItem, false);
        }

        var newItem = new CartItem(Id, productId, productName, unitPrice, quantity);
        _items.Add(newItem);
 
        UpdatedAt = DateTime.UtcNow;

        return (newItem, true);
    }

    public void RemoveItem(Guid productId)
    {
        var item =
            _items.FirstOrDefault(i => i.ProductId == productId);

        if(item != null)
        {
            _items.Remove(item);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}