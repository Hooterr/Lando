using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using System;
using Application = Microsoft.Maui.Controls.Application;

namespace Lando
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

            MainPage = new AppShell();
		}

    }
}
