
namespace MegaEcommerce.Application.DTO.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data  { get; set; }

        public int StatusCode { get; set; }

        public static ApiResponse<T> SuccessResponse(T? data = default,string message = "Success")
        {
            return new ApiResponse<T>()
            {
                Success = true,
                Message = message,
                Data = data,
                StatusCode = 200
            };
        }

        public static ApiResponse<T> ErrorResponse( string message = "Something went wrong",int statusCode = 500)
        {
            return new ApiResponse<T>()
            {
                Success = false,
                Message = message,
                Data = default,
                StatusCode = statusCode
            };
        }

    }
}
