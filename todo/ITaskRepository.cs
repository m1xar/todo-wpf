using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo
{
    internal interface ITaskRepository
    {
        void Insert(Todo_Task task);
        Todo_Task Get(string name);
        List<Todo_Task> Select();
        void Delete(string name);
        void Update(Todo_Task task);

    }
}
