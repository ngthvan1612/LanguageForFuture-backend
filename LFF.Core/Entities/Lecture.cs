using LFF.Core.Base;
using System;

namespace LFF.Core.Entities
{
    public partial class Lecture : IEntity<Guid?>, IModificationEntity, IDeletionEntity, ICreationEntity
    {
        private Guid? _id;
        private string? _name;
        private string? _description;
        private string? _content;
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

        public string? Content
        {
            get { return this._content; }
            set { this._content = value; }
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

        public Lecture()
        {

        }
    }
}
