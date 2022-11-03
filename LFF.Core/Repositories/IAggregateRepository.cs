namespace LFF.Core.Repositories
{
    public interface IAggregateRepository
    {
        IUserRepository UserRepository { get; }
        ICourseRepository CourseRepository { get; }
        IClassroomRepository ClassroomRepository { get; }
        ILessonRepository LessonRepository { get; }
        ILectureRepository LectureRepository { get; }
        IRegisterRepository RegisterRepository { get; }
        ITestRepository TestRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IStudentTestRepository StudentTestRepository { get; }
        IStudentTestResultRepository StudentTestResultRepository { get; }
    }
}
