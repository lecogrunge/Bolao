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
			Errors = new List<ErrorResponseBase>();
		}

		protected IList<ErrorResponseBase> Errors { get; private set; }

        public void AddErrorValidationResult(ValidationResult validation)
        {
            foreach (ValidationFailure item in validation.Errors)
                Errors.Add(new ErrorResponseBase { Property = item.PropertyName, Message = item.ErrorMessage });
        }

		public void AddError(ErrorResponseBase error)
		{
			Errors.Add(error);
		}

        public bool IsValid()
        {
            return !Errors.Any();
        }

        public IList<ErrorResponseBase> GetErrors()
        {
            return this.Errors;
        }
    }
}