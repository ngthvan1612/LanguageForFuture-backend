using LFF.Core.Base;
using LFF.Core.Entities.Supports;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LFF.Core.DTOs.Classrooms.Responses
{
    public class ListClassroomsWithNumberOfStudentsResponse : SuccessResponseBase
    {
        public ListClassroomsWithNumberOfStudentsResponse(List<ClassroomWithNumberOfStudents> data)
            : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
            this.Data = data;
        }
    }
}
