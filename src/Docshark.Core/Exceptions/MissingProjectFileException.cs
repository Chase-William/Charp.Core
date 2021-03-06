using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docshark.Core.Exceptions
{
    public class MissingProjectFileException : Exception
    {
        public string ProjectFile { get; set; }

        public MissingProjectFileException(string csProjFile)
            => ProjectFile = csProjFile;

        public override string Message => "Was unable to locate the following file: '" + ProjectFile + "'.";
    }
}
