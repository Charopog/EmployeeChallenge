

namespace EmployeeChallenge.Xam.ViewModels
{
    using Acr.UserDialogs;
    using EmployeeChallenge.Xam.Model;
    using EmployeeChallenge.Xam.Services.Abstractions;
    using EmployeeChallenge.Xam.Validations;
    using Prism.Commands;
    using Prism.Navigation;
    using System;
    using System.Diagnostics;

    public class EditEmployeePageViewModel : ViewModelBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly IUserDialogs _userDialogs;

        public EditEmployeePageViewModel(INavigationService navigationService, IEmployeesService employeesService,
                                       IUserDialogs userDialogs)
            : base(navigationService)
        {
            _employeesService = employeesService ?? throw new ArgumentNullException(nameof(employeesService));
            _userDialogs = userDialogs ?? throw new ArgumentNullException(nameof(userDialogs));

            Title = "Edit Employee";

            ValidateFirstNameCommand = new DelegateCommand(ValidateFirstName);
            ValidateLastNameCommand = new DelegateCommand(ValidateLastName);
            ValidateEmailCommand = new DelegateCommand(ValidateEmail);
            ValidateAddressLineCommand = new DelegateCommand(ValidateAddressLine);
            ValidateCityCommand = new DelegateCommand(ValidateCity);
            ValidateCountryCommand = new DelegateCommand(ValidateCountry);
            UpdateEmployeeCommand = new DelegateCommand(UpdateEmployee);

        }

        public DelegateCommand ValidateFirstNameCommand { get; }
        public DelegateCommand ValidateLastNameCommand { get; }
        public DelegateCommand ValidateEmailCommand { get; }
        public DelegateCommand ValidateAddressLineCommand { get; }
        public DelegateCommand ValidateCityCommand { get; }
        public DelegateCommand ValidateCountryCommand { get; }
        public DelegateCommand UpdateEmployeeCommand { get; }

        private EmployeeValidableObject _employee;
        public EmployeeValidableObject Employee
        {
            get { return _employee; }
            set { SetProperty(ref _employee, value); }
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            var employee = parameters.GetValue<Employee>("employee");
            Employee = employee.ToValidatableObject();
        }

        private void ValidateCountry()
        {
            _employee.Country.Validate();
        }

        private void ValidateCity()
        {
            _employee.City.Validate();
        }

        private void ValidateAddressLine()
        {
            _employee.AddressLine.Validate();
        }

        private void ValidateEmail()
        {
            _employee.Email.Validate();
        }

        private void ValidateLastName()
        {
            _employee.LastName.Validate();
        }

        private void ValidateFirstName()
        {
            _employee.FirstName.Validate();
        }

        private async void UpdateEmployee()
        {
            if (_employee.IsValid())
            {
                try
                {
                    await _employeesService.UpdateEmployeeAsync(_employee.ID, _employee.ToNonValidatableObject());
                    await NavigationService.GoBackAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    await _userDialogs.AlertAsync(ex.Message, "Error");
                }

            }
            else
            {
                await _userDialogs.AlertAsync("Employee is not Valid", "Warning");
            }
        }
    }
}
