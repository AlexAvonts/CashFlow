using System;
using System.ComponentModel.DataAnnotations;

namespace CashFlow.Application.ViewModels
{
    public class FlowViewModel
    {
        public Guid Id { get; set; }
        public double Value { get; set; }

        [Required(ErrorMessage = "Campo FlowType, não pode ser nulo/branco")]        
        public string FlowType { get; set; }
    }
}
