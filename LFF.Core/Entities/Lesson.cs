using LFF.Core.Base;
using System;
using System.Collections.Generic;

namespace LFF.Core.Entities
{
    public partial class Lesson : IEntity<Guid?>, IModificationEntity, IDeletionEntity, ICreationEntity
    {
        private Guid? _id;
        private string? _name;
        private string? _description;
        private string? _lessonContent;
        private DateTime? _startTime;
        private DateTime? _endTime;
        private Guid? _classId;
        private DateTime? _deletedAt;
        private DateTime? _createdAt;
        private DateTime? _lastUpdatedAt;
        private bool? _isApproved;
        private string? _reasonForNotApproving;

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

        public string? LessonContent
        {
            get { return this._lessonContent; }
            set { this._lessonContent = value; }
        }

        public DateTime? StartTime
        {
            get { return this._startTime; }
            set { this._startTime = value; }
        }

        public DateTime? EndTime
        {
            get { return this._endTime; }
            set { this._endTime = value; }
        }

        public Guid? ClassId
        {
            get { return this._classId; }
            set { this._classId = value; }
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

        public bool? IsApproved
        {
            get => this._isApproved;
            set => this._isApproved = value;
        }

        public string? ReasonForNotApproving
        {
            get => this._reasonForNotApproving;
            set => this._reasonForNotApproving = value;
        }

        public Classroom Class { get; set; }

        public ICollection<Lecture> Lectures { get; set; }

        public ICollection<Test> Tests { get; set; }

        public Lesson()
        {
            this.Lectures = new HashSet<Lecture>();
            this.Tests = new HashSet<Test>();
        }
    }
}
