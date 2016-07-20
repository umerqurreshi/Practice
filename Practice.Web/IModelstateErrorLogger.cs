using System.Web.Http.ModelBinding;

namespace Practice.Web
{
    public interface IModelstateErrorLogger
    {
        string ModelstateErrors(ModelStateDictionary modelState);
    }
}
