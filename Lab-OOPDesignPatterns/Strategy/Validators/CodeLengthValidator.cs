using SharpCompiler.Interfaces;
using SharpCompiler.Exceptions;

namespace SharpCompiler.Validators
{
    public class CodeLengthValidator : ICodeValidationStrategy
    {
        private const int CodeLength = 20;
        
        public void Validate(string codeString)
        {
            if (codeString.Length < 20)
            {
                throw new CompilationException(string.Format("Code should be at least {0} characters long", CodeLength));
            }
        }
    }
}
