using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practical_Test_Jaydatt.Models;

namespace Practical_Test_Jaydatt.Service
{        
    public class ItemService : IItemService
    {
        ShopBridgeContext _context;

        public ItemService(ShopBridgeContext context)
        {
            _context = context;
        }

        //public IEnumerable<Item> GetAll()
        //{
        //    return _context.Items;
        //}

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task UpdateItem(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteItem(int? Id)
        {
            int result = 0;
            if(_context != null)
            {
                var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == Id);

                if(item != null)
                {
                    _context.Remove(item);
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<int> AddItem(Item item)
        {
            if(_context != null)
            {
                await _context.Items.AddAsync(item);
                await _context.SaveChangesAsync();

                return item.Id;
            }
            return 0;
        }        
    }
}
