using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseDB.Repos
{
    public interface ICartItemsRepo
    {
         void AddCartItem(CartItem cartItem);
         void UpdateCartItem (CartItem cartItem);
         CartItem GetCartItemByCartItemId(int cartItemId);
         CartItem GetCartItemByCartId(int cartId);
         CartItem GetCartItemByCustId(int custId);
         List<CartItem> GetAllCartItemsByCartId(int cartId);
         void DeleteCartItem(CartItem cartItem);

         void SaveChanges();
    }
}