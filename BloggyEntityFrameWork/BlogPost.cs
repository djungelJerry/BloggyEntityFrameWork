using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggyEntityFrameWork
{
	internal class BlogPost
	{


		public int BlogPostId { get; set; }
		public string Name { get; set; }
		public string Content { get; set; }
		


		public  List<Category> Categories { get; set; }

	}
}