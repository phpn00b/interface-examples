using DependencyInjectionExample;
using DependencyInjectionExample.Repository.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace DependencyInjectionExampleGui
{
	static class Program
	{
		//this should be in a configuration file, in a different class, is here for example purposes 
		private const string _serverUrl = "http://localhost:43615/";

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var services = new ServiceCollection();

			ConfigureServices(services);

			using (ServiceProvider serviceProvider = services.BuildServiceProvider())
			{
				var form1 = serviceProvider.GetRequiredService<Form1>();
				Application.Run(form1);
			}
		}


		private static void ConfigureServices(ServiceCollection services)
		{
			services.AddSingleton<IRepository>(_ => new ApiRepository(_serverUrl));
			services.AddScoped<Form1>();
		}
	}
}
