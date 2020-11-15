using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseLib
{
    public interface ICartItemServices
    {
        void AddCartItem(CartItem cartItem);
        void DeleteCartItem(CartItem cartItem);
        List<CartItem> GetAllCartItemsByCartId(int cartId);
        CartItem GetCartItemByCartId(int cartId);
        CartItem GetCartItemByCartItemId(int cartItemId);
        CartItem GetCartItemByCustId(int custId);
        void UpdateCartItem(CartItem cartItem);
    }
}