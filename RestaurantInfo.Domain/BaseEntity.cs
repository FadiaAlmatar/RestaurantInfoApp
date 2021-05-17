using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantInfo.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public DateTime? ModificationTime { get; set; }

        public void Delete ()
        {
            IsDeleted = true;
            DeletionTime = DateTime.Now;
        }
        public void SetCreationTime()
        {
            CreationTime = DateTime.Now;
        }
    }
}
