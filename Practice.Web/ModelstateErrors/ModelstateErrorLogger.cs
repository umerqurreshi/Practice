using System.Web.Http.ModelBinding;

namespace Practice.Web.ModelstateErrors
{
    public class ModelstateErrorLogger : IModelstateErrorLogger
    {
        public string ModelstateErrors(ModelStateDictionary modelState)
        {
            var errors = string.Empty;

            foreach (var state in modelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    errors += $"{error.ErrorMessage}. ";
                }
            }

            return errors;
        }
    }
}