namespace Taskbit.Server.Entities
{
    public class Tasks
    {
        private int id_tasks;
        private string description;
        private string dueDate;
        private char priority;
        private string title;
        private int id_users;


        public Tasks() { }

        public Tasks(int id_tasks_, string description_, string dueDate_, char priority_, string title_, int id_users_)
        {
            id_tasks = id_tasks_;
            description = description_;
            dueDate = dueDate_;
            priority = priority_;
            title = title_;
            id_users = id_users_;
        }

        public int Id_tasks { get => id_tasks; set => id_tasks = value; }
        public string Description { get => description; set => description = value; }
        public string DueDate { get => dueDate; set => dueDate = value; }
        public char Priority { get => priority; set => priority = value; }
        public string Title { get => title; set => title = value; }

        public int Id_users { get => id_users; set => id_users = value; }

    }
}
