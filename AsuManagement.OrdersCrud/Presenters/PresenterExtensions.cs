using AsuManagement.OrdersCrud.Presenters.Orders;
using AsuManagement.OrdersCrud.Services.Commands.Orders.CreateOrder;
using Microsoft.AspNetCore.Mvc;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using AsuManagement.OrdersCrud.Helpers;
using System.Reflection;
using AsuManagement.OrdersCrud.Domain.Interfaces;
using AsuManagement.OrdersCrud.Domain.Services;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using MediatR;
using AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrder;
using AsuManagement.OrdersCrud.Services.Commands.Orders.DeleteOrder;
using AsuManagement.OrdersCrud.Services.Commands.Orders.AddItemToOrder;
using AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrderItem;
using AsuManagement.OrdersCrud.Services.Commands.OrderItems.DeleteOrderItem;
using AsuManagement.OrdersCrud.Services.Commands.Orders;

namespace AsuManagement.OrdersCrud.Presenters
{
    public static class PresentersExtensions
    {
        public static IServiceCollection AddResponsesPresenters(this IServiceCollection services) =>
            services

        #region Providers
            .AddScoped<IRequestHandler<GetProvidersCommand, GetManyQueryResponse<Provider>>, GetProvidersHandler>()
            .AddScoped<IResponsePresenter<GetManyQueryResponse<Provider>>, QueryResponsesPresenter<Provider>>()
        #endregion


        #region Orders
            .AddScoped<IRequestHandler<GetOrdersCommand, GetOrdersOutput>, GetOrdersHandler>()
            .AddScoped<IResponsePresenter<GetOrdersOutput>, GetOrdersPresenter>()

            .AddScoped<IRequestHandler<GetOrderCommand, GetOneQueryResponse<Order>>, GetOrderHandler>()
            .AddScoped<IResponsePresenter<GetOneQueryResponse<Order>>, QueryResponsesPresenter<Order>>()

            .AddScoped<IRequestHandler<CreateOrderCommand, CreateOrderOutput>, CreateOrderHandler>()
            .AddScoped<IResponsePresenter<CreateOrderOutput>, CreateOrderPresenter>()

            .AddScoped<IRequestHandler<EditOrderCommand, EditOrderOutput>, EditOrderHandler>()
            .AddScoped<IResponsePresenter<EditOrderOutput>, EditOrderPresenter>()

            .AddScoped<IRequestHandler<DeleteOrderCommand, SucceededResult>, DeleteOrderHandler>()

        #endregion

        #region OrderItems
            .AddScoped<IRequestHandler<GetOrderItemsCommand, GetManyQueryResponse<OrderItem>>, GetOrderItemsHandler>()
            .AddScoped<IResponsePresenter<GetManyQueryResponse<OrderItem>>, QueryResponsesPresenter<OrderItem>>()

            .AddScoped<IRequestHandler<GetOrderItemCommand, GetOneQueryResponse<OrderItem>>, GetOrderItemHandler>()
            .AddScoped<IResponsePresenter<GetOneQueryResponse<OrderItem>>, QueryResponsesPresenter<OrderItem>>()

            .AddScoped<IRequestHandler<AddItemToOrderCommand, AddItemToOrderOutput>, AddItemToOrderHandler>()
            .AddScoped<IResponsePresenter<AddItemToOrderOutput>, AddItemToOrderPresenter>()

            .AddScoped<IRequestHandler<EditOrderItemCommand, EditOrderItemOutput>, EditOrderItemHandler>()
            .AddScoped<IResponsePresenter<EditOrderItemOutput>, EditOrderItemPresenter>()

            .AddScoped<IRequestHandler<DeleteOrderItemCommand, SucceededResult>, DeleteOrderItemHandler>();
        #endregion
    }
}
