using System.Collections.Generic;
using System.Linq;


namespace sovmm_backend.Models
{
    public class ConnSettings : IConnSettings
    {
        public string AwsBucket { get; set; }
        public string AwsAccessKeyId { get; set; }
        public string AwsSecret { get; set; }
        public string SecretCredentials { get; set; }
        public string ConnUrl { get; set; }
        public string DbName { get; set; }
        public string UserCollectionName { get; set; }
        public string PresidenciaCollectionName { get; set; }
        public string ProyectoCollectionName { get; set; }
    }

    public interface IConnSettings
    {
        public string AwsBucket { get; set; }
        public string AwsAccessKeyId { get; set; }
        public string AwsSecret { get; set; }
        public string SecretCredentials { get; set; }
        public string ConnUrl { get; set; }
        public string DbName { get; set; }
        public string UserCollectionName { get; set; }
        public string PresidenciaCollectionName { get; set; }
        public string ProyectoCollectionName { get; set; }
    }
    
    public  static class HelperMethods
    {
        public static IEnumerable<User> WithoutPassword(this IEnumerable<User> users)
        {
            return users.Select(user => user.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            user.Password = null;
            return user;
        }
    }
}