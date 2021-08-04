using System;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseController
    {
        private IUnitOfWork<Product> _uof;
        private IGenericRepository<Product> _repo;

        public ProductsController(IUnitOfWork<Product> unitOfWork)
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
        public async Task<ActionResult> Create(Product model)
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
        public async Task<ActionResult> Update(Product model)
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