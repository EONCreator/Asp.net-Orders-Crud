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
using AsuManagement.OrdersCrud.Presenters.Providers;

namespace AsuManagement.OrdersCrud.Presenters
{
    public static class PresentersExtensions
    {
        public static IServiceCollection AddResponsesPresenters(this IServiceCollection services) =>
            services

        #region Providers
            .AddScoped<IRequestHandler<GetProvidersCommand, GetProvidersOutput>, GetProvidersHandler>()
            .AddScoped<IResponsePresenter<GetProvidersOutput>, GetProvidersPresenter>()
        #endregion


        #region Orders
            .AddScoped<IRequestHandler<GetOrdersCommand, GetOrdersOutput>, GetOrdersHandler>()
            .AddScoped<IResponsePresenter<GetOrdersOutput>, GetOrdersPresenter>()

            .AddScoped<IRequestHandler<GetOrderCommand, GetOrderOutput>, GetOrderHandler>()
            .AddScoped<IResponsePresenter<GetOrderOutput>, GetOrderPresenter>()

            .AddScoped<IRequestHandler<CreateOrderCommand, CreateOrderOutput>, CreateOrderHandler>()
            .AddScoped<IResponsePresenter<CreateOrderOutput>, CreateOrderPresenter>()

            .AddScoped<IRequestHandler<EditOrderCommand, EditOrderOutput>, EditOrderHandler>()
            .AddScoped<IResponsePresenter<EditOrderOutput>, EditOrderPresenter>()

            .AddScoped<IRequestHandler<DeleteOrderCommand, SucceededResult>, DeleteOrderHandler>()

        #endregion

        #region OrderItems
            .AddScoped<IRequestHandler<GetOrderItemsCommand, GetOrderItemsOutput>, GetOrderItemsHandler>()
            .AddScoped<IResponsePresenter<GetOrderItemsOutput>, GetOrderItemsPresenter>()

            .AddScoped<IRequestHandler<GetOrderItemCommand, GetOrderItemOutput>, GetOrderItemHandler>()
            .AddScoped<IResponsePresenter<GetOrderItemOutput>, GetOrderItemPresenter>()

            .AddScoped<IRequestHandler<AddItemToOrderCommand, AddItemToOrderOutput>, AddItemToOrderHandler>()
            .AddScoped<IResponsePresenter<AddItemToOrderOutput>, AddItemToOrderPresenter>()

            .AddScoped<IRequestHandler<EditOrderItemCommand, EditOrderItemOutput>, EditOrderItemHandler>()
            .AddScoped<IResponsePresenter<EditOrderItemOutput>, EditOrderItemPresenter>()

            .AddScoped<IRequestHandler<DeleteOrderItemCommand, SucceededResult>, DeleteOrderItemHandler>();
        #endregion
    }
}
