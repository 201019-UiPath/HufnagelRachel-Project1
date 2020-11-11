using lacrosseDB.Models;

namespace lacrosseDB.Repos
{
    public interface ICartRepo
    {
         void AddCart(Cart cart);
         void UpdateCart(Cart cart);
         Cart GetCartByCartId(int cartId);
         Cart GetCartByCustId(int custId);
         void DeleteCart(Cart cart);

         void SaveChanges();
    }
}