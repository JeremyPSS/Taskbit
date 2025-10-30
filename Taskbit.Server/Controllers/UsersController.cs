using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Taskbit.Server.Entities;

namespace Taskbit.Server.Controllers
{
    public class UsersController : Controller
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
        public static List<Users> GetUsers()
        {
            try
            {
                //RunAsync().Wait(); //Wait for the async method to complete
                List<Users> listUsers = null;
                HttpResponseMessage response = client.GetAsync("api/Users").Result; //Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    listUsers = response.Content.ReadAsAsync<List<Users>>().Result; //Deserialize the JSON payload to a list of users
                }
                return listUsers;
            }
            catch (Exception ex) { 
                throw new Exception("Error API to get all users", ex);
            }


        }

        public static async Task<Users> GetUserById(int id) //task is a reserve class from async methods
        {
            try 
            { 
                Users user = null;
                HttpResponseMessage response = await client.GetAsync($"api/Users/{id}");
                if (response.IsSuccessStatusCode)
                { 
                    user = await response.Content.ReadAsAsync<Users>(); //deserialize the JSON payload to a user instance
                }
                return user;
            }catch(Exception ex)
            {
                throw new Exception("Error API to get the user", ex);
            }
        }

        /**
         * If the request is successful, will return a status code 201 (Created).
         * The response should include the URL of the created resources in the Location header.
         */
        public static async void InsertUser(Users obj)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Users", obj); //PostAsJsonAsync serialize to JSON and send it to a POST Request
                response.EnsureSuccessStatusCode(); //Throw an exception if the HTTP response is an error code.

                // return URI of the created resource.
                //return response.Headers.Location;
            }
            catch (Exception ex)
            {
                throw new Exception("Error API to get the user", ex);
            }
        }

        public static async void UpdateUser(Users obj)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/Users/{obj.Id_users}", obj);
                response.EnsureSuccessStatusCode();

                // Deserialize the updated user from the response body.
                //obj = await response.Content.ReadAsAsync<Users>();
                //return obj
            }
            catch (Exception ex) {
                throw new Exception("Error API to get the user", ex);
            }
        }
        public static async void DeleteUser(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"api/Users/{id}");
                //return response.StatusCode;
            }
            catch (Exception ex) {
                throw new Exception("Error API to delete the user", ex);
            }
        }
    }
}
