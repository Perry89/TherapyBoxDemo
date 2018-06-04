using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace TherapyBoxDemo.PageModels
{
    public class TaskPageModel : FreshBasePageModel
    {
        public TaskPageModel()
        {
            var list = new List<TaskItems>();
            list.Add(new TaskItems { TaskName = "Task1", TaskToggle = true });
            list.Add(new TaskItems { TaskName = "Task2", TaskToggle = false });
            list.Add(new TaskItems { TaskName = "Task3", TaskToggle = false });
            list.Add(new TaskItems { TaskName = "Task4", TaskToggle = false });
            list.Add(new TaskItems { TaskName = "Task5", TaskToggle = false });
            list.Add(new TaskItems { TaskName = "Task6", TaskToggle = false });
            list.Add(new TaskItems { TaskName = "Task7", TaskToggle = true });
            list.Add(new TaskItems { TaskName = "Task8", TaskToggle = true });
            TaskList = list;

        }
        private List<TaskItems> _taskList;
        public List<TaskItems> TaskList
        {
            get
            {
                return _taskList;
            }
            set
            {
                _taskList = value;
                RaisePropertyChanged("TaskList");
            }
        }
    }
    public class TaskItems
    {
        public string TaskName { get; set; }
        public bool TaskToggle { get; set; }
    }
}
