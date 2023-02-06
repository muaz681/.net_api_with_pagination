using FinalApi.Data;
using FinalApi.Pagination.Filter;
using FinalApi.Pagination.Helper;
using FinalApi.Models;
using FinalApi.Pagination.Services.CService;
using FinalApi.Pagination.Services.IService;
using FinalApi.Pagination.Wrapper;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;

namespace FinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly AdventureWorks2019Context _dbContext;
        private readonly IUriService uriService;
        public PersonController(AdventureWorks2019Context dbContext, IUriService uriService)
        {
            _dbContext = dbContext;
            this.uriService = uriService;
        }
        DataTable dt = new DataTable();


        [HttpGet]
        public async Task<IActionResult> GetPerson([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _dbContext.People
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
            var totalRecords = await _dbContext.People.CountAsync();
            var pagedReponse = PaginationHelper.CreatePagedReponse<Person>(pagedData, validFilter, totalRecords, uriService, route);
            return Ok(pagedReponse);

            //var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            //var pagedData = await _dbContext.People
            //    .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            //    .Take(validFilter.PageSize)
            //    .ToListAsync();
            //var totalRecords = await _dbContext.People.CountAsync();
            //return Ok(new PagedResponse<List<Person>>(pagedData, validFilter.PageNumber, validFilter.PageSize));

            //var person = await _dbContext.People.ToListAsync();
            //return Ok(person);
            //return Ok(await _dbContext.People.ToListAsync());

            
        }

        //[HttpGet("GetData")]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        var persons = _dbContext.People.ToList();
        //        if(persons.Count == 0)
        //        {
        //            return StatusCode(400, "No user found");
        //        }
        //        return Ok(persons);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "An error has occured");
        //    }
        //}

        
    }
}
