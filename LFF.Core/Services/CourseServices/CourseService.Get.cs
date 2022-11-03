using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Courses.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.CourseServices
{
    public partial class CourseService
    {

        public virtual async Task<ResponseBase> GetCourseByIdAsync(Guid id)
        {
            var userRepository = this.aggregateRepository.UserRepository;
            var courseRepository = this.aggregateRepository.CourseRepository;
            var classroomRepository = this.aggregateRepository.ClassroomRepository;
            var lessonRepository = this.aggregateRepository.LessonRepository;
            var lectureRepository = this.aggregateRepository.LectureRepository;
            var registerRepository = this.aggregateRepository.RegisterRepository;
            var testRepository = this.aggregateRepository.TestRepository;
            var questionRepository = this.aggregateRepository.QuestionRepository;
            var studentTestRepository = this.aggregateRepository.StudentTestRepository;
            var studentTestResultRepository = this.aggregateRepository.StudentTestResultRepository;

            var entity = await courseRepository.GetCourseByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy khóa học nào với Id = {id}");

            return await Task.FromResult(new GetCourseResponse(entity));
        }

        public virtual async Task<ResponseBase> GetCourseByNameAsync(string name)
        {
            var userRepository = this.aggregateRepository.UserRepository;
            var courseRepository = this.aggregateRepository.CourseRepository;
            var classroomRepository = this.aggregateRepository.ClassroomRepository;
            var lessonRepository = this.aggregateRepository.LessonRepository;
            var lectureRepository = this.aggregateRepository.LectureRepository;
            var registerRepository = this.aggregateRepository.RegisterRepository;
            var testRepository = this.aggregateRepository.TestRepository;
            var questionRepository = this.aggregateRepository.QuestionRepository;
            var studentTestRepository = this.aggregateRepository.StudentTestRepository;
            var studentTestResultRepository = this.aggregateRepository.StudentTestResultRepository;

            var entity = await courseRepository.GetCourseByNameAsync(name);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy khóa học nào với tên khóa học = {name}");

            return await Task.FromResult(new GetCourseResponse(entity));
        }

        public virtual async Task<ResponseBase> ListCourseAsync(IEnumerable<SearchQueryItem> queries)
        {
            var userRepository = this.aggregateRepository.UserRepository;
            var courseRepository = this.aggregateRepository.CourseRepository;
            var classroomRepository = this.aggregateRepository.ClassroomRepository;
            var lessonRepository = this.aggregateRepository.LessonRepository;
            var lectureRepository = this.aggregateRepository.LectureRepository;
            var registerRepository = this.aggregateRepository.RegisterRepository;
            var testRepository = this.aggregateRepository.TestRepository;
            var questionRepository = this.aggregateRepository.QuestionRepository;
            var studentTestRepository = this.aggregateRepository.StudentTestRepository;
            var studentTestResultRepository = this.aggregateRepository.StudentTestResultRepository;

            var raws = await courseRepository.ListByQueriesAsync(queries);
            return await Task.FromResult(new ListCourseResponse(raws));
        }
    }
}
