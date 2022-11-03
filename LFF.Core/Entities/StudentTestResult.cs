using LFF.Core.Base;
using System;

namespace LFF.Core.Entities
{
    public partial class StudentTestResult : IEntity<Guid?>, IModificationEntity, IDeletionEntity, ICreationEntity
    {
        private Guid? _id;
        private Guid? _studentTestId;
        private Guid? _questionId;
        private string? _result;
        private DateTime? _deletedAt;
        private DateTime? _createdAt;
        private DateTime? _lastUpdatedAt;

        public Guid? Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public Guid? StudentTestId
        {
            get { return this._studentTestId; }
            set { this._studentTestId = value; }
        }

        public Guid? QuestionId
        {
            get { return this._questionId; }
            set { this._questionId = value; }
        }

        public string? Result
        {
            get { return this._result; }
            set { this._result = value; }
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

        public StudentTest StudentTest { get; set; }

        public Question Question { get; set; }

        public StudentTestResult()
        {

        }
    }
}
