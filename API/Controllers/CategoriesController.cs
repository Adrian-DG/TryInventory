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
    public class CategoriesController : GenericController<Category>
    {
        public CategoriesController(IUnitOfWork<Category> unitOfWork) : base(unitOfWork)
        {
        }
    }
}