using Bolao.Domain.Arguments.Base.Error;
using System.Collections.Generic;

namespace Bolao.Domain.Interfaces.Arguments
{
    public interface IResponseBase
	{
		IList<ErrorResponse> GetErrors();
	}
}