using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practical_Test_Jaydatt.Models;

namespace Practical_Test_Jaydatt.Service
{
    public interface IItemService
    {
        //IEnumerable<Item> GetAll();
        Task<IEnumerable<Item>> GetAll();

        Task UpdateItem(Item item);

        Task<int> DeleteItem(int? Id);

        Task<int> AddItem(Item item);
    }
}
