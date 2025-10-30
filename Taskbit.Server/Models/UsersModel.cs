using Taskbit.Server.Controllers;
using Taskbit.Server.Entities;

namespace Taskbit.Server.Models
{
    public class UsersModel
    {
        public List<Users> ViewUsers()
        {
            Users user1;
            List<Users> Lista = new List<Users>();
            try {
                List<Users> aux = UsersController.GetUsers();
                foreach(Users obj in aux)
                {
                    user1 = new Users(obj.Id_users, obj.Username, obj. PasswordHash);
                    Lista.Add(user1);
                }
                return Lista;
            }catch(Exception ex)
            {
                throw new ModelExceptions("Error to get the users", ex);
            }
        }

        public Users GetUser(int id)
        {
            try
            {
                Users result = UsersController.GetUserById(id).Result; //No requires converting the Task to user. Simply Use The Task Result.
                return result;
            }
            catch (Exception ex)
            {
                throw new ModelExceptions("Error to convert the user", ex);
            }
        }
        public bool CreateUser(Users obj)
        {
            try {
                UsersController.InsertUser(obj);
                return true;
            }
            catch(Exception ex)
            {
                throw new ModelExceptions("Error to insert the user", ex);
            }
        }

        public bool EditUser(Users obj)
        {
            try {
                UsersController.UpdateUser(obj);
                return true;
            }
            catch(Exception ex)
            {
                throw new ModelExceptions("Error to update the user", ex);
            }
        }

        public bool RemoveUser(int id)
        {
            try {
                UsersController.DeleteUser(id);
                return true;
            }
            catch(Exception ex)
            {
                throw new ModelExceptions("Error to delete the user", ex);
            }
        }
    }
}
