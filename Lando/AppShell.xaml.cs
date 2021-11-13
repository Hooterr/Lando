using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace Lando
{
	public partial class AppShell : Shell
    { 

		public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("login", typeof(LoginPage));
            CurrentItem = LoadingShell;

        }
    }
}
