using SharpCompiler.Interfaces;
using SharpCompiler.Exceptions;

namespace SharpCompiler.Validators
{
    public class SystemNetValidator : ICodeValidationStrategy
    {
        public void Validate(string codeString)
        {
            if (!codeString.Contains("using System.Net"))
            {
                throw new CompilationException("Code does not contain \"using System.Net\" reference.");
            }
        }
    }
}
