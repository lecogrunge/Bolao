using FluentValidation.Results;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Bolao.CrossCutting.Common
{
    public static class Text
    {
        public static string RemoverAcentuacao(this string text)
        {
            return new string(text.Normalize(NormalizationForm.FormD)
                                  .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                                  .ToArray());
        }

        //public static IList<ErrorResponse> ConverterErrorFluentValidationResponseToError(this IList<ValidationFailure> fluentErrors)
        //{
        //    IList<ErrorResponse> lista = new List<ErrorResponse>();

        //    foreach (ValidationFailure item in fluentErrors)
        //    {
        //        string errorCode = item.ErrorCode.VerificarEhValorNumerico() ? item.ErrorCode : "0";
        //        lista.Add(new ErrorResponse(errorCode, item.ErrorMessage));
        //    }

        //    return lista;
        //}

        public static bool VerificarEhValorNumerico(this string text)
        {
            return text.All(char.IsDigit);
        }
    }
}