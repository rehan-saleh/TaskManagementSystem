using System.Collections.Generic;
using TaskManagementService.Common.ViewModels;

namespace TaskManagementService.Common.DTO
{
    public class ResponseDTO<T>
    {
        public List<T> Data { get; set; }
        public ErrorResponseViewModel Error { get; set; }
    }
}
