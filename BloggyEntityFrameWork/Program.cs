using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using BloggyEntityFrameWork;
using BloggyEntityFrameWork.Migrations;
using Microsoft.EntityFrameworkCore;

bool KeepRunning=true;

MyDbContext Context = new MyDbContext();


while (KeepRunning)
{

	//Console.WriteLine("Vill du skapa en ny blogg J/N?");
	//string NybloggJaNej = Console.ReadLine();
	//if (NybloggJaNej == "J")
	//{
	//	Console.WriteLine("Kategori: ");

	//	Category category = new Category();
	//	category.Name = Console.ReadLine();
	//	Context.categories.Add(category);

	//	Console.WriteLine("Blogg Titel: ");
	//	BlogPost blogpost = new BlogPost();
	//	blogpost.Name = Console.ReadLine();


	//	Console.WriteLine("Blogg Text: ");
	//	blogpost.Content = Console.ReadLine();
	//	Context.blogs.Add(blogpost);

	//	Context.SaveChanges();

	//	continue;

	//}

	//else if (NybloggJaNej == "N")
	//{
	//	Console.WriteLine("Visar Meny ");
	//}


	Console.WriteLine("1. För att visa alla inlägg, tryck 1");
	Console.WriteLine("2. För att visa alla kategorier, tryck 2");
	Console.WriteLine("3. För att lägga till ett nytt blogginlägg, tryck 3");
	Console.WriteLine("4. För att lägga till en ny kategori, tryck 4");
	Console.WriteLine("5. För att visa alla blogg titlar från en särskild kategori, tryck 5");
	Console.WriteLine("6. Lägg till en skapad blogg till en tidigare använd kategori");
	Console.WriteLine("7. Tryck q för att avsluta");
	string UserChoice = Console.ReadLine();


	if (UserChoice == "1")
	{
		Console.WriteLine("Visa alla inlägg");
		foreach (BlogPost blog in Context.blogs)
			Console.WriteLine(blog.Name);
	}

	if (UserChoice == "2")
	{
		Console.WriteLine("Visa alla kategorier");
		foreach (Category categories in Context.categories)
			Console.WriteLine(categories.Name);
	}
	if (UserChoice == "3")
	{
		Console.WriteLine("Lägg till ett nytt blogginlägg");

		Category category = new Category();
		Console.WriteLine("Kategori:");
		category.Name = Console.ReadLine();
		Context.categories.Add(category);


		Console.WriteLine("Titel:");
		BlogPost blogpost = new BlogPost();
		blogpost.Name = Console.ReadLine();



		if (blogpost.Categories == null)
		{
			blogpost.Categories = new List<Category>();
		}
		blogpost.Categories.Add(category);
		Console.WriteLine("Text:");
		blogpost.Content = Console.ReadLine();
		Context.blogs.Add(blogpost);
		Context.SaveChanges();



	}

	if (UserChoice == "4")
	{
		Console.WriteLine("Lägg till en ny kategori");
		Category category = new Category();
		category.Name = Console.ReadLine();
		if (Context.categories.FirstOrDefault(x => x.Name == category.Name) != null)
		{
			Console.WriteLine("Denna kategori existerar redan.");
		}
		else
		{
			Context.categories.Add(category);

		}

		Context.SaveChanges();
	}
	if (UserChoice == "5")
	{
		Console.WriteLine("Visa alla blog titlar från en särskild kategori");
		string UserSearch = Console.ReadLine();

		List<BlogPost> BlogTitlar = Context.blogs.Include(u => u.Categories).ToList();
		{


			foreach (BlogPost item in Context.blogs.ToList())
			{
				bool match = false;
			
				foreach (Category item2 in item.Categories.ToList())
				{

					if (item2.Name == UserSearch)
					{
						match = true;
						Console.WriteLine(item.Name);
					}
				}

				
			}
		}
	}
	




	

	if (UserChoice == "6")
	{
		Console.WriteLine("Lägg till en skapad blogg till en tidigare använd kategori");

		foreach (BlogPost blog in Context.blogs)
			Console.WriteLine(blog.Name);

		

		Console.WriteLine("Skriv vilken blogg du vill lägga till i en kategori");
		Console.WriteLine();
		string bloggname = Console.ReadLine();

		

		Console.WriteLine("Skriv Vilken kategori du vill lägga till den i");
		Console.WriteLine();
		foreach (Category categories in Context.categories)
			Console.WriteLine(categories.Name);
		Console.WriteLine();
		string categoryname = Console.ReadLine();
		BlogPost CurrentBlog = Context.blogs.FirstOrDefault(c => c.Name == bloggname);
		Category category = new Category();
		category.Name = categoryname;
		if(CurrentBlog.Categories == null)
		CurrentBlog.Categories = new List<Category>();
		CurrentBlog.Categories.Add(category);
		Context.blogs.Update(CurrentBlog);
		Context.SaveChanges();
		
	}




	if (UserChoice == "q")
	{
		KeepRunning = false;
		Console.WriteLine("herrå");
	}
}







