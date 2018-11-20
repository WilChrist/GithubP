using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GithubP.Pages
{
    public partial class ReposPage : ContentPage
    {
        public ReposPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            LoadReposAsync();
            base.OnAppearing();
        }

        private async void LoadReposAsync()
        {
            reposListView.IsRefreshing = true;

            var repos = await Helpers.RepositoryHelper.GetAsync("created");

            this.BindingContext = repos;
            reposListView.ItemsSource = repos;

            reposListView.IsRefreshing = false;
        }
    }
}
