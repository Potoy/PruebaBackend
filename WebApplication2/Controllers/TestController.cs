using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        // GET /api/Test/time?value=
        [Route("time")]
        public HttpResponseMessage GetTime([FromUri] string value)
        {
            if(value == "hora")
            {
                JsonTimeDataResponseModel realtime = new JsonTimeDataResponseModel
                {
                    code = "00",
                    description = "OK",
                    data = "UTC ISO DATE"
                };
                return Request.CreateResponse<JsonTimeDataResponseModel>(System.Net.HttpStatusCode.Created, realtime);
            }
            else if( value != "hora")
            {
                JsonTimeDataResponseModel badtime = new JsonTimeDataResponseModel
                {
                    code ="00",
                    description = "400",
                    data = ""
                };
                return Request.CreateResponse<JsonTimeDataResponseModel>(HttpStatusCode.BadRequest, badtime);
            }
            else
            {
                JsonTimeDataResponseModel internalerror = new JsonTimeDataResponseModel
                {
                    code = "00",
                    description = "500",
                    data = ""
                };
                return Request.CreateResponse<JsonTimeDataResponseModel>(HttpStatusCode.InternalServerError, internalerror);

            }

        }

        //POST /api/Test/word
        [Route("word")]
        public HttpResponseMessage PostData(JsonDataModel word)
        {
            int number;
            if(word.Equals(null))
            {
                JsonDataResponseModel internalserver = new JsonDataResponseModel
                {
                    code = "00",
                    description = "500",
                    data = ""
                };
                return Request.CreateResponse<JsonDataResponseModel>(HttpStatusCode.InternalServerError, internalserver);
            }

            bool isNumber = int.TryParse(word.data.ToString(),out number);
            if (isNumber)
            {
                JsonDataResponseModel badresponse = new JsonDataResponseModel
                {
                    code = "00",
                    description = "400",
                    data = ""
                };
                return Request.CreateResponse<JsonDataResponseModel>(HttpStatusCode.BadRequest, badresponse);
            }

            JsonDataResponseModel value = new JsonDataResponseModel
            {
                code = "00",
                description = "OK",
                data = word.data.ToUpper()
            };
            return Request.CreateResponse<JsonDataResponseModel>(System.Net.HttpStatusCode.Created, value);
           
        }

    }
}
