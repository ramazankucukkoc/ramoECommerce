using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class RefreshToken : Entity
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        //Revoked Iptal edilmiş zaman demektir.
        public DateTime? Revoked { get; set; }
        public string? RevokedByIp { get; set; }
        public string? ReplcaedByToken { get; set; }
        public string? ReasonRevoked { get; set; }
        public virtual User User { get; set; }

        public RefreshToken()
        {

        }
        public RefreshToken(int id, string token, DateTime expires, DateTime created, string createdByIp, DateTime? revoked,
            string revokedByIp, string replaceByToken, string reasonRevoked)
        {
            Id = id;
            Token = token;
            Expires = expires;
            Created = created;
            CreatedByIp = createdByIp;
            Revoked = revoked;
            ReasonRevoked = reasonRevoked;
            RevokedByIp = revokedByIp;
            ReplcaedByToken = replaceByToken;
        }
    }
}
