

namespace todo
{
    internal class Todo_Task
    {
        private string name;
        private string description;
        private DateTime time;
        private int priority;
        private bool done = false;

        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public DateTime Time { get { return time; } set { time = value; } }
        public int Priority { get { return priority; } set { priority = value; } }

        public bool Done { get { return done; } set { done = value; } }
        public Todo_Task(Todo_Task task)
        {
            this.name = task.Name;
            this.description = task.Description;
            this.time = task.Time;
            this.priority = task.Priority;
        }
        public Todo_Task(string name, string description, DateTime time, int priority)
        {
            this.name=name; ;
            this.description = description;
            this.time = time;
            this.priority = priority;
        }
        
        public Todo_Task()
        {
            this.name = "Default";
            this.time =DateTime.Now;
            this.description = "Test";
            this.priority = 100;
        }
    }
}


