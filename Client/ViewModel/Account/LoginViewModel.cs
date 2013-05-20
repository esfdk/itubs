
namespace Client.ViewModel.Account
{
    using Client.Model;
    using Client.Types;

    public static class LoginViewModel
    {
        public static RequestResult Login(string username, string password)
        {
            return PersonModel.Login(username, password);
        }
    }
}