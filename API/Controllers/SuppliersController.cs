using System;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SuppliersController : GenericController<Supplier>
    {
        public SuppliersController(IUnitOfWork<Supplier> unitOfWork) : base(unitOfWork)
        {
        }
    }
}