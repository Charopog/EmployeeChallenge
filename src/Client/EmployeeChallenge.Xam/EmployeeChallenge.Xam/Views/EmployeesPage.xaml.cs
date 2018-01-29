
namespace EmployeeChallenge.Xam.Views
{
    using EmployeeChallenge.Xam.Model;
    using EmployeeChallenge.Xam.ViewModels;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public partial class EmployeesPage : ContentPage
    {
        private EmployeesPageViewModel _vm
        {
            get { return BindingContext as EmployeesPageViewModel; }
        }

        public EmployeesPage()
        {
            InitializeComponent();
        }

        private async void EmployeeList_OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            await Task.Delay(20);
            EmployeeListView.SelectedItem = null;
        }

        private async void EmployeeList_OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            var menuOption = args.Item as Employee;
            _vm.DisplayEmployeeActionSheetCommand.Execute(menuOption);
            await Task.Delay(20);
            EmployeeListView.SelectedItem = null;
        }
    }
}
