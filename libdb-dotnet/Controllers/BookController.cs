﻿using libdb_dotnet.DTOs;
using libdb_dotnet.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace libdb_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController(IBookService service) : CoreController
    {
        private readonly IBookService _service = service;

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookCreateBody requestBody)
        {
            return await HandleServiceCall(async () => await _service.CreateBook(requestBody));
        }

        [HttpGet("all")]
        public async Task<IActionResult> FindAllBooks(int pageNumber, int pageSize)
        {
            return await HandleServiceCall(async () => await _service.FindAllBooks(pageNumber, pageSize));
        }

        [HttpGet("search")]
        public async Task<IActionResult> FindBooks(string title)
        {
            return await HandleServiceCall(async () => await _service.FindBooks(title));
        }

        [HttpGet]
        public async Task<IActionResult> FindOneBook(int id)
        {
            return await HandleServiceCall(async () => await _service.FindOneBook(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookUpdateBody requestBody)
        {
            return await HandleServiceCall(async () => await _service.UpdateBook(requestBody));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return await HandleServiceCall(async () => await _service.DeleteBook(id));
        }
    }
}