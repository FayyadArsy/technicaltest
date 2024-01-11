using FayyadTechnicalBackend.Context;
using FayyadTechnicalBackend.Models;
using FayyadTechnicalBackend.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FayyadTechnicalBackend.Repository
{
    public class CartRepository
    {
        private readonly MyContext context;
        public CartRepository(MyContext context)
        {
            this.context = context;
        }
        public IEnumerable<Cart> Get()
        {
           return context.Cart
            .Include(cart => cart.Items)
            .ToList();
        }
        public int Insert(ViewModel.CartVm TransactionItems)
        {
            var insert = new Models.Cart
            {
                ItemsId = TransactionItems.ItemsId,
                Quantity = TransactionItems.Quantity,
                TransactionId = TransactionItems.TransactionId,

            };
            context.Cart.Add(insert);
            var setcart = context.SaveChanges();
            return setcart;
        }
        public int Update(Cart cart)
        {
            context.Entry(cart).State = EntityState.Modified;
            var result = context.SaveChanges();
            return result;
        }
        public int Delete(int Id)
        {
            var findData = context.Cart.Find(Id);
            if (findData != null)
            {
                context.Cart.Remove(findData);
            }
            var save = context.SaveChanges();
            return save;
        }
        public Cart Get(int Id)
        {
            return context.Cart
            .Include(cart => cart.Items) 
            .FirstOrDefault(cart => cart.CartId == Id);
        }
        
    }
}
