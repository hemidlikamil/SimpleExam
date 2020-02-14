[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SimpleExam.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SimpleExam.NinjectWebCommon), "Stop")]

namespace SimpleExam
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Web;
    using UOW;
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);

            //kernel.Bind(x => x.FromThisAssembly().SelectAllClasses().BindDefaultInterface());
            //kernel.Bind<AppDbContext>().To<AppDbContext>();
            //kernel.Bind<IExamRepository>().To<ExamRepository>();
            //kernel.Bind<IStudentRepository>().To<StudentRepository>();
            //kernel.Bind<ILessonRepository>().To<LessonRepository>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
        }
    }
}