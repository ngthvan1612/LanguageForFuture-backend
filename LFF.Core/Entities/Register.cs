using LFF.Core.Base;
using System;

namespace LFF.Core.Entities
{
    public partial class Register : IEntity<Guid?>, IModificationEntity, IDeletionEntity, ICreationEntity
    {
        private Guid? _id;
        private Guid? _studentId;
        private Guid? _classId;
        private DateTime? _registrationDate;
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

        public Guid? ClassId
        {
            get { return this._classId; }
            set { this._classId = value; }
        }

        public DateTime? RegistrationDate
        {
            get { return this._registrationDate; }
            set { this._registrationDate = value; }
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

        public Classroom Class { get; set; }

        public Register()
        {

        }
    }
}
