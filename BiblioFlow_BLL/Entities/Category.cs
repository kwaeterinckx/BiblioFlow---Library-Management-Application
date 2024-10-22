using DB = BiblioFlow_DB.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioFlow_BLL.Entities
{
    public class Category
    {
        public int CategoryId { get; }
        public string Name { get; }
        public string? Description { get; }
        public DateTime CreatedAt { get; }
        public DateTime? LastModifiedAt { get; }
        public Guid CreatedByUserId { get; }
        public Guid? LastModifiedByUserId { get; }

        public Category(string name, string? description, DateTime createdAt, DateTime? lastModifiedAt, Guid createdByUserId, Guid? lastModifiedByUserId)
        {
            Name = name;
            Description = description;
            CreatedAt = createdAt;
            LastModifiedAt = lastModifiedAt;
            CreatedByUserId = createdByUserId;
            LastModifiedByUserId = lastModifiedByUserId;
        }

        internal Category(DB.Category category)
            : this(category.Name, category.Description, category.CreatedAt, category.LastModifiedAt, category.CreatedByUserId, category.LastModifiedByUserId)
        {
            CategoryId = category.CategoryId;
        }
    }
}
