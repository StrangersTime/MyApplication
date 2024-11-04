using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OlimpiadaForYou
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static database.user91_dbEntities1 Context { get; } = new database.user91_dbEntities1();
        public static database.Olimp_Users _Olimp_Users = new database.Olimp_Users();
    }
}
