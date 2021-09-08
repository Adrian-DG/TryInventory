using API.Interfaces;
using API.Models;

namespace API.Controllers
{
    public class ProductsController : GenericController<Product>
    {
        public ProductsController(IUnitOfWork<Product> unitOfWork) : base(unitOfWork)
        {
        }
    }
}