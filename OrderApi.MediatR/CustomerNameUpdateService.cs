using MediatR;
using OrderApi.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OrderApi.MediatR
{
    public interface ICustomerNameUpdateService
    {
        void UpdateCustomerNameInOrders(UpdateCustomerFullNameModel updateCustomerFullNameModel);
    }
    public class CustomerNameUpdateService : ICustomerNameUpdateService
    {
        private readonly IMediator _mediator;

        public CustomerNameUpdateService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async void UpdateCustomerNameInOrders(UpdateCustomerFullNameModel updateCustomerFullNameModel)
        {
            try
            {
                var ordersOfCustomer = await _mediator.Send(new GetOrderByCustomerIdQuery
                {
                    CustomerId = updateCustomerFullNameModel.Id
                });

                if (ordersOfCustomer.Count != 0)
                {
                    ordersOfCustomer.ForEach(x => x.CustomerFullName = $"{updateCustomerFullNameModel.FirstName} {updateCustomerFullNameModel.LastName}");
                }

                await _mediator.Send(new UpdateOrderCommand
                {
                    Orders = ordersOfCustomer
                });
            }
            catch (Exception ex)
            {
                // log an error message here

                Debug.WriteLine(ex.Message);
            }
        }
    }
}
