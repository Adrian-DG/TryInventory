using System;
using System.Threading.Tasks;
using API.DTO;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : GenericController<Product>
    {
        public ProductsController(IUnitOfWork<Product> unitOfWork) : base(unitOfWork)
        {
        }
    }
}