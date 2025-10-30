using Taskbit.Server.Controllers;
using Taskbit.Server.Entities;

namespace Taskbit.Server.Models
{
    public class TasksModel
    {
        public List<Tasks> ViewTasks()
        {
            Tasks tasks1;
            List<Tasks> Lista = new List<Tasks>();
            try
            {
                List<Tasks> aux = TasksController.GetTasks();
                foreach (Tasks obj in aux)
                {
                    tasks1 = new Tasks(obj.Id_tasks, obj.Description, obj.DueDate, obj.Priority,obj.Title,obj.Id_users);
                    Lista.Add(tasks1);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new ModelExceptions("Error to get the Tasks", ex);
            }
        }

        public Tasks GetTasks(int id)
        {
            try
            {
                Tasks result = TasksController.GetTasksById(id).Result;
                return result;
            }
            catch (Exception ex)
            {
                throw new ModelExceptions("Error to convert the tasks", ex);
            }
        }
        public bool CreateTasks(Tasks obj)
        {
            try
            {
                TasksController.InsertTasks(obj);
                return true;
            }
            catch (Exception ex)
            {
                throw new ModelExceptions("Error to insert the tasks", ex);
            }
        }

        public bool EditTasks(Tasks obj)
        {
            try
            {
                TasksController.UpdateTasks(obj);
                return true;
            }
            catch (Exception ex)
            {
                throw new ModelExceptions("Error to update the tasks", ex);
            }
        }

        public bool RemoveTasks(int id)
        {
            try
            {
                TasksController.DeleteTasks(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new ModelExceptions("Error to delete the tasks", ex);
            }
        }
    }
}
