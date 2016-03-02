using System;
using System.Collections.Generic;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class CreateOrderQuery
    {
        public IEnumerable<AddOrderedProductQuery> OrderedProducts { get; set; }
        public AddPersonQuery Person { get; set; }

        public class AddOrderedProductQuery
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

        public class AddPersonQuery
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
        }
    }

    public class OrdersBL
    {
        private readonly IOrderedProductsRepository _orderedProductsRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderStatusHistoryItemsRepository _orderStatusHistoryItemsRepository;
        private readonly IPersonsRepository _personsRepository;

        public OrdersBL(IPersonsRepository personsRepository, IOrdersRepository ordersRepository,
            IOrderStatusHistoryItemsRepository orderStatusHistoryItemsRepository,
            IOrderedProductsRepository orderedProductsRepository)
        {
            _personsRepository = personsRepository;
            _ordersRepository = ordersRepository;
            _orderStatusHistoryItemsRepository = orderStatusHistoryItemsRepository;
            _orderedProductsRepository = orderedProductsRepository;
        }

        public Order CreateOrder(CreateOrderQuery createOrderQuery)
        {
            Person person = _personsRepository.Add(new Person
                {
                    Email = createOrderQuery.Person.Email,
                    FirstName = createOrderQuery.Person.FirstName,
                    LastName = createOrderQuery.Person.LastName,
                    MiddleName = createOrderQuery.Person.MiddleName,
                    PhoneNumber = createOrderQuery.Person.PhoneNumber
                });

            Order order = _ordersRepository.Add(new Order
                {
                    Person = person
                });

            _orderStatusHistoryItemsRepository.Add(new OrderStatusHistoryItem
                {
                    Created = DateTime.Now,
                    OrderId = order.Id,
                    Status = OrderStatus.Open
                });

            foreach (CreateOrderQuery.AddOrderedProductQuery addOrderedProductQuery in createOrderQuery.OrderedProducts)
            {
                _orderedProductsRepository.Add(new OrderedProduct
                    {
                        ProductId = addOrderedProductQuery.ProductId,
                        Quantity = addOrderedProductQuery.Quantity,
                        OrderId = order.Id
                    });
            }

            return order;
        }
    }
}