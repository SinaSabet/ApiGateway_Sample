using System.ComponentModel.DataAnnotations;

namespace app.ApiGateWay.Middleware
{
    internal class ApiResult<T>
    {
        private ValidationException ex;
        private object validationErrors;
        private object validationWarnings;
        private object value;

        public ApiResult(ValidationException ex, object validationErrors, object validationWarnings, object value)
        {
            this.ex = ex;
            this.validationErrors = validationErrors;
            this.validationWarnings = validationWarnings;
            this.value = value;
        }
    }
}