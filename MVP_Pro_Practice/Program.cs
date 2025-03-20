using Microsoft.Extensions.DependencyInjection;
using MVP_Pro_Practice.Components;
using MVP_Pro_Practice.Contracts;
using MVP_Pro_Practice.Models.Repository;
using MVP_Pro_Practice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_Pro_Practice
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        /// 
        public static IOCServiceCollection.ServiceProvider provider = null;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Assembly assembly = Assembly.GetExecutingAssembly();
            IOCServiceCollection.ServiceCollection collection = new IOCServiceCollection.ServiceCollection();
            collection.AutoRegister(assembly);

            //collection.AddSingleton<Form, Form1>();
            collection.AddSingleton<Form, Form2>();

            provider = collection.BuildServiceProvider();
            Form form = provider.GetService<Form>();

            Application.Run(form);
        }
    }
}
