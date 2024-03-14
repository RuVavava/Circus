using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus.DB
{
    internal class DBConnection
    {
        public static CircusEntities3 circus = new CircusEntities3(); //Строка подключения БД
        public static Workers loginedWorker; //Строка вошедшего пользователя

        //LAPTOP-NE0LG8CN\SQLEXPRESS

    }
}
