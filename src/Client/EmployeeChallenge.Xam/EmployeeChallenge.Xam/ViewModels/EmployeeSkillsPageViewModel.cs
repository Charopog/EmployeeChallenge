
namespace EmployeeChallenge.Xam.ViewModels
{
    using Acr.UserDialogs;
    using EmployeeChallenge.Xam.Model;
    using EmployeeChallenge.Xam.Services.Abstractions;
    using MvvmHelpers;
    using Prism.Commands;
    using Prism.Navigation;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public class EmployeeSkillsPageViewModel : ViewModelBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly IUserDialogs _userDialogs;
        private readonly ISkillsService _skillsService;

        private Guid _currentEmployeeID;
        private IEnumerable<Skill> _skillCache;

        public EmployeeSkillsPageViewModel(INavigationService navigationService, IEmployeesService employeesService,
                                          ISkillsService skillsService, IUserDialogs userDialogs)
            : base(navigationService)
        {
            _employeesService = employeesService ?? throw new ArgumentNullException(nameof(employeesService));
            _userDialogs = userDialogs ?? throw new ArgumentNullException(nameof(userDialogs));
            _skillsService = skillsService ?? throw new ArgumentNullException(nameof(skillsService));
            OpenAddSkillActionSheetCommand = new DelegateCommand(OpenAddSkillActionSheet);
            DisplayEmployeeSkillActionSheetCommand = new DelegateCommand<Skill>(DisplayEmployeeSkillActionSheet);
            RefreshSkillsCommand = new DelegateCommand(RefreshSkills);
            _employeeSkills = new ObservableRangeCollection<Skill>();
            Title = "Skills Management";
        }



        public DelegateCommand RefreshSkillsCommand { get; }
        public DelegateCommand OpenAddSkillActionSheetCommand { get; }
        public DelegateCommand<Skill> DisplayEmployeeSkillActionSheetCommand { get; }


        private ObservableRangeCollection<Skill> _employeeSkills;
        public ObservableRangeCollection<Skill> EmployeeSkills
        {
            get { return _employeeSkills; }
            set { SetProperty(ref _employeeSkills, value); }
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

            _currentEmployeeID = parameters.GetValue<Guid>("employeeID");
            
            try
            {
                 await GetAndReplaceAllSkills();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await _userDialogs.AlertAsync(ex.Message, "Error");
            }
        }

        private async void OpenAddSkillActionSheet()
        {
            var cfg = new ActionSheetConfig()
                        .SetTitle("Select Action");
            try
            {
                _skillCache = await _skillsService.GetAllSkillsAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await _userDialogs.AlertAsync(ex.Message, "Error");
            }

            foreach (var skill in _skillCache)
            {
                cfg.Add(skill.Name, async () => await AddSkillToEmployee(skill.ID));
            }

            cfg.SetCancel("Cancel");

            _userDialogs.ActionSheet(cfg);
        }

        private async Task AddSkillToEmployee(Guid skillID)
        {
            var selectedSkill = _skillCache.FirstOrDefault(s => s.ID == skillID) ??
                throw new InvalidOperationException($"Skill {skillID} Does not exist");
            try
            {
                await _employeesService.AddSkillToEmployeeAsync(_currentEmployeeID, selectedSkill);
                EmployeeSkills.Add(selectedSkill);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await _userDialogs.AlertAsync(ex.Message, "Error");
            }
        }

        private void DisplayEmployeeSkillActionSheet(Skill skill)
        {
            var cfg = new ActionSheetConfig()
                        .SetTitle("Select Action");

            cfg.Add("Remove Skill", async () => await RemoveSkillFromEmployee(skill));

            cfg.SetCancel("Cancel");

            _userDialogs.ActionSheet(cfg);

        }

        private async Task RemoveSkillFromEmployee(Skill skill)
        {
            try
            {
                await _employeesService.RemoveSkillFromEmployeeAsync(_currentEmployeeID, skill.ID);
                EmployeeSkills.Remove(skill);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await _userDialogs.AlertAsync(ex.Message, "Error");
            }
        }

        private async void RefreshSkills()
        {
            IsRefreshing = true;
            try
            {
                await GetAndReplaceAllSkills();
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

        private async Task GetAndReplaceAllSkills()
        {
            var employeeSkills = await _employeesService.GetEmployeeSkillsAsync(_currentEmployeeID);
            EmployeeSkills.ReplaceRange(employeeSkills);
        }

    }
}
