using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUP.DataAccessLayer.Entities
{
	public class CourseSection
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Content { get; set; } 
		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}
