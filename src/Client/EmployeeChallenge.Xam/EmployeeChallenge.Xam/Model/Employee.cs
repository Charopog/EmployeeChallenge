
namespace EmployeeChallenge.Xam.Model
{
    using MvvmHelpers;
    using Prism.Mvvm;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Employee : BindableBase
    {
        public Employee(Guid id)
        {
            ID = id;
            Skills = new ObservableRangeCollection<Skill>();
        }
        public Guid ID { get; private set; }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value,()=>RaisePropertyChanged(nameof(Fullname))); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value, () => RaisePropertyChanged(nameof(Fullname))); }
        }

        public string Fullname
        {
            get
            {
                return _firstName + " "+ LastName;
            }
        }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { SetProperty(ref _dateOfBirth, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

        private string _addressLine;
        public string AddressLine
        {
            get { return _addressLine; }
            set { SetProperty(ref _addressLine, value); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value, () => RaisePropertyChanged(nameof(LocationInfo))); }
        }

        private string _country;
        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value, () => RaisePropertyChanged(nameof(LocationInfo))); }
        }

        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { SetProperty(ref _zipCode, value); }
        }

        public string LocationInfo
        {
            get
            {
                return _city + " " + _country;
            }
        }
        public ObservableRangeCollection<Skill> Skills { get; private set; }

        public void AddSkill(Skill skill)
        {
            Skills.Add(skill);
        }

        public void RemoveSkill(Skill skill)
        {
            Skills.Remove(skill);
        }

        public void AddSkills(IEnumerable<Skill> skills)
        {
            Skills.AddRange(skills);
        }

        public void ReplaceAllSkills(IEnumerable<Skill> skills)
        {
            Skills.ReplaceRange(skills);
        }


    }
}
