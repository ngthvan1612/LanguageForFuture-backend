using LFF.Core.Base;
using System;
using System.Collections.Generic;

namespace LFF.Core.Entities
{
    public partial class Test : IEntity<Guid?>, IModificationEntity, IDeletionEntity, ICreationEntity
    {
        private Guid? _id;
        private string? _name;
        private string? _description;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private int? _numberOfAttempts;
        private DateTime? _time;
        private Guid? _lessonId;
        private DateTime? _deletedAt;
        private DateTime? _createdAt;
        private DateTime? _lastUpdatedAt;

        public Guid? Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string? Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string? Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public DateTime? StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public DateTime? EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }

        public int? NumberOfAttempts
        {
            get { return this._numberOfAttempts; }
            set { this._numberOfAttempts = value; }
        }

        public DateTime? Time
        {
            get { return this._time; }
            set { this._time = value; }
        }

        public Guid? LessonId
        {
            get { return this._lessonId; }
            set { this._lessonId = value; }
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

        public Lesson Lesson { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<StudentTest> StudentTests { get; set; }

        public Test()
        {
            this.Questions = new HashSet<Question>();
            this.StudentTests = new HashSet<StudentTest>();
        }
    }
}
