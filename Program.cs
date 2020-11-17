using System;
using System.Collections.Generic;
using System.IO;

namespace GitCloneUtilityInCsharp
{
	class Program
	{
		static string gitClonePath = @"D:\gitclonetest";
		static List<string> gitRepoURLList = new List<string>()
		{
			"https://github.com/abpframework/abp-samples.git",
			"https://github.com/primefaces/primeng.git",
			"https://github.com/microsoft/ApplicationInspector.git",
			"https://github.com/Azure/aspnet-redis-providers.git",
			"https://github.com/dotnet/aspnetcore.git",
			"https://github.com/aspnet/Docs.git",
			"https://github.com/dsternlicht/RESTool.git",
			"https://github.com/hajekj/azure-functions-openapi-demo.git",
			"https://github.com/Azure/azure-libraries-for-net.git",
			"https://github.com/aliencube/AzureFunctions.Extensions.git",
			"https://github.com/dotnet-presentations/blazor-workshop.git",
			"https://github.com/paragpkulkarni/SampleCode.git",
			"https://github.com/ardalis/CleanArchitecture.git",
			"https://github.com/cofoundry-cms/cofoundry.git",
			"https://github.com/OrchardCMS/OrchardCore.git",
			"https://github.com/Azure-Samples/azure-cosmos-db-graph-gremlindotnet-getting-started.git",
			"https://github.com/davidfowl/AspNetCoreDiagnosticScenarios.git",
			"https://github.com/davidfowl/BedrockFramework.git",
			"https://github.com/davidfowl/FeatherHttp.git",
			"https://github.com/davidfowl/Micronetes.git",
			"https://github.com/davidfowl/Todos.git",
			"https://github.com/natemcmaster/dotnet-serve.git",
			"https://github.com/riganti/dotvvm-samples-academy.git",
			"https://github.com/riganti/dotvvm-samples-blazingpizza.git",
			"https://github.com/dotnet-architecture/eShopOnContainers.git",
			"https://github.com/grandnode/grandnode.git",
			"https://github.com/nopSolutions/nopCommerce.git",
			"https://github.com/simplcommerce/SimplCommerce.git",
			"https://github.com/smartstore/SmartStoreNET.git",
			"https://github.com/aspnet/EntityFrameworkCore.git",
			"https://github.com/Rodrigolmti/flutter_clean_architecture.git",
			"https://github.com/ionic-team/cs-demo-ac-iv.git",
			"https://github.com/ionic-team/ionic-conference-app.git",
			"https://github.com/mbdavid/LiteDB.git",
			"https://github.com/dotnet-architecture/eShopOnWeb.git",
			"https://github.com/mspnp/microservices-reference-implementation.git",
			"https://github.com/simplcommerce/SimplCommerce.git",
			"https://github.com/AzureAD/microsoft-identity-web.git",
			"https://github.com/guptaanmol184/LibraryManagementSystem.git",
			"https://github.com/Cosaquee/Renter.git",
			"https://github.com/codecypher/NorthwindForms.git",
			"https://github.com/jasontaylordev/NorthwindTraders.git",
			"https://github.com/dodyg/practical-aspnetcore.git",
			"https://github.com/uglide/RedisDesktopManager.git",
			"https://github.com/uglide/pyotherside.git",
			"https://github.com/uglide/qredisclient.git",
			"https://github.com/benlau/asyncfuture.git",
			"https://github.com/redis/hiredis.git",
			"https://github.com/aliasaria/scrumblr.git",
			"https://github.com/ariacom/Seal-Report.git",
			"https://github.com/sergeysyrovatchenko/SQLIndexManager.git",
			"https://github.com/microsoft/sql-server-samples.git",
			"https://github.com/StackExchange/StackExchange.Redis.git",
			"https://github.com/Aguafrommars/TheIdServer.git",
			"https://github.com/aelassas/Wexflow.git",
			"https://github.com/xunit/xunit.git"
		};
		static void Main(string[] args)
		{

			foreach (var gitURL in gitRepoURLList)
			{
				string gitReporURL = gitURL;
				try
				{					
					CloneTheGitRepo(gitReporURL, gitClonePath);
				}
				catch(Exception ex)
				{
					Console.WriteLine($"exception while cloning the repo {gitReporURL}. Exception {ex}");
				}

			};
		}

		private static void CloneTheGitRepo(string gitReporURL, string gitClonePath)
		{
			var repoName = gitReporURL.Substring(gitReporURL.LastIndexOf("/") + 1);
			var folderName = repoName.Substring(0, repoName.LastIndexOf("."));
			Console.WriteLine($"Creating folder {folderName}");

			var gitCloneFolderPath = Path.Combine(gitClonePath, folderName);
			var folderCreateCommand = $"md {gitCloneFolderPath}";
			ExecuteCommandSync(folderCreateCommand);
			var gitCloneCommand = $"git clone {gitReporURL} {gitCloneFolderPath}";
			ExecuteCommandSync(gitCloneCommand);
		}

		public static void ExecuteCommandSync(object command)
		{
			// Following code is borrowed from https://www.codeproject.com/Articles/25983/How-to-Execute-a-Command-in-C
			try
			{
				Console.WriteLine($"Begin Executing command {command}");
				// create the ProcessStartInfo using "cmd" as the program to be run,
				// and "/c " as the parameters.
				// Incidentally, /c tells cmd that we want it to execute the command that follows,
				// and then exit.
				System.Diagnostics.ProcessStartInfo procStartInfo =
					new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

				// The following commands are needed to redirect the standard output.
				// This means that it will be redirected to the Process.StandardOutput StreamReader.
				procStartInfo.RedirectStandardOutput = true;
				procStartInfo.UseShellExecute = false;
				// Do not create the black window.
				procStartInfo.CreateNoWindow = true;
				// Now we create a process, assign its ProcessStartInfo and start it
				System.Diagnostics.Process proc = new System.Diagnostics.Process();
				proc.StartInfo = procStartInfo;
				proc.Start();
				// Get the output into a string
				string result = proc.StandardOutput.ReadToEnd();
				// Display the command output.
				Console.WriteLine(result);
				Console.WriteLine($"end Executing command {command}");

			}
			catch (Exception objException)
			{
				// Log the exception
			}
		}
	}
}
