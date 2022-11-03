using LFF.Core.Base;
using System;
using System.Collections.Generic;

namespace LFF.Core.Entities
{
    public partial class Classroom : IEntity<Guid?>, IModificationEntity, IDeletionEntity, ICreationEntity
    {
        private Guid? _id;
        private string? _name;
        private DateTime? _startDate;
        private int? _numberOfLessons;
        private Guid? _courseId;
        private Guid? _teacherId;
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

        public DateTime? StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public int? NumberOfLessons
        {
            get { return this._numberOfLessons; }
            set { this._numberOfLessons = value; }
        }

        public Guid? CourseId
        {
            get { return this._courseId; }
            set { this._courseId = value; }
        }

        public Guid? TeacherId
        {
            get { return this._teacherId; }
            set { this._teacherId = value; }
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

        public User Teacher { get; set; }

        public Course Course { get; set; }

        public ICollection<Register> Registers { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

        public Classroom()
        {
            this.Registers = new HashSet<Register>();
            this.Lessons = new HashSet<Lesson>();
        }
    }
}
