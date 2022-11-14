using AutoMapper;
using CashFlow.Application.AutoMapper;
using CashFlow.Application.Services;
using CashFlow.Application.ViewModels;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace CashFlow.Application.Tests.Services
{
    public class FlowServiceTests
    {
        private FlowService flowService;

        public FlowServiceTests()
        {
            flowService = new FlowService(new Mock<IFlowRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void Post_SendingValidId()
        {
            var exception = Assert.Throws<Exception>(() => flowService.Post(new ViewModels.FlowViewModel()));

            Assert.Equal("ID da transação não pode ser nula", exception.Message);
        }

        [Fact]
        public void GetById_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => flowService.GetById(""));
            Assert.Equal("Transação inválida", exception.Message);
        }

        [Fact]
        public void GetById_SendingInvalidGuid()
        {
            var exception = Assert.Throws<Exception>(() => flowService.GetById("FF015441-BD5A-4DB7-9C9B-CC3134C6911D"));
            Assert.Equal("Transação não encontrada", exception.Message);
        }

        [Fact]
        public void Put_SendingInvalidId()
        {
            FlowViewModel flowViewModel = new FlowViewModel();
            flowViewModel.Id = Guid.NewGuid();

            var exception = Assert.Throws<Exception>(() => flowService.Put(flowViewModel));
            Assert.Equal("Transação não encontrada", exception.Message);
        }

        [Fact]
        public void Delete_SendingInvalidGuid()
        {
            var exception = Assert.Throws<Exception>(() => flowService.Delete("3FA85F64-5717-4562-B3FC-2C963F66AFA6"));
            Assert.Equal("Transação não encontrada", exception.Message);
        }

        [Fact]
        public void Post_SendingValidObject()
        {
            var result = flowService.Post(new FlowViewModel { Id = Guid.NewGuid(), Value = 12.5, FlowType = "C" });
            Assert.True(result); 
        }

        [Fact]
        public void Post_SendingInvalidValidObject()
        {
            var exception = Assert.Throws<ValidationException>(() => flowService.Post(new FlowViewModel 
                { Id = Guid.NewGuid(), Value = 12.5 }));
            Assert.Equal("The FlowType field is required.", exception.Message);
        }

        [Fact]
        public void Get_ValidateObject()
        {
            List<Flow> _flows = new List<Flow>();
            _flows.Add(new Flow { Id = Guid.NewGuid(), Value = 10, FlowType = "C", DateCreated = DateTime.Now  });

            var _flowRepository = new Mock<IFlowRepository>();
            _flowRepository.Setup(x => x.GetAll()).Returns(_flows);

            var _autoMapperProfile = new CashFlow.Application.AutoMapper.AutoMapperSetup();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);

            flowService = new FlowService(_flowRepository.Object, _mapper);
            var result = flowService.Get();
            Assert.True(result.Count > 0);
        }

    }
}
