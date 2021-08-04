using System;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SuppliersController : BaseController
    {
        private IUnitOfWork<Supplier> _uof;
        private IGenericRepository<Supplier> _repo;

        public SuppliersController(IUnitOfWork<Supplier> unitOfWork)
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

        [HttpPost("create")]
        public async Task<ActionResult> Create(Supplier model)
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

        [HttpPut("edit/{id}")]
        public async Task<ActionResult> Update(Supplier model)
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