namespace WebApiAuthentication.Models
{

    public class UserConstants
    {
        public static List<User> users = new List<User>()
        {
            new User(){UserName="admin", EmailAddress="luke.admin@email.com",Password="123",GivenName="Luke",SurName="Rogers",Role="Administrator"},
            new User(){UserName="user", EmailAddress="lydia.standard@email.com",Password="123",GivenName="Elyse",SurName="Burtonn",Role="Standard"},
        };
    }
}
