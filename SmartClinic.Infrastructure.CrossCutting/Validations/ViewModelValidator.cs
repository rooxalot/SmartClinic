using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SmartClinic.Infrastructure.CrossCutting.Validations
{
    public class ViewModelValidator
    {
        public static List<ValidationResult> Validate(object viewModel)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext =  new ValidationContext(viewModel, null, null);

            var isValid = Validator.TryValidateObject(viewModel, validationContext, validationResults, true);

            return validationResults;
        }
    }
}
