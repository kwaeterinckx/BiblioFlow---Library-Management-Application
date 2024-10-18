using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_BLL.Entities
{
    public class RefreshToken
    {
        public int TokenId { get; }
        public string Token { get; }
        public DateTime ExpiresAt { get; }
        public bool IsRevoked { get; }
        public DateTime CreatedAt { get; }
        public Guid UserId { get; }

        public RefreshToken(string token, DateTime expiresAt, bool isRevoked, DateTime createdAt, Guid userId)
        {
            Token = token;
            ExpiresAt = expiresAt;
            IsRevoked = isRevoked;
            CreatedAt = createdAt;
            UserId = userId;
        }
    }
}
