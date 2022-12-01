using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LFF.Core.DTOs.Tests.Requests
{
    public class ImportListQuestionsRequest
    {
        public Guid TestId { get; set; }
        public IFormFile? UploadFile { get; set; }
    }
}
