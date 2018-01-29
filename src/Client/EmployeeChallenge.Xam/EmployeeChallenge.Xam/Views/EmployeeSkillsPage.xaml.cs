
namespace EmployeeChallenge.Xam.Views
{
    using EmployeeChallenge.Xam.Model;
    using EmployeeChallenge.Xam.ViewModels;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public partial class EmployeeSkillsPage : ContentPage
    {
        private EmployeeSkillsPageViewModel _vm
        {
            get { return BindingContext as EmployeeSkillsPageViewModel; }
        }

        public EmployeeSkillsPage()
        {
            InitializeComponent();
        }

        private async void EmployeeSkillsList_OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            await Task.Delay(20);
            EmployeeSkillsListView.SelectedItem = null;
        }

        private async void EmployeeSkillsList_OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            var menuOption = args.Item as Skill;
            _vm.DisplayEmployeeSkillActionSheetCommand.Execute(menuOption);
            await Task.Delay(20);
            EmployeeSkillsListView.SelectedItem = null;
        }
    }
}
