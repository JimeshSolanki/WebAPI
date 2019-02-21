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
        [HttpGet]
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

        [HttpPost]
        [Route("api/Product/Details")]
        public virtual Response GetProductDetails(Request request)
        {
            Response response = null;
            string Message = null;
            var Count = 0;

            if (IsValidId(request.Id))
            {
                var Id = request.Id;

                EntityMapper<DataLayer.Product, Models.Product> mapper = new EntityMapper<DataLayer.Product, Models.Product>();
                DataLayer.Product dalProduct = DAL.GetProduct(ToInt(Id));
                Models.Product product = new Models.Product();
                product = mapper.Translate(dalProduct);

                if (product != null)
                {
                    Message = Config.RECORD_FOUND_MESSAGE;
                    Count = 1;
                    response = BuildResponse(Config.SUCESS, Count, Message, product, null);
                }
                else
                {
                    Message = Config.RECORD_FOUND_MESSAGE;
                    response = BuildResponse(Config.SUCESS, Count, Message, null, null);
                }
            }
            else
            {
                Message = Config.INVALID_ID_MESSAGE;
                response = BuildResponse(Config.SUCESS, Count, Message, null, null);
            }
            return response;
        }

        [HttpPost]
        [Route("api/Product/Add")]
        public Response InsertProduct(Models.Product product)
        {
            Response response = null;
            string Message = null;
            var Count = 0;

            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<Models.Product, DataLayer.Product> mapObj = new EntityMapper<Models.Product, DataLayer.Product>();
                DataLayer.Product productObj = new DataLayer.Product();
                productObj = mapObj.Translate(product);
                status = DAL.InsertProduct(productObj);
            }

            if (status)
            {
                Message = Config.INSERT_MESSAGE;
                Count = 1;
                response = BuildResponse(Config.SUCESS, Count, Message, null, null);
            }
            else
            {
                Message = Config.INVALID_PARAMETER_MESSAGE;
                response = BuildResponse(Config.FAILED, Count, Message, null, null);
            }
            return response;
        }

        [HttpPut]
        [Route("api/Product/Update")]
        public Response UpdateProduct(Models.Product product)
        {
            Response response = null;
            string Message = null;
            var Count = 0;

            EntityMapper<Models.Product, DataLayer.Product> mapObj = new EntityMapper<Models.Product, DataLayer.Product>();
            DataLayer.Product productObj = new DataLayer.Product();
            productObj = mapObj.Translate(product);
            var status = DAL.UpdateProduct(productObj);
            if (status)
            {
                Message = Config.UPDATE_MESSAGE;
                Count = 1;
                response = BuildResponse(Config.SUCESS, Count, Message, null, null);
            }
            else
            {
                Message = Config.INVALID_PARAMETER_MESSAGE;
                response = BuildResponse(Config.FAILED, Count, Message, null, null);
            }
            return response;
        }

        [HttpDelete]
        [Route("api/Product/Delete")]
        public Response DeleteProduct(int id)
        {
            Response response = null;
            string Message = null;
            var Count = 0;

            var status = DAL.DeleteProduct(id);

            if (status)
            {
                Message = Config.DELETE_MESSAGE;
                Count = 1;
                response = BuildResponse(Config.SUCESS, Count, Message, null, null);
            }
            else
            {
                Message = Config.INVALID_PARAMETER_MESSAGE;
                response = BuildResponse(Config.FAILED, Count, Message, null, null);
            }
            return response;
        }
    }
}
