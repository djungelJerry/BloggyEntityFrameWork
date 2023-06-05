using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggyEntityFrameWork
{
	internal class Category
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }

		public List<BlogPost> blogPosts { get; set; }
	}
}
