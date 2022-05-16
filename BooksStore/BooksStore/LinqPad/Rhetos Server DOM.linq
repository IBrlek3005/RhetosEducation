<Query Kind="Program">
  <Reference Relative="..\bin\Autofac.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Autofac.dll</Reference>
  <Reference Relative="..\bin\EntityFramework.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\EntityFramework.dll</Reference>
  <Reference Relative="..\bin\EntityFramework.SqlServer.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\EntityFramework.SqlServer.dll</Reference>
  <Reference Relative="..\bin\BooksStore.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\BooksStore.dll</Reference>
  <Reference>..\bin\Generated\ServerDom.Orm.dll</Reference>
  <Reference>..\bin\Generated\ServerDom.Repositories.dll</Reference>
  <Reference Relative="..\bin\NLog.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\NLog.dll</Reference>
  <Reference Relative="..\bin\Oracle.ManagedDataAccess.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Oracle.ManagedDataAccess.dll</Reference>
  <Reference>..\bin\Rhetos.AspNetFormsAuth.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Dom.DefaultConcepts.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Rhetos.Dom.DefaultConcepts.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Dom.DefaultConcepts.Interfaces.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Rhetos.Dom.DefaultConcepts.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Dsl.DefaultConcepts.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Rhetos.Dsl.DefaultConcepts.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Processing.DefaultCommands.Interfaces.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Rhetos.Processing.DefaultCommands.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Configuration.Autofac.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Rhetos.Configuration.Autofac.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Dom.Interfaces.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Rhetos.Dom.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Dsl.Interfaces.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Rhetos.Dsl.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Interfaces.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Rhetos.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Logging.Interfaces.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Rhetos.Logging.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Persistence.Interfaces.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Rhetos.Persistence.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Processing.Interfaces.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Rhetos.Processing.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Security.Interfaces.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Rhetos.Security.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.TestCommon.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Rhetos.TestCommon.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Utilities.dll">&lt;MyDocuments&gt;\Git\BooksStore\BooksStore\bin\Rhetos.Utilities.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.AccountManagement.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>Rhetos.Configuration.Autofac</Namespace>
  <Namespace>Rhetos.Dom</Namespace>
  <Namespace>Rhetos.Dom.DefaultConcepts</Namespace>
  <Namespace>Rhetos.Dsl</Namespace>
  <Namespace>Rhetos.Dsl.DefaultConcepts</Namespace>
  <Namespace>Rhetos.Logging</Namespace>
  <Namespace>Rhetos.Persistence</Namespace>
  <Namespace>Rhetos.Security</Namespace>
  <Namespace>Rhetos.Utilities</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Data.Entity</Namespace>
  <Namespace>System.DirectoryServices</Namespace>
  <Namespace>System.DirectoryServices.AccountManagement</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Runtime.Serialization.Json</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Xml</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
  <Namespace>Autofac</Namespace>
  <Namespace>Rhetos.TestCommon</Namespace>
  <Namespace>Rhetos</Namespace>
</Query>

void Main()
{
	string applicationFolder = Path.GetDirectoryName(Util.CurrentQueryPath);
	//ConsoleLogger.MinLevel = EventType.Info; // Use EventType.Trace for more detailed log.
	
	using (var scope = ProcessContainer.CreateScope(applicationFolder))
	    {
	        var context = scope.Resolve<Common.ExecutionContext>();
	        var repository = context.Repository;
			
			//Day 2 Load()
			Console.WriteLine("Load()");

			//.Where(q => q.ID == new Guid("24b2abca-f3aa-4515-9d51-90ead2127cb3")).Dump();
			var persons = repository.Bookstore.Person.Load();
			
			//Guid id= new Guid("d5093895-9ffe-4da3-b052-68e437b02d68");
			repository.Bookstore.Book.Load().Dump();
			var books=repository.Bookstore.Book.Load();
			
			foreach (var book in books)
			{
				book.Title.Dump();
				persons.Where(p=> p.ID == book.AuthorID).FirstOrDefault()?.Name.Dump();
			}
			
			repository.Bookstore.Person.Load().Dump();
			//	repository.Bookstore.Book.Load(new[] {id}).Single().Dump();
			
			
			var 

			//Day 2 Query()
			Console.WriteLine("Query()");
			var q3 = repository.Bookstore.Book.Query();
			q3.Where(b=>b.AuthorID != null).Select(b => new { b.Author.Name, b.Title } ).Dump();


			//Day 2 Action
			Console.WriteLine("Action ");
			var action = new Bookstore.InsertMultipleBooks{
				NumberOfBooks =7,
				Title= "A Song of Ice and Fire",
			};
			repository.Bookstore.InsertMultipleBooks.Execute(action);
			repository.Bookstore.Book.Query().Select(book=>book.Title).Dump();
			scope.CommitAndClose();
		
			Console.WriteLine("Filter testing");
			//var filterParameter= new Bookstore.LongBooks();
			//repository.Bookstore.Book.Query(filterParameter).Select(b =>b.Title ).Dump();
			var filterParameter = new Bookstore.LongBooks3{
				MinimumPages=100,
				ForeignBooksOnly= false,
			};
			repository.Bookstore.Book.Query(filterParameter).ToSimple().Dump();

		// Query data from the `Common.Claim` table:

		var claims = repository.Common.Claim.Query()
			.Where(c => c.ClaimResource.StartsWith("Common.") && c.ClaimRight == "New")
			.ToSimple(); // Removes ORM navigation properties from the loaded objects.

		claims.ToString().Dump("Common.Claims SQL query");
		claims.Dump("Common.Claims items");

		// Add and remove a `Common.Principal`:

		//var testUser = new Common.Principal { Name = "Test123", ID = Guid.NewGuid() };
		//repository.Common.Principal.Insert(new[] { testUser });
		//repository.Common.Principal.Delete(new[] { testUser });

		// Print logged events for the `Common.Principal`:

//		repository.Common.LogReader.Query()
//			.Where(log => log.TableName == "Common.Principal" && log.ItemId == testUser.ID)
//			.ToList()
//			.Dump("Common.Principal log");
//
//		Console.WriteLine("Done.");

		//scope.CommitAndClose(); // Database transaction is rolled back by default.

		////Zadaci za vježbu
		Console.WriteLine("Vježba!");
		//var filterParamerar= new Bookstore.LongBooks();
		//var query = repository.Bookstore.Book.Query(filterParamerar);
		//query.ToString().Dump("Query to string");

		//query.ToSimple().ToList().Dump("Query to List");
	}
}

// Define other methods and classes here