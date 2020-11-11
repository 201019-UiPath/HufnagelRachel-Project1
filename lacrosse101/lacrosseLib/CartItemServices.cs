using System.Collections.Generic;
using lacrosseDB.Models;
using lacrosseDB.Repos;

namespace lacrosseLib
{
    public class CartItemServices
    {
        private ICartItemsRepo repo;

        public CartItemServices(ICartItemsRepo repo)
        {
            this.repo = repo;
        }

        public void AddCartItem(CartItem cartItem)
        {
            repo.AddCartItem(cartItem);
        }

        public void UpdateCartItem(CartItem cartItem) 
        {
            repo.UpdateCartItem(cartItem);
        }

        public CartItem GetCartItemByCartItemId(int cartItemId)
        {
            CartItem cartItem = repo.GetCartItemByCartItemId(cartItemId);
            return cartItem;
        }

        public CartItem GetCartItemByCartId(int cartId)
        {
            CartItem cartItem = repo.GetCartItemByCartId(cartId);
            return cartItem;
        }

        public CartItem GetCartItemByCustId(int custId) 
        {
            CartItem cartItem = repo.GetCartItemByCustId(custId);
            return cartItem;
        }

        public List<CartItem> GetAllCartItemsByCartId(int cartId)
        {
            List<CartItem> cartItems = repo.GetAllCartItemsByCartId(cartId);
            return cartItems;
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            repo.DeleteCartItem(cartItem);
        }
    }
}