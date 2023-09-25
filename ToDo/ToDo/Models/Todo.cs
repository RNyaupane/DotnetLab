namespace ToDo.Models
{
    public class Todo
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } public int Status { get; set; }   

    }
}
