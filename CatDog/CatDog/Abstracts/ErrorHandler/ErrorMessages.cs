using System;

namespace CatDog.Abstracts.ErrorHandler
{
    public class ErrorMessages
    {
        public const string ERROR_TITLE_DEFAULT = "Error";
        public const string ERROR_MESSAGE_DEFAULT = "Unexpected error, please try again later.";
        public const string ERROR_PRECONDITION_FAILED = "Impossible to accomplish.";
        public const string ERROR_HTTP_REQUEST = "Unreachable server, check your internet connection and try again.";
        public const string ERROR_INT_SERVER = "An error occurred on server, wait a while and try again. If persists, mail us.";

        public static string ERROR_MESSAGE_EXCEPTION_DEFAULT(Exception e)
        {
            return ERROR_MESSAGE_DEFAULT + " \n\n" + e.Message;
        }
        public static string ERROR_MESSAGE_INT_SERVER_DEFAULT(ErrorModel e)
        {
            return ERROR_INT_SERVER + " \n\n" + e.exception;
        }
        public static string GetMessageErroFromCode(ErrorCode _Code)
        {
            switch (_Code)
            {
                case ErrorCode.PRECONDITION_FAILED:
                    return $"{_Code} - {ERROR_PRECONDITION_FAILED}";
                case ErrorCode.HTTP_EXCEPTION:
                    return $"{_Code} - {ERROR_HTTP_REQUEST}";
                default:
                    return $"Code:{_Code} - Msg:{ERROR_MESSAGE_DEFAULT}";

            }
        }
    }
}
