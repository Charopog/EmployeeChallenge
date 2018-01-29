
namespace EmployeeChallenge.Xam.Model
{
    using Prism.Mvvm;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Skill : BindableBase
    {
        public Skill(Guid id)
        {
            ID = id;
        }

        public Guid ID { get; private set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
}
