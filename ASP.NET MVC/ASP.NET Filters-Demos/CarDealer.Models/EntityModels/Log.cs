using System;

namespace CarDealer.Models.EntityModels
{
    public class Log
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public OperationLog Operation { get; set; }

        public string ModifiedTableName { get; set; }

        public DateTime ModifiedAt { get; set; }
    }

    public enum OperationLog
    {
        Add, Edit, Delete
    }
}
