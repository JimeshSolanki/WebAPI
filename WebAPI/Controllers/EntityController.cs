using DataLayer;
using System.Collections.Generic;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Repository;
using WebAPI.Util;

namespace WebAPI.Controllers
{
    public class EntityController : BaseController
    {
        [HttpPost]
        [Route("api/Product/List")]
        public virtual Response GetAllProduct()
        {
            Response response = null;
            string Message = null;
            int Count = 0;

            EntityMapper<DataLayer.Product, Models.Product> mapper =
                new EntityMapper<DataLayer.Product, Models.Product>();

            List<DataLayer.Product> prodList = DAL.GetAllProducts();
            List<Models.Product> products = new List<Models.Product>();

            foreach (var item in prodList)
            {
                products.Add(mapper.Translate(item));
            }

            if (products.Count > 0)
            {
                Message = Config.RECORD_FOUND_MESSAGE;
                Count = products.Count;
                response = BuildResponse(Config.SUCESS, Count, Message, products, null);
            }
            else
            {
                Message = Config.RECORD_NOT_FOUND_MESSAGE;
                response = BuildResponse(Config.FAILED, Count, Message, null, null);
            }
            return response;
        }
    }
}
