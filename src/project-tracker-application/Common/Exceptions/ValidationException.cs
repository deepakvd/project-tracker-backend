using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace project_tracker_application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public Dictionary<string, string> Errors { get; set; }

        public ValidationException(string message, Dictionary<string, string> errors) : base(message)
        {
            Errors = errors;
        }

    }
}

