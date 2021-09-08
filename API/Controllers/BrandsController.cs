using API.Interfaces;
using API.Models;

namespace API.Controllers
{
    public class BrandsController : GenericController<Brand>
    {
        public BrandsController(IUnitOfWork<Brand> unitOfWork) : base(unitOfWork)
        {
        }
    }
}