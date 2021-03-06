﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.Sample.Database.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime OverDueDate { get; set; }
        public bool IsPaid { get; set; }

        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }

        public Property Property { get; set; }
    }
}
