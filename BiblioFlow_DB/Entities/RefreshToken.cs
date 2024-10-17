using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_DB.Entities
{
	public class RefreshToken
	{
		public int TokenId { get; set; }
		public string Token { get; set; } = null!;
		public DateTime ExpiryDate { get; set; }
		public bool IsRevoked { get; set; }

		public Guid UserId { get; set; }
		public User User { get; set; } = null!;
	}
}
