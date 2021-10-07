using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practical_Test_Jaydatt.Models;
using Practical_Test_Jaydatt.Service;

namespace Practical_Test_Jaydatt.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly ShopBridgeContext _context;

        private readonly IItemService _service;



        public ItemsController(IItemService service)
        {
            _service = service;
        }

        //public IEnumerable<Item> GetAllItem()
        //{
        //    return _service.GetAll();
        //}

        [HttpGet]
        [Route("GetAllItem")]
        public async Task<IActionResult> GetAllItem()
        {
            var data = await _service.GetAll();           
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateItem")]
        public async Task<IActionResult> UpdateItem([FromBody] Item item)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateItem(item);
                    return Ok();
                }
                catch(Exception ex)
                {
                    if(ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            return BadRequest();
        }

       [HttpDelete]        
       [Route("DeleteItem")]
       public async Task<IActionResult> DeleteItem(int? Id)
        {
            int result = 0;
            if(Id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _service.DeleteItem(Id);
                if(result == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok();
                }
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
        
        [HttpPost]
        [Route("AddItem")]
        public async Task<IActionResult> AddItem([FromBody]Item item)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var ItemId = await _service.AddItem(item);
                    if(ItemId > 0)
                    {
                        return Ok(ItemId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch(Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
