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
            var setemployee = context.SaveChanges();
            return setemployee;
        }
        public int Update(Models.Cart employee)
        {
            context.Entry(employee).State = EntityState.Modified;
            var result = context.SaveChanges();
            return result;
        }
    }
}
