using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsuManagement.OrdersCrud.Domain.Core.Errors
{
    public static class OrderErrors
    {
        public static string NotFound = "Заказ не найден";
        public static string AlreadyExists = "Заказ с таким номером и поставщиком уже существует";

        public static string ItemNameSameWithOrderName = "Название элемента не может равняться номеру заказа";
        public static string OrderItemNotFound = "Элемент заказа не найден";
    }
}
