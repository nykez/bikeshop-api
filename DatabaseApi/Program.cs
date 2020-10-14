using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DatabaseApi {
	/// <summary>
	/// The main class that builds/runs the host and calls configuration.
	/// </summary>
	public class Program {
		/// <summary>
		/// Main method builds and runs the host.
		/// </summary>
		/// <param name="args">Arguments for the host passed in at runtime.</param>
		public static void Main(string[] args) {
			CreateHostBuilder(args).Build().Run();
		}

		/// <summary>
		/// Creates the host builder to allow creation of the host.
		/// </summary>
		/// <param name="args">Arguments for the host passed in at runtime.</param>
		/// <returns>A host builder interface.</returns>
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder => {
					webBuilder.UseStartup<Startup>();
				});
	}
}
