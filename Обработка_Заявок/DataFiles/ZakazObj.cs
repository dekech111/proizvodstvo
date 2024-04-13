using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Обработка_Заявок.DataFiles
{
    internal class ZakazObj
    {
        public static int Код_Заказа { get; set; }
        public static int Код_Услуги { get; set; }
        public static string Краткое_описание { get; set; }
        public static int Код_исполнителя { get; set; }
        public static int Код_заказчика { get; set; }
        public static int Код_оборудования { get; set; }
        public static int КолВо_Оборудования { get; set; }
        public static DateTime Дата { get; set; }
        public static int Сумма { get; set; }
        public static int Код_Статуса { get; set; }
    }
}
