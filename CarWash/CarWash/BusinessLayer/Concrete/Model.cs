using System.Net;

namespace BusinessLayer.Concrete
{
    public class Model
    {
        public HttpStatusCode Status { get; set; }
        public string StatuMessage { get; set; }
        public object models { get; set; }

    }
}
