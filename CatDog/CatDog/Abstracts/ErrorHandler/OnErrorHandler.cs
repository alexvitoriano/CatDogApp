using System;
using System.Collections.Generic;
using System.Text;

namespace CatDog.Abstracts.ErrorHandler
{
    public class ONErrorHandler : Exception
    {
        public ErrorCode Code { get; set; }
        public string Title { get; set; }
        public string Msg { get; set; }
        //public Exception e { get; set; }

        public ONErrorHandler()
        {
            Code = ErrorCode.DEFAULT;
            Title = ErrorMessages.ERROR_TITLE_DEFAULT;
            Msg = ErrorMessages.ERROR_MESSAGE_DEFAULT;
        }

        public ONErrorHandler(Exception ex)
        {
            Code = ErrorCode.DEFAULT;
            Title = ErrorMessages.ERROR_TITLE_DEFAULT;
            Msg = ErrorMessages.ERROR_MESSAGE_EXCEPTION_DEFAULT(ex);
        }
        public ONErrorHandler(ErrorModel err)
        {
            Code = ErrorCode.DEFAULT;
            Title = ErrorMessages.ERROR_TITLE_DEFAULT;
            Msg = ErrorMessages.ERROR_MESSAGE_INT_SERVER_DEFAULT(err);
        }
        public ONErrorHandler(ErrorCode _Code, string _Title, string _Message)
        {
            Code = _Code;
            Title = _Title;
            Msg = _Message;
        }
        public ONErrorHandler(string _Title, string _Message)
        {
            Code = ErrorCode.DEFAULT;
            Title = _Title;
            Msg = _Message;
        }
        public ONErrorHandler(string _Message)
        {
            Code = ErrorCode.DEFAULT;
            Title = ErrorMessages.ERROR_TITLE_DEFAULT;
            Msg = _Message;
        }
        public ONErrorHandler(ErrorCode _Code)
        {
            Code = _Code;
            Title = ErrorMessages.ERROR_TITLE_DEFAULT;
            Msg = ErrorMessages.GetMessageErroFromCode(_Code);
        }
        public ONErrorHandler(ErrorCode _Code, string _Title)
        {
            Code = _Code;
            Title = _Title;
            Msg = ErrorMessages.GetMessageErroFromCode(_Code);
        }

    }
}
