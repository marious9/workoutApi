using System.Collections.Generic;
using Newtonsoft.Json;

namespace workout_app.Core.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<UserTraining> UserTrainings { get; set; }
    }
}