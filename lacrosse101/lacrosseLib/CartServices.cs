using lacrosseDB.Models;
using lacrosseDB.Repos;

namespace lacrosseLib
{
    public class CartServices : ICartServices
    {
        private ICartRepo repo;

        public CartServices(ICartRepo repo)
        {
            this.repo = repo;
        }

        public void AddCart(Cart cart)
        {
            repo.AddCart(cart);
        }

        public void UpdateCart(Cart cart)
        {
            repo.UpdateCart(cart);
        }

        public Cart GetCartByCartId(int cartId)
        {
            Cart cart = repo.GetCartByCartId(cartId);
            return cart;
        }

        public Cart GetCartByCustId(int custId)
        {
            Cart cart = repo.GetCartByCustId(custId);
            return cart;
        }

        public void DeleteCart(Cart cart)
        {
            repo.DeleteCart(cart);
        }
    }
}