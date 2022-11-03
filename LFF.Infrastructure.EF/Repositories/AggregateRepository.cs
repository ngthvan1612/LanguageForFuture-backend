using LFF.Core.Repositories;

namespace LFF.Infrastructure.EF.Repositories
{
    public class AggregateRepository : IAggregateRepository
    {
        private readonly IUserRepository userRepository;
        private readonly ICourseRepository courseRepository;
        private readonly IClassroomRepository classroomRepository;
        private readonly ILessonRepository lessonRepository;
        private readonly ILectureRepository lectureRepository;
        private readonly IRegisterRepository registerRepository;
        private readonly ITestRepository testRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IStudentTestRepository studentTestRepository;
        private readonly IStudentTestResultRepository studentTestResultRepository;

        public IUserRepository UserRepository
        {
            get { return this.userRepository; }
            set { }
        }

        public ICourseRepository CourseRepository
        {
            get { return this.courseRepository; }
            set { }
        }

        public IClassroomRepository ClassroomRepository
        {
            get { return this.classroomRepository; }
            set { }
        }

        public ILessonRepository LessonRepository
        {
            get { return this.lessonRepository; }
            set { }
        }

        public ILectureRepository LectureRepository
        {
            get { return this.lectureRepository; }
            set { }
        }

        public IRegisterRepository RegisterRepository
        {
            get { return this.registerRepository; }
            set { }
        }

        public ITestRepository TestRepository
        {
            get { return this.testRepository; }
            set { }
        }

        public IQuestionRepository QuestionRepository
        {
            get { return this.questionRepository; }
            set { }
        }

        public IStudentTestRepository StudentTestRepository
        {
            get { return this.studentTestRepository; }
            set { }
        }

        public IStudentTestResultRepository StudentTestResultRepository
        {
            get { return this.studentTestResultRepository; }
            set { }
        }

        public AggregateRepository(IUserRepository userRepository, ICourseRepository courseRepository, IClassroomRepository classroomRepository, ILessonRepository lessonRepository, ILectureRepository lectureRepository, IRegisterRepository registerRepository, ITestRepository testRepository, IQuestionRepository questionRepository, IStudentTestRepository studentTestRepository, IStudentTestResultRepository studentTestResultRepository)
        {
            this.userRepository = userRepository;
            this.courseRepository = courseRepository;
            this.classroomRepository = classroomRepository;
            this.lessonRepository = lessonRepository;
            this.lectureRepository = lectureRepository;
            this.registerRepository = registerRepository;
            this.testRepository = testRepository;
            this.questionRepository = questionRepository;
            this.studentTestRepository = studentTestRepository;
            this.studentTestResultRepository = studentTestResultRepository;
        }

        public IUserRepository GetUserRepository()
        {
            return this.userRepository;
        }

        public ICourseRepository GetCourseRepository()
        {
            return this.courseRepository;
        }

        public IClassroomRepository GetClassroomRepository()
        {
            return this.classroomRepository;
        }

        public ILessonRepository GetLessonRepository()
        {
            return this.lessonRepository;
        }

        public ILectureRepository GetLectureRepository()
        {
            return this.lectureRepository;
        }

        public IRegisterRepository GetRegisterRepository()
        {
            return this.registerRepository;
        }

        public ITestRepository GetTestRepository()
        {
            return this.testRepository;
        }

        public IQuestionRepository GetQuestionRepository()
        {
            return this.questionRepository;
        }

        public IStudentTestRepository GetStudentTestRepository()
        {
            return this.studentTestRepository;
        }

        public IStudentTestResultRepository GetStudentTestResultRepository()
        {
            return this.studentTestResultRepository;
        }
    }
}
