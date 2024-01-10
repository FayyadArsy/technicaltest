using FayyadTechnicalBackend.Context;
using FayyadTechnicalBackend.Models;
using FayyadTechnicalBackend.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace FayyadTechnicalBackend.Repository
{
    public class ItemsRepository
    {
        private readonly MyContext context;
        public ItemsRepository(MyContext context)
        {
            this.context = context;
        }
        public IEnumerable<Items> Get()
        {
            return context.Items.ToList();
        }
        public int Insert(ItemsVM item)
        {
            var insert = new Items
            {
              Name = item.Name,
              Quantity = item.Quantity,
              Price = item.Price
            };
            context.Items.Add(insert);
            var setItem = context.SaveChanges();
            return setItem;
        }
        public int Update(Items item)
        {
            context.Entry(item).State = EntityState.Modified;
            var result = context.SaveChanges();
            return result;
        }
    }
}
