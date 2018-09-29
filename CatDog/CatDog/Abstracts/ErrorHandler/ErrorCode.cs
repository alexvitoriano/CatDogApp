using System.Net;
using static CatDog.Abstracts.AbstractServices;

namespace CatDog.Abstracts.ErrorHandler
{
    public enum ErrorCode
    {
        //Software`s Error
        DEFAULT = 0,
        JSON_CONVERTER = 1,
        INT_SERVER_ERROR = 2,

        //Server HTTPStatus Errors
        HTTP_DEFAULT = 3,
        NOT_FOUND = 4,
        CONFLICT = 5,
        PRECONDITION_FAILED = 6,
        HTTP_EXCEPTION = 7,
              

    }

    public class ErrorCodeHTTP
    {

        public static ONErrorHandler GetErrorCodeHTTP(HttpStatusCode _StatusCode, ApiMethodTypes _Method)
        {
            switch (_StatusCode)
            {
                case HttpStatusCode.PreconditionFailed:
                    return new ONErrorHandler(ErrorCode.PRECONDITION_FAILED);
                case HttpStatusCode.NotFound:
                    return new ONErrorHandler(ErrorCode.NOT_FOUND);
                case HttpStatusCode.Conflict:
                    return new ONErrorHandler(ErrorCode.CONFLICT);
                default:
                    return new ONErrorHandler(ErrorCode.HTTP_DEFAULT);
            }
        }

    }
}
