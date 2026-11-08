namespace OnlineShop.CartService.Domain.Entities;

public class CartItem
{
    public Guid Id { get; private set; }
    public Guid CartId { get; private set; }
    public Guid ProductId { get; private set; }
    public string ProductName { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }

    private CartItem() {}

    public CartItem(Guid cartId, Guid productId, string productName, decimal unitPrice, int quantity)
    {
        Id = Guid.NewGuid();
        CartId = cartId;
        ProductId = productId;
        ProductName = productName;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public void UpdateQuantity(int newQuantity)
    {
        if (newQuantity <= 0) 
            throw new ArgumentException("Quantity must be positive");
        Quantity = newQuantity;
    }
}