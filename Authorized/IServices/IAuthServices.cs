using System.Data;

namespace FinalApi.Authorized.IServices
{
    public interface IAuthServices
    {
        public Task<DataTable> Register(string firstName, string lastName, string email, string password, string conPassword, DateTime dob, string uniqID, string softID, string tokenID);
    }
}
