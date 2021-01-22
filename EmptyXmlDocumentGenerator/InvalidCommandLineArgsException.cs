using System;
using System.Collections.Generic;
using System.Text;

namespace EmptyXmlDocumentGenerator
{
    /// <summary>
    /// 
    /// </summary>
    public class InvalidCommandLineArgsException : Exception
    {
        public InvalidCommandLineArgsException(string message) : base(message)
        {
        }
    }
}
