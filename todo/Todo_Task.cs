using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace todo
{
    internal class Todo_Task //: IEnumerable<Todo_Task>
    {
        private string name;
        private string description;
        private DateTime time;
        private int priority;

        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public DateTime Time { get { return time; } set { time = value; } }
        public int Priority { get { return priority; } set { priority = value; } }

        public Todo_Task(Todo_Task task)
        {
            this.name = task.Name;
            this.description = task.Description;
            this.time = task.Time;
            this.priority = task.Priority;
        }
        public Todo_Task(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public Todo_Task(string name, string description, DateTime time)
        {
            this.name =name;
            this.description = description;
            this.time = time;
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

    /*    public IEnumerator<Todo_Task> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    */
    }
}


