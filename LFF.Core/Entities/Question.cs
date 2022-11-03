using LFF.Core.Base;
using System;
using System.Collections.Generic;

namespace LFF.Core.Entities
{
    public partial class Question : IEntity<Guid?>, IModificationEntity, IDeletionEntity, ICreationEntity
    {
        private Guid? _id;
        private string? _content;
        private string? _questionType;
        private Guid? _testId;
        private DateTime? _deletedAt;
        private DateTime? _createdAt;
        private DateTime? _lastUpdatedAt;

        public Guid? Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string? Content
        {
            get { return this._content; }
            set { this._content = value; }
        }

        public string? QuestionType
        {
            get { return this._questionType; }
            set { this._questionType = value; }
        }

        public Guid? TestId
        {
            get { return this._testId; }
            set { this._testId = value; }
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

        public Test Test { get; set; }

        public ICollection<StudentTestResult> StudentTestResults { get; set; }

        public Question()
        {
            this.StudentTestResults = new HashSet<StudentTestResult>();
        }
    }
}
