using Autofac;
using Business.ServiceContracts;
using Business.Services;
using Data;
using Data.Repositories;
using Data.RepositoryContracts;
using Data.UnitOfWork;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace EsateApplication
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ContainerBuilder();
            // Registering db context
            builder.RegisterType<PropertyEntities>().As<PropertyEntities>().InstancePerLifetimeScope();
            //builder.RegisterType<PropertyEntities>().AsSelf();   
            // Registering unit of work pattern
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            // Registering repositories
            builder.RegisterType<EstateRepository>().As<IEstateRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PhotoRepository>().As<IPhotoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EstateAgentRepository>().As<IEstateAgentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RoomRepository>().As<IRoomRepository>().InstancePerLifetimeScope();
            // Registering services
            builder.RegisterType<EstateService>().As<IEstateService>().InstancePerLifetimeScope();
            builder.RegisterType<PhotoService>().As<IPhotoService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<EstateAgentService>().As<IEstateAgentService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<RoomService>().As<IRoomService>().InstancePerLifetimeScope();
            // Registering forms
            //builder.RegisterType<Form1>();
            //builder.RegisterType<SignUp>();
            builder.RegisterType<Form1>().AsSelf();
            builder.RegisterType<SignUp>().AsSelf();
            builder.RegisterType<EmlakciMain>().AsSelf();
            builder.RegisterType<EmlakDetail>().AsSelf();
            builder.RegisterType<CreateNewEmlak>().AsSelf();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var form = scope.Resolve<Form1>();
                Application.Run(form);

                //var form = scope.Resolve<EmlakciMain>();
                //Application.Run(form);

                //var form = scope.Resolve<CreateNewEmlak>();
                //Application.Run(form);
            }
        }
    }
}
