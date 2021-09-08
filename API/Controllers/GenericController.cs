using System;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class GenericController<T> : ControllerBase where T : class
    {
        private IUnitOfWork<T> _uof;
        private IGenericRepository<T> _repo;
        public GenericController(IUnitOfWork<T> unitOfWork)
        {
            _uof = unitOfWork;
            _repo = _uof.Repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try 
            {
                return  new JsonResult(await _repo.GetAll());
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try 
            {
                return new JsonResult(await _repo.GetById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("create")]
        public async Task<ActionResult> Create(T model)
        {
            try 
            {
                await _repo.Insert(model);
                return  new JsonResult(await _uof.CommitChanges()); 
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut("edit")]
        public async Task<ActionResult> Update(T model)
        {
            try 
            {
                _repo.Update(model);
                return new JsonResult(await _uof.CommitChanges());
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("remove/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try 
            {
                await _repo.Delete(id);
                return new JsonResult(await _uof.CommitChanges());
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

    }
}