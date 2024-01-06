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
        public async Task<IActionResult> CreateBook(BookRequestBody dto)
        {
            return await HandleServiceCall(async () => await _service.CreateBook(dto));
        }

        [HttpGet("all")]
        public async Task<IActionResult> FindAllBooks(int pageNumber, int pageSize)
        {
            return await HandleServiceCall(async () => await _service.FindAllBooks(pageNumber, pageSize));
        }

        [HttpGet("search")]
        public async Task<IActionResult> FindBooks(string bookTitle)
        {
            return await HandleServiceCall(async () => await _service.FindBooks(bookTitle));
        }

        [HttpGet]
        public async Task<IActionResult> FindOneBook(string bookIsbn)
        {
            return await HandleServiceCall(async () => await _service.FindOneBook(bookIsbn));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(string bookIsbn, BookRequestBody dto)
        {
            return await HandleServiceCall(async () => await _service.UpdateBook(bookIsbn, dto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(string bookIsbn)
        {
            return await HandleServiceCall(async () => await _service.DeleteBook(bookIsbn));
        }
    }
}