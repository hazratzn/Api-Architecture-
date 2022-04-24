using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Book;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
   
    public class BookController : BaseController
    {
        private readonly IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] BookCreateDto book)
        {
          

            await _service.CreateAsync(book);
            return Ok();
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BookEditDto book)
        {


            await _service.UpdateAsync(id,book);
            return Ok();
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> Search([FromQuery] string search)
        {


            
            return Ok(await _service.GetAllByConditionAsync(search));
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
