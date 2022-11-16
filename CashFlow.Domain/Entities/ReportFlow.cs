using CashFlow.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CashFlow.Domain.Entities
{
    public class ReportFlow : Entity
    {
        public string SumValue { get; set; }
        public string Date { get; set; }
    }
}
