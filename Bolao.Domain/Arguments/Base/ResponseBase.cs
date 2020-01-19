using Bolao.Domain.Arguments.Base.Error;
using Bolao.Domain.Interfaces.Arguments;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Bolao.Domain.Arguments.Base
{
    public abstract class ResponseBase : IResponseBase
    {
        public ResponseBase()
        {
            Errors = new List<ErrorResponse>();
        }

        protected IList<ErrorResponse> Errors { get; private set; }

        public void AddErrorValidationResult(ValidationResult validation)
        {
            foreach (ValidationFailure item in validation.Errors)
            {
                Errors.Add(new ErrorResponse(item.PropertyName, item.ErrorMessage));
            }
        }

        public void AddError(ErrorResponse error)
        {
            Errors.Add(error);
        }

        public bool IsValid()
        {
            return !Errors.Any();
        }

        public IList<ErrorResponse> GetErrors()
        {
            return Errors;
        }
    }
}