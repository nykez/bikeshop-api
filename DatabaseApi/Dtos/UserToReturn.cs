using System.Collections.Generic;

namespace DatabaseApi.Dtos
{
    public class UserToReturn
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}