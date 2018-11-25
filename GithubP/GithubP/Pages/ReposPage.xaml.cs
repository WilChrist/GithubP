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

        /// <summary>
        /// get list of repos and bind it to the view, asynchroniously
        /// </summary>
        private async void LoadReposAsync()
        {
            reposListView.IsRefreshing = true;

            var repos = await Helpers.RepositoryHelper.GetAsync("created:%3E2017-10-22&sort=stars&order=desc");

            this.BindingContext = repos;
            reposListView.ItemsSource = repos;

            reposListView.IsRefreshing = false;
        }
    }
}
