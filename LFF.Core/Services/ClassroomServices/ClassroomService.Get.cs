using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Classrooms.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.ClassroomServices
{
    public partial class ClassroomService : IClassroomService
    {

        public virtual async Task<ResponseBase> GetClassroomByIdAsync(Guid id)
        {
            var classroomRepository = this.aggregateRepository.ClassroomRepository;

            var entity = await classroomRepository.GetClassroomByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy lớp học nào với Id = {id}");
            Console.WriteLine("lay du lieu xong");
            return await Task.FromResult(new GetClassroomResponse(entity));
        }

        public virtual async Task<ResponseBase> GetClassroomByNameAsync(string name)
        {
            var classroomRepository = this.aggregateRepository.ClassroomRepository;

            var entity = await classroomRepository.GetClassroomByNameAsync(name);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy lớp học nào với tên lớp = {name}");

            return await Task.FromResult(new GetClassroomResponse(entity));
        }

        public virtual async Task<ResponseBase> ListClassroomAsync(IEnumerable<SearchQueryItem> queries)
        {
            var classroomRepository = this.aggregateRepository.ClassroomRepository;

            var raws = await classroomRepository.ListByQueriesAsync(queries);
            return await Task.FromResult(new ListClassroomResponse(raws));
        }

        public async Task<ResponseBase> ListClassroomsWithNumberOfStudents()
        {
            var result = await this.aggregateRepository.ClassroomRepository.ListClassroomWithNumberOfStudents();
            return new ListClassroomsWithNumberOfStudentsResponse(result);
        }
    }
}
