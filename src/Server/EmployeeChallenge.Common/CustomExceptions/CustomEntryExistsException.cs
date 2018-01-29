
namespace EmployeeChallenge.Common.CustomExceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CustomEntryExistsException : Exception
    {
        public CustomEntryExistsException()
        {
        }

        public CustomEntryExistsException(string message) : base(message)
        {
        }

        public CustomEntryExistsException(string message, Exception inner)
                                                : base(message, inner)
        {
        }
    }
}
