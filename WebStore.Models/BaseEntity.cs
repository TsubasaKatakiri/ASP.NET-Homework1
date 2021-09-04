using System;

namespace WebStore.Models
{
    /*
     Generating unique ID for all models
    */
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
