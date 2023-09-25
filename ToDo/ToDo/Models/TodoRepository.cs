namespace ToDo.Models
{
    public static class TodoRepository
    {
        public static List<Todo> Todos {  get; set; } = new List<Todo>() // Use 'new' to create a List<Todo>
            {
                new Todo
                {
                    Id = 1,
                    Title = "Go grocery shopping",
                    Description = "Buy fruits, vegetables, and milk",
                },
                new Todo
                {
                    Id = 2,
                    Title = "Finish work report",
                    Description = "Complete the report for the upcoming meeting",
                },
                new Todo
                {
                    Id = 3,
                    Title = "Plan weekend trip",
                    Description = "Research and plan a weekend getaway",
                },
                new Todo
                {
                    Id = 4,
                    Title = "Attend webinar",
                    Description = "Participate in the online seminar on AI",
                },
                new Todo
                {
                    Id = 5,
                    Title = "Read a book",
                    Description = "Spend some time reading a novel",
                }
            };
    }
}
