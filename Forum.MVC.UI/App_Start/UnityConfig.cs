using System;
using Unity.AspNet.Mvc;
using Unity;
using System.Data.Entity;
using Forum.MVC.UI.MvcAdmin;
using Forum.MVC.UI.MvcAdmin.Interface;
using Forum.Admin.Infrastructure;
using Forum.Admin.Service.Interface;
using Forum.Admin.Service;
using System.Web.Mvc;
using Forum.Users.Service.Interface;
using Forum.Data;
using Forum.Data.Interfaces;
using Forum.Entity;
using Forum.Service;
using Forum.Service.Interfaces;

namespace Forum.MVC.UI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IUsersServices, UsarService>();
            container.RegisterType<DbContext, ForumContext>();
            container.RegisterType<IComplainReplayService, ComplainReplaysService>();
            container.RegisterType<Admin.Service.Interface.IRankingService, Admin.Service.RankingService>();
            container.RegisterType<IPostServices, PostServices>();
            container.RegisterType<Admin.Service.Interface.IComplainService, Admin.Service.ComplainServices>();
            container.RegisterType<IChangeInfoRequestService, Change_Info_RequestService>();
            container.RegisterType<IUsersModelServices, UserModelServices>();
            container.RegisterType<IComplainReplaysModelService, ComplainReplaysModelServices>();
            container.RegisterType<IRankingModelService, RankingModelServices>();
            container.RegisterType<IPostModelServices,PostModelServices>();
            container.RegisterType<IComplainModelService, ComplainModelServices>();
            container.RegisterType<IChangeInfoRequestModelService, ChangeInfoRequestModelServices>();
            container.RegisterType<IComplainReplaysModelService, ComplainReplaysModelServices>();
            container.RegisterType<IStarustic, Starustic>();
            container.RegisterType<Users.Service.Interface.IUserServices, Users.Service.UserServices>();
            container.RegisterType<Users.Service.Interface.IChangeInfoRequestServices, Users.Service.ChangeInfoRequestServices >();
            container.RegisterType<IComplainServices, Users.Service.ComplainServices>();
            container.RegisterType<MvcUser.Interface.IUsersModelServices, MvcUser.UserModelServices>();
            container.RegisterType<MvcUser.Interface.IComplainsModelServices, MvcUser.ComplainModelServices>();            container.RegisterType<IRepository<User>, UserRepository>();
            container.RegisterType<IRepository<Post>, PostRepository>();
            container.RegisterType<IRepository<Comment>, CommentRepository>();
            container.RegisterType<IRepository<Reply>, ReplyRepository>();
            container.RegisterType<IRepository<Post_Vote>, PostVoteRepository>();
            container.RegisterType<IRepository<Comment_Vote>, CommentVoteRepository>();
            container.RegisterType<IRepository<Reply_Vote>, ReplyVoteRepository>();
            container.RegisterType<IRepository<Complain>, ComplainRepository>();
            container.RegisterType<IRepository<Complain_Reply>, ComplainReplyRepository>();
            container.RegisterType<IRepository<Change_Info_Request>, ChangeInfoRequestRepository>();
            container.RegisterType<IRepository<Ranking>, RankingRepository>();
            container.RegisterType<IService<User>, UserService>();
            container.RegisterType<IService<Post>, PostService>();
            container.RegisterType<IService<Comment>, CommentService>();
            container.RegisterType<IService<Reply>, ReplyService>();
            container.RegisterType<IService<Post_Vote>, PostVoteService>();
            container.RegisterType<IService<Comment_Vote>, CommentVoteService>();
            container.RegisterType<IService<Reply_Vote>, ReplyVoteService>();
            container.RegisterType<IService<Complain>, ComplainService>();
            container.RegisterType<IService<Complain_Reply>, ComplainReplyService>();
            container.RegisterType<IService<Change_Info_Request>, ChangeInfoRequestService>();
            container.RegisterType<IService<Ranking>,Forum.Service.RankingService>();
            container.RegisterType<MvcUser.Interface.IChangeInfoRequestModelServices, MvcUser.ChangeInfoRequestModelServices>();
            UnityDependencyResolver unityDependencyResolver = new UnityDependencyResolver(container);

            DependencyResolver.SetResolver(unityDependencyResolver);
        }
    }
}