using API.Data;
using API.Models;
using API.Interfaces;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.DTO;

namespace API.Controllers
{
    public class CategoriesController : BaseController
    {
        private IUnitOfWork<Category> _uof;
        private IGenericRepository<Category> _repo;

        public CategoriesController(IUnitOfWork<Category> unitOfWork)
        {
            _uof = unitOfWork;
            _repo = _uof.Repository;
        }

       [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] QueryParams parameters)
        {
            try 
            {
                return  new JsonResult(await _repo.GetAll(parameters));
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
        public async Task<ActionResult> Create(Category model)
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
        [HttpPut("edit/{id}")]
        public async Task<ActionResult> Update(Category model)
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