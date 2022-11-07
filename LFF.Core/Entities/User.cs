using LFF.Core.Base;
using System;
using System.Collections.Generic;

namespace LFF.Core.Entities
{
    public static class UserRoles
    {
        public const string Admin = "ADMIN";
        public const string Staff = "STAFF";
        public const string Teacher = "TEACHER";
        public const string Student = "STUDENT";

        public static List<string> GetAllRoles()
            => new List<string>(new string[] { Admin, Staff, Teacher, Student });
    }

    public partial class User : IEntity<Guid?>, IModificationEntity, IDeletionEntity, ICreationEntity
    {
        private Guid? _id;
        private string? _username;
        private string? _password;
        private string? _fullName;
        private string? _email;
        private DateTime? _dateOfBirth;
        private string? _cMND;
        private string? _role;
        private DateTime? _deletedAt;
        private DateTime? _createdAt;
        private DateTime? _lastUpdatedAt;

        public Guid? Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string? Username
        {
            get { return this._username; }
            set { this._username = value; }
        }

        public string? Password
        {
            get { return this._password; }
            set { this._password = value; }
        }

        public string? FullName
        {
            get { return this._fullName; }
            set { this._fullName = value; }
        }

        public string? Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public DateTime? DateOfBirth
        {
            get { return this._dateOfBirth; }
            set { this._dateOfBirth = value; }
        }

        public string? CMND
        {
            get { return this._cMND; }
            set { this._cMND = value; }
        }

        public string? Role
        {
            get { return this._role; }
            set { this._role = value; }
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

        public ICollection<Classroom> Classrooms { get; set; }

        public ICollection<Register> Registers { get; set; }

        public ICollection<StudentTest> StudentTests { get; set; }

        public User()
        {
            this.Classrooms = new HashSet<Classroom>();
            this.Registers = new HashSet<Register>();
            this.StudentTests = new HashSet<StudentTest>();
        }
    }
}
