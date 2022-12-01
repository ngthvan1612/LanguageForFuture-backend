using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LFF.Core.DTOs.Lessons.Requests
{
    [DataContract]
    public class UpdateLessonApprovalRequest
    {
        
        public Guid LessonId { get; set; }

        [DataMember]
        public bool? IsApproved { get; set; }

        [DataMember]
        public string? Reason { get; set; }

        public UpdateLessonApprovalRequest()
        {

        }
    }
}
