using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartClinic.Infrastructure.CrossCutting.Validations
{
    public class ViewModelValidator
    {

        /// <summary>
        /// Valida se o ViewModel está valido
        /// </summary>
        /// <param name="viewModel">ViewModel a veificado.</param>
        /// <returns>Retorna um booleano informando se o objeto está valido ou não.</returns>
        public static bool Validate(object viewModel)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(viewModel, null, null);

            var isValid = Validator.TryValidateObject(viewModel, validationContext, validationResults, true);

            return isValid;
        }


        /// <summary>
        /// Valida se o ViewModel está valido
        /// </summary>
        /// <param name="viewModel">ViewModel a veificado.</param>
        /// <param name="results">Parâmetro de saída para que seja possível analisar os resultados de validação do ViewModel</param>
        /// <returns>Retorna um booleano informando se o objeto está valido ou não.</returns>
        public static bool Validate(object viewModel, out List<ValidationResult> results)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(viewModel, null, null);

            var isValid = Validator.TryValidateObject(viewModel, validationContext, validationResults, true);

            results = validationResults;
            return isValid;
        }
    }
}