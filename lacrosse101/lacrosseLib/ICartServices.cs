using lacrosseDB.Models;

namespace lacrosseLib
{
    public interface ICartServices
    {
        void AddCart(Cart cart);
        void DeleteCart(Cart cart);
        Cart GetCartByCartId(int cartId);
        Cart GetCartByCustId(int custId);
        void UpdateCart(Cart cart);
    }
}