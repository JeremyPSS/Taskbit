using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Taskbit.Server.Entities;


namespace Taskbit.Server.Controllers
{
    public class TasksController : Controller
    {
        static HttpClient client = new HttpClient();

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://localhost:7280/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );  
        }

        public static List<Tasks> GetTasks()
        {
            try
            {
                List<Tasks> listTasks = null;
                HttpResponseMessage response = client.GetAsync("api/Tasks").Result;
                if (response.IsSuccessStatusCode)
                {
                    listTasks = response.Content.ReadAsAsync<List<Tasks>>().Result;
                }
                return listTasks;
            }
            catch (Exception ex)
            {
                throw new Exception("Error API to get all tasks", ex);
            }
        }

        public static async Task<Tasks> GetTasksById(int id) 
        {
            try
            {
                Tasks tasks = null;
                HttpResponseMessage response = await client.GetAsync($"api/Tasks/{id}");
                if (response.IsSuccessStatusCode)
                {
                    tasks = await response.Content.ReadAsAsync<Tasks>(); 
                }
                return tasks;
            }
            catch (Exception ex)
            {
                throw new Exception("Error API to get the tasks", ex);
            }
        }
        public static async void InsertTasks(Tasks obj)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Tasks", obj); 
                response.EnsureSuccessStatusCode();

            }
            catch (Exception ex)
            {
                throw new Exception("Error API to get the tasks", ex);
            }
        }

        public static async void UpdateTasks(Tasks obj)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/Tasks/{obj.Id_tasks}", obj);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception("Error API to get the tasks", ex);
            }
        }
        public static async void DeleteTasks(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"api/Tasks/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error API to delete the tasks", ex);
            }
        }
    }
}
