using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class OtpAuthenticator:Entity
    {
        public int UserId { get; set; }
        public byte[] SecretKey { get; set; }
        public bool IsVerified { get; set; }
        public virtual User User{ get; set; }
        public OtpAuthenticator()
        {
        }
        public OtpAuthenticator(int id,int userId, byte[]secretKey,bool isVerified):this()
        {
            Id = id;
            UserId = userId;
            SecretKey = secretKey;
            IsVerified = isVerified;
        }
    }
}
