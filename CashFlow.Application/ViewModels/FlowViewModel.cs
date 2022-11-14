using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Application.ViewModels
{
    public class FlowViewModel
    {
        public Guid Id { get; set; }
        public double Value { get; set; }

        [Required]
        public string FlowType { get; set; }
    }
}
