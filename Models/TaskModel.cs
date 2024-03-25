using System.ComponentModel.DataAnnotations;

namespace To_do_List.Models
{
	public class TaskModel
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(70)]
		public string Title { get; set; } = string.Empty;

		[Required]
		[MaxLength(300)]
		public string Description { get; set; } = string.Empty;

		public bool IsDone { get; set; } = false;

		public DateTime Date { get; set; } = DateTime.UtcNow;
	}
}