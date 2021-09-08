using API.Interfaces;
using API.Models;

namespace API.Controllers
{
    public class SuppliersController : GenericController<Supplier>
    {
        public SuppliersController(IUnitOfWork<Supplier> unitOfWork) : base(unitOfWork)
        {
        }
    }
}