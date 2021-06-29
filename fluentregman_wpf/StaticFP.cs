using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fluentregman_wpf
{
    static class StaticFP
    {
        public static DataBase dbase = new DataBase();
        public static MainWindow win_edit = new MainWindow(1);

        public static Red_Client pClientEdit = new Red_Client(0);

        public static Red_Client pClientAdd = new Red_Client(1);



    }
}
