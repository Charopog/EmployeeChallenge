
namespace EmployeeChallenge.Xam.ViewModels
{
    using Acr.UserDialogs;
    using EmployeeChallenge.Xam.Services.Abstractions;
    using EmployeeChallenge.Xam.Validations;
    using Prism.Commands;
    using Prism.Navigation;
    using System;
    using System.Diagnostics;

    public class AddEmployeePageViewModel : ViewModelBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly IUserDialogs _userDialogs;

        public AddEmployeePageViewModel(INavigationService navigationService, IEmployeesService employeesService,
                                       IUserDialogs userDialogs)
            : base(navigationService)
        {
            _employeesService = employeesService ?? throw new ArgumentNullException(nameof(employeesService));
            _userDialogs = userDialogs ?? throw new ArgumentNullException(nameof(userDialogs));

            _employee = new EmployeeValidableObject(Guid.NewGuid());
            Title = "Add Employee";

            ValidateFirstNameCommand = new DelegateCommand(ValidateFirstName);
            ValidateLastNameCommand = new DelegateCommand(ValidateLastName);
            ValidateEmailCommand = new DelegateCommand(ValidateEmail);
            ValidateAddressLineCommand = new DelegateCommand(ValidateAddressLine);
            ValidateCityCommand = new DelegateCommand(ValidateCity);
            ValidateCountryCommand = new DelegateCommand(ValidateCountry);
            SaveEmployeeCommand = new DelegateCommand(SaveEmployee);

        }

        public DelegateCommand ValidateFirstNameCommand { get; }
        public DelegateCommand ValidateLastNameCommand { get; }
        public DelegateCommand ValidateEmailCommand { get; }
        public DelegateCommand ValidateAddressLineCommand { get; }
        public DelegateCommand ValidateCityCommand { get; }
        public DelegateCommand ValidateCountryCommand { get; }
        public DelegateCommand SaveEmployeeCommand { get; }

        private EmployeeValidableObject _employee;
        public EmployeeValidableObject Employee
        {
            get { return _employee; }
            set { SetProperty(ref _employee, value); }
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

        private async void SaveEmployee()
        {
            if(_employee.IsValid())
            {
                try
                {
                    var createdEmployeeGuid = await _employeesService.CreateNewEmployeeAsync(_employee.ToNonValidatableObject());
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
