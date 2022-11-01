using System.Data.SqlClient;
using DemoAude___DAL.Interfaces;
using DemoAude___Domain;
using DemoAude___Domain.ViewModel;

namespace DemoAude___DAL.Entities;

public class UserRepository : IUserRepository
{
    private const string connectionString = "Server=localhost\\SQLEXPRESS;Database=DemoAude;Trusted_Connection=True;";
    public bool UserAlreadyExist(string email)
    {
        //SELECT COUNT(*) FROM users WHERE email = 'pom@pomt.be'
        
        SqlConnection conn = new SqlConnection(connectionString);

        SqlCommand command = conn.CreateCommand();

        command.CommandText = "SELECT COUNT(*) FROM users WHERE email = @email";

        command.Parameters.AddWithValue("@email", email);


        int result;
        conn.Open();

        result = (int)command.ExecuteScalar();
        
        conn.Close();

        return result == 1;
    }

    
    public User GetOneByEmail(string Email)
    {
        SqlConnection conn = new SqlConnection(connectionString);

        SqlCommand command = conn.CreateCommand();

        command.CommandText = "SELECT * FROM users WHERE email = @email";

        command.Parameters.AddWithValue("@email", Email);

        User user = new User();
        
        
        conn.Open();
        
        
        SqlDataReader reader = command.ExecuteReader();
        
        while (reader.Read())
        {
            user.Id = (int)reader["id"];
            user.Email = (string)reader["email"];
            user.Password = (string)reader["password"];
        }
        conn.Close();
        
        return user;
    }

    public bool AddUser(UserRegisterViewModel userRegisterViewModel)
    {
        SqlConnection conn = new SqlConnection(connectionString);

        SqlCommand command = conn.CreateCommand();

        command.CommandText = "INSERT INTO users(email, password) VALUES(@email, @password)";

        command.Parameters.AddWithValue("@email", userRegisterViewModel.Email);
        command.Parameters.AddWithValue("@password", userRegisterViewModel.Password);


        int result;
        conn.Open();

        result = command.ExecuteNonQuery();
        
        conn.Close();

        return result == 1;

    }
}