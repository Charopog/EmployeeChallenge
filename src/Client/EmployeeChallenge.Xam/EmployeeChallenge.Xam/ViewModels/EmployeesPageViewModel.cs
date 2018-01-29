
namespace EmployeeChallenge.Xam.ViewModels
{
    using Acr.UserDialogs;
    using EmployeeChallenge.Xam.Model;
    using EmployeeChallenge.Xam.Services.Abstractions;
    using MvvmHelpers;
    using Prism.Commands;
    using Prism.Navigation;
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class EmployeesPageViewModel : ViewModelBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly IUserDialogs _userDialogs;

        public EmployeesPageViewModel(INavigationService navigationService, IEmployeesService employeesService,
                                       IUserDialogs userDialogs)
            : base(navigationService)
        {
            _employeesService = employeesService ?? throw new ArgumentNullException(nameof(employeesService));
            _userDialogs = userDialogs ?? throw new ArgumentNullException(nameof(userDialogs));
            Title = "Employee Management";
            _employees = new ObservableRangeCollection<Employee>();
            DisplayEmployeeActionSheetCommand = new DelegateCommand<Employee>(DisplayEmployeeActionSheet);
            RefreshEmployeesCommand = new DelegateCommand(RefreshEmployees);
            NavigateToAddEmployeeCommand = new DelegateCommand(NavigateToAddEmployee);
        }


        public DelegateCommand RefreshEmployeesCommand { get; }
        public DelegateCommand<Employee> DisplayEmployeeActionSheetCommand { get; }
        public DelegateCommand NavigateToAddEmployeeCommand { get; }

        private ObservableRangeCollection<Employee> _employees;
        public ObservableRangeCollection<Employee> Employees
        {
            get { return _employees; }
            set { SetProperty(ref _employees, value); }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            try
            {
                await GetAndReplaceAllEmployees();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await _userDialogs.AlertAsync(ex.Message, "Error");
            }
        }

        private void DisplayEmployeeActionSheet(Employee employee)
        {
            var cfg = new ActionSheetConfig()
                        .SetTitle("Select Action");
            cfg.Add("Edit", async () => await NavigateToEditEmployeePage(employee));
            cfg.Add("Delete", async () => await DeleteEmployee(employee));
            cfg.Add("Manage Skills", async () => await NavigateToEmployeeSkillsPage(employee.ID));

            cfg.SetCancel("Cancel");

            _userDialogs.ActionSheet(cfg);

        }

        private async Task GetAndReplaceAllEmployees()
        {
            var employees = await _employeesService.GetAllEmployeesAsync();
            Employees.ReplaceRange(employees);
        }

        private async void RefreshEmployees()
        {
            IsRefreshing = true;
            try
            {
                await GetAndReplaceAllEmployees();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await _userDialogs.AlertAsync(ex.Message, "Error");
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private async void NavigateToAddEmployee()
        {
            await NavigationService.NavigateAsync("AddEmployeePage", null, false);
        }

        private Task NavigateToEmployeeSkillsPage(Guid employeeID)
        {
            var navParameters = new NavigationParameters();
            navParameters.Add("employeeID", employeeID);

            return NavigationService.NavigateAsync("EmployeeSkillsPage", navParameters, false);

        }

        private Task NavigateToEditEmployeePage(Employee employee)
        {
            var navParameters = new NavigationParameters();
            navParameters.Add("employee", employee);

            return NavigationService.NavigateAsync("EditEmployeePage", navParameters, false);

        }

        private async Task DeleteEmployee(Employee employee)
        {
            try
            {
                await _employeesService.DeleteEmployeeAsync(employee.ID);
                Employees.Remove(employee);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await _userDialogs.AlertAsync(ex.Message, "Error");
            }

        }
    }
}
