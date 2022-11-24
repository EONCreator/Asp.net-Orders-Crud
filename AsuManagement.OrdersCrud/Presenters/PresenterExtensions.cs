using MediatR;
using AsuManagement.OrdersCrud.Presenters.Orders;
using AsuManagement.OrdersCrud.Services.Commands.Orders.CreateOrder;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrder;
using AsuManagement.OrdersCrud.Services.Commands.Orders.DeleteOrder;
using AsuManagement.OrdersCrud.Services.Commands.Orders.AddItemToOrder;
using AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrderItem;
using AsuManagement.OrdersCrud.Services.Commands.OrderItems.DeleteOrderItem;
using AsuManagement.OrdersCrud.Services.Commands.Providers;
using AsuManagement.OrdersCrud.Services.Commands.GetMany.Orders;
using AsuManagement.OrdersCrud.Services.Commands.GetOne.Orders;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AsuManagement.OrdersCrud.Presenters.Common;

namespace AsuManagement.OrdersCrud.Presenters
{
    public static class PresentersExtensions
    {
        public static IServiceCollection AddResponsesPresenters(this IServiceCollection services) =>
            services

            .AddScoped<IResponsePresenter<EntityIdOutput>, EntityIdPresenter>()

        #region Providers
            .AddScoped<IRequestHandler<GetProvidersCommand, List<Provider>>, GetProvidersHandler>()
            .AddScoped<IResponsePresenter<List<Provider>>, EntitiesPresenter<Provider>>()
        #endregion


        #region Orders
            .AddScoped<IRequestHandler<GetOrdersCommand, GetOrdersOutput>, GetOrdersHandler>()
            .AddScoped<IResponsePresenter<GetOrdersOutput>, GetOrdersPresenter>()

            .AddScoped<IRequestHandler<GetOrderCommand, Order>, GetOrderHandler>()
            .AddScoped<IResponsePresenter<List<Order>>, EntitiesPresenter<Order>>()

            .AddScoped<IRequestHandler<CreateOrderCommand, EntityIdOutput>, CreateOrderHandler>()
            .AddScoped<IRequestHandler<EditOrderCommand, EntityIdOutput>, EditOrderHandler>()
            .AddScoped<IRequestHandler<DeleteOrderCommand, SucceededResult>, DeleteOrderHandler>()

        #endregion

        #region OrderItems
            .AddScoped<IRequestHandler<GetOrderItemsCommand, List<OrderItem>>, GetOrderItemsHandler>()
            .AddScoped<IResponsePresenter<List<OrderItem>>, EntitiesPresenter<OrderItem>>()

            .AddScoped<IRequestHandler<GetOrderItemCommand, OrderItem>, GetOrderItemHandler>()
            .AddScoped<IResponsePresenter<OrderItem>, EntityPresenter<OrderItem>>()

            .AddScoped<IRequestHandler<AddItemToOrderCommand, EntityIdOutput>, AddItemToOrderHandler>()
            .AddScoped<IRequestHandler<EditOrderItemCommand, EntityIdOutput>, EditOrderItemHandler>()
            .AddScoped<IRequestHandler<DeleteOrderItemCommand, SucceededResult>, DeleteOrderItemHandler>();
        #endregion
    }
}
