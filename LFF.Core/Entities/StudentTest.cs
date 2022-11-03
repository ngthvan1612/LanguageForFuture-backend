using LFF.Core.Base;
using System;
using System.Collections.Generic;

namespace LFF.Core.Entities
{
    public partial class StudentTest : IEntity<Guid?>, IModificationEntity, IDeletionEntity, ICreationEntity
    {
        private Guid? _id;
        private Guid? _studentId;
        private Guid? _testId;
        private DateTime? _startDate;
        private DateTime? _deletedAt;
        private DateTime? _createdAt;
        private DateTime? _lastUpdatedAt;

        public Guid? Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public Guid? StudentId
        {
            get { return this._studentId; }
            set { this._studentId = value; }
        }

        public Guid? TestId
        {
            get { return this._testId; }
            set { this._testId = value; }
        }

        public DateTime? StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public DateTime? DeletedAt
        {
            get { return this._deletedAt; }
            set { this._deletedAt = value; }
        }

        public DateTime? CreatedAt
        {
            get { return this._createdAt; }
            set { this._createdAt = value; }
        }

        public DateTime? LastUpdatedAt
        {
            get { return this._lastUpdatedAt; }
            set { this._lastUpdatedAt = value; }
        }

        public User Student { get; set; }

        public Test Test { get; set; }

        public ICollection<StudentTestResult> StudentTestResults { get; set; }

        public StudentTest()
        {
            this.StudentTestResults = new HashSet<StudentTestResult>();
        }
    }
}
