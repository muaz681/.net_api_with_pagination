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
using FinalApi.Helper;
using FinalApi.IServices.IPerson;
using FinalApi.DTO;

namespace FinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly AdventureWorks2019Context _dbContext;
        private readonly IPersonService _personService;
        private MessageStatus _messageStatus;
        private readonly IUriService uriService;
        public PersonController(AdventureWorks2019Context dbContext, IUriService uriService, IPersonService personService)
        {
            _dbContext = dbContext;
            _personService = personService;
            this.uriService = uriService;
            
        }
        DataTable dt = new DataTable();

        //Read Data

        [HttpGet]
        [Route("person")]
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


        //Data Create

        [HttpPost]
        [Route("create")]
        
        public async Task<MessageStatus> createPerson(
            int bussinessID, string personType, bool nameType, string title, string firstName, string middleName, string lastName, string suffix, int mailPromotion, Guid rowguid)
        {
            try
            {
                var result = _personService.createPerson(bussinessID, personType, nameType, title, firstName, middleName, lastName, suffix, mailPromotion, rowguid);
                _messageStatus = new MessageStatus()
                {
                    Data = result,
                    Status = true,
                    Code = 200,
                    Message = "Successful"
                };
            }
            catch(Exception ex)
            {
                _messageStatus = new MessageStatus()
                {
                    Data = null,
                    Status = false,
                    Code = 200,
                    Message = "Failed"
                };
            }
            return _messageStatus;
        }

        [HttpGet]
        [Route("GetMail")]
        
        public async Task<IActionResult> GetEmail([FromQuery] PaginationFilter filter, int emailPromotionID)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _dbContext.People
                .Where(Person => Person.EmailPromotion == emailPromotionID)
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
            var totalRecords = await _dbContext.People.Where(Person => Person.EmailPromotion == emailPromotionID).CountAsync();
            var pagedReponse = PaginationHelper.CreatePagedReponse<Person>(pagedData, validFilter, totalRecords, uriService, route);
            return Ok(pagedReponse);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdatePerson([FromBody] PersonDTO personDto)
        {
            try
            {
                var dt = await _personService.UpdatePerson(personDto);
                if (dt == null)
                {
                    return NotFound();
                }
                return Ok(dt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //public async Task<IActionResult> UpdatePerson(int id, Person person)
        //{
        //    if (id != person.BusinessEntityId)
        //    {
        //        return BadRequest();
        //    }

        //    _dbContext.Entry(person).State = EntityState.Modified;

        //    try
        //    {
        //        await _dbContext.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (person == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        //public async Task<MessageStatus> UpdatePerson(PersonDTO personDTO
        //    //int bussinessID, string personType, bool nameType, string title, string firstName, string middleName, string lastName, string suffix, int mailPromotion, Guid rowguid
        //    )
        //{
        //    try
        //    {
        //        var result = await _personService.UpdatePerson( personDTO
        //            //bussinessID, personType, nameType, title, firstName, middleName, lastName, suffix, mailPromotion, rowguid
        //            );
        //        _messageStatus = new MessageStatus()
        //        {
        //            Data = result,
        //            Status = true,
        //            Code = 200,
        //            Message = "Successful"
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        _messageStatus = new MessageStatus()
        //        {
        //            Data = null,
        //            Status = true,
        //            Code = 200,
        //            Message = "Successful"
        //        };
        //    }
        //    return _messageStatus;
        //}

        //Edit
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Person>> GetEdit(int id)
        {
            var people = await _dbContext.People.FindAsync(id);

            if (people == null)
            {
                return NotFound();
            }

            return people;
        }


        //public IEnumerable<Person> GetEdit(int bussinessID)
        //{
        //    var res = from p in _dbContext.People where p.BusinessEntityId == bussinessID select p;
        //    return res;
        //}

    }
}
