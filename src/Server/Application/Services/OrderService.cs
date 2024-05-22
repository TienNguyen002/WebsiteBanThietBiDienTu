using Domain.DTO.Order;
using Domain.DTO.OrderItem;
using Domain.DTO.Serie;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infrastructure.Repositories;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using System;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IOrderItemRepository _itemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOtherRepository _otherRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IOrderRepository repository, IOrderItemRepository itemRepository, IProductRepository productRepository, IOtherRepository otherRepository, UserManager<ApplicationUser> userManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _itemRepository = itemRepository;
            _productRepository = productRepository;
            _otherRepository = otherRepository;
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddOrder(OrderEditModel model)
        {
            var random = new Random();
            var order = new Order();
            order.Name = $"#{random.Next(100000, 1000000):D6}";
            order.Address = model.Address;
            order.Phone = model.Phone;
            order.DateOrder = DateTime.Now;
            order.Quantity = model.Quantity;
            order.TotalPrice = model.TotalPrice;
            order.StatusId = model.StatusId;
            var user = await _userManager.FindByIdAsync(model.UserId);
            if(user == null)
            {
                return false;
            }
            order.ApplicationUserId = user.Id;
            order.PaymentMethodId = model.PaymentMethodId;
            order.DiscountId = model.DiscountId;
            var orderCount = await _repository.CountOrders();
            foreach (var orderItem in model.OrderItems)
            {
                var item = new OrderItem()
                {
                    OrderId = orderCount + 1,
                    Color = orderItem.Color,
                    ProductId = orderItem.ProductId,
                    Quantity = orderItem.Quantity,
                    Price = orderItem.Price,
                };
                order.OrderItems.Add(item);
                await _itemRepository.Add(item);
                var product = await _productRepository.GetById(orderItem.ProductId);
                if(product != null && product.Amount > 0)
                {
                    product.Amount -= orderItem.Quantity;
                    product.SoldQuantity += orderItem.Quantity;
                    await _productRepository.Update(product);
                }
            }
            var notification = new Notification()
            {
                Title = "New Order",
                Description = user.Name + " vừa đặt hàng với giá " + order.TotalPrice,
            };
            await _otherRepository.AddNofication(notification);
            await _repository.Add(order);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        public async Task<bool> CancelOrder(int id)
        {
            var order = await _repository.GetByIdWithInclude(id, o => o.Status);
            order.StatusId = 6;
            await _repository.Update(order);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }

        public async Task<IList<OrderDTO>> GetAllOrders()
        {
            var orders = await _repository.GetAllOrders();
            return _mapper.Map<IList<OrderDTO>>(orders);
        }

        public async Task<IList<OrderDTO>> GetAllOrdersByUserId(string userId)
        {
            var orders = await _repository.GetOrdersByUserIdAsync(userId);
            return _mapper.Map<IList<OrderDTO>>(orders);
        }

        public async Task<IList<OrderItemsDTO>> GetOrderItemsByOrderIdAsync(int id)
        {
            var orders = await _itemRepository.GetOrderItemsByOrderIdAsync(id);
            return _mapper.Map<IList<OrderItemsDTO>>(orders);
        }

        public async Task<bool> MoveToNextStep(int id)
        {
            var order = await _repository.GetByIdWithInclude(id, o => o.Status);
            order.StatusId += 1;
            await _repository.Update(order);
            int saved = await _unitOfWork.Commit();
            return saved > 0;
        }
    }
}
