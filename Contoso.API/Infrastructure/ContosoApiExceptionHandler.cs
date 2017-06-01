using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Contoso.API.Infrastructure
{
    /*
     there are a number of cases that exception filters can't handle. For example:
        Exceptions thrown from controller constructors.
        Exceptions thrown from message handlers.
        Exceptions thrown during routing.
        Exceptions thrown during response content serialization .
      */
    public class ContosoApiExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context.Exception is ArgumentNullException)
            {
                var result = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "ArgumentNullException"
                };

                context.Result = new ArgumentNullResult(context.Request, result);
            }
        }
    }

    public class ArgumentNullResult : IHttpActionResult
    {
        private readonly HttpResponseMessage _httpResponseMessage;
        private HttpRequestMessage _request;


        public ArgumentNullResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
        {
            _request = request;
            _httpResponseMessage = httpResponseMessage;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_httpResponseMessage);
        }
    }
}