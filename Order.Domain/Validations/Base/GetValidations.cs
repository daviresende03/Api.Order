using FluentValidation.Results;

namespace Order.Domain.Validations.Base
{
    public static class GetValidations
    {
        public static Response GetErrors(this ValidationResult result)
        {
            var response = new Response();

            if (!result.IsValid)
            {
                foreach (var err in result.Errors)
                {
                    response.Report.Add(new Report()
                    {
                        Code = err.PropertyName,
                        Message = err.ErrorMessage
                    });
                }
                return response;
            }
            return response;
        }
    }
}
