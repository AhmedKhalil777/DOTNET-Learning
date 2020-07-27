using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Database.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime OverDueDate { get; set; }
        public bool IsPaid { get; set; }
    }
}
