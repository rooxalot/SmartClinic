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
        public static bool Validate(object viewModel)
        {
            var validationContext =  new ValidationContext(viewModel);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(viewModel, validationContext, validationResults);

            return isValid;
        }
    }
}
