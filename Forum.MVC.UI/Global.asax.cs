using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Forum.Admin.Service;
using Forum.Admin.Service.Interface;
using Forum.MVC.UI.Models;
using Forum.Entity;
using Unity;

namespace Forum.MVC.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);           
        }
        //protected void Session_Start()
        //{
        //    Session["Users"] = new List<Users>()
        //   {
        //       new Users()
        //       {
        //           Id = "1",
        //           Name ="Bob Marsh",
        //           Email = "bob@aiub.edu",
        //           CGPA = 3.41f,
        //           Department = Department.ARCH,
        //           Status = Status.Alumni,
        //           UserType=Types.Student,
        //           Address="kkkfjjjfjj",
        //           BloodGroup=BloodGroup.APositive,
        //           DateOfBirth=Convert.ToDateTime("9/11/2001"),
        //           LastLogin=DateTime.Now,
        //           LastPost=DateTime.Now,
        //           Gender=Gender.Male,
        //           LastLogout=DateTime.Now,
        //           Password="bobaiub@",
        //           Phone="23748596872",
        //           Religion="Muslim",
        //           PhotoUrl="dffdf"

        //       },
        //       new Users()
        //       {
        //           Id = "2",
        //           Name ="Anne Zane",
        //           Email = "anne@aiub.edu",
        //           CGPA = 3.86f,
        //           Department = Department.BBA,
        //           Status = Status.Inactive,
        //           UserType=Types.Student,
        //            Address="lkjlglkg",
        //           BloodGroup=BloodGroup.APositive,
        //           DateOfBirth=Convert.ToDateTime("9/11/1998"),
        //           LastLogin=DateTime.Now,
        //           LastPost=DateTime.Now,
        //           Gender=Gender.Female,
        //           LastLogout=DateTime.Now,
        //           Password="anneaiub@",
        //           Phone="45456456465",
        //           Religion="Muslim",
        //           PhotoUrl="dffdf"
        //       },
        //       new Users()
        //       {
        //           Id = "3",
        //           Name ="John Doe",
        //           Email = "john@aiub.edu",
        //           Department = Department.CSE,
        //           Status = Status.Active,
        //           UserType=Types.Moderator,
        //           Address="kkfjjsjsjj",
        //           BloodGroup=BloodGroup.APositive,
        //           DateOfBirth=Convert.ToDateTime("9/11/1994"),
        //           LastLogin=DateTime.Now,
        //           LastPost=DateTime.Now,
        //           Gender=Gender.Male,
        //           LastLogout=DateTime.Now,
        //           Password="johnaiub@",
        //           Phone="4546545688",
        //           Religion="Muslim",
        //           PhotoUrl="dffdf"
        //       },
        //       new Users()
        //       {
        //           Id = "4",
        //           Name ="Scott Tiger",
        //           Email = "scott@aiub.edu",
        //           Department = Department.CSE,
        //           Status = Status.Active,
        //           UserType=Types.Moderator,
        //            Address="kkkfjjjfsdasasajj",
        //           BloodGroup=BloodGroup.APositive,
        //           DateOfBirth=Convert.ToDateTime("9/11/1990"),
        //           LastLogin=DateTime.Now,
        //           LastPost=DateTime.Now,
        //           Gender=Gender.Male,
        //           LastLogout=DateTime.Now,
        //           Password="scottaiub@",
        //           Phone="58413658526",
        //           Religion="Muslim",
        //           PhotoUrl="dffdf"
        //       },
        //       new Users()
        //       {
        //           Id = "5",
        //           Name ="Jems",
        //           Email = "jems@aiub.edu",
        //           CGPA = 3.41f,
        //           Department = Department.ARCH,
        //           Status = Status.Pending,
        //           UserType=Types.Student,
        //           Address="kkkfjjjfjj",
        //           BloodGroup=BloodGroup.APositive,
        //           DateOfBirth=Convert.ToDateTime("9/11/2001"),
        //           LastLogin=DateTime.Now,
        //           LastPost=DateTime.Now,
        //           Gender=Gender.Male,
        //           LastLogout=DateTime.Now,
        //           Password="jemsaiub@",
        //           Phone="23748596872",
        //           Religion="Muslim",
        //           PhotoUrl="dffdf"

        //       },
        //       new Users()
        //       {
        //           Id = "6",
        //           Name ="Michel",
        //           Email = "michel@aiub.edu",
        //           CGPA = 3.41f,
        //           Department = Department.ARCH,
        //           Status = Status.Blocked,
        //           UserType=Types.Student,
        //           Address="kkkfjjjfjj",
        //           BloodGroup=BloodGroup.APositive,
        //           DateOfBirth=Convert.ToDateTime("9/11/2001"),
        //           LastLogin=DateTime.Now,
        //           LastPost=DateTime.Now,
        //           Gender=Gender.Male,
        //           LastLogout=DateTime.Now,
        //           Password="micheliub@",
        //           Phone="23748596872",
        //           Religion="Muslim",
        //           PhotoUrl="dffdf"

        //       }
        //   };
        //    Session["ChangeInfoRequests"] = new List<ChangeInfoRequests>()
        //    {
        //        new ChangeInfoRequests()
        //        {
        //            Id=1,
        //            UserId="1",
        //            FieldName=FieldName.Email,
        //            FieldValue="assw",
        //            Status=InfoStatus.Approved

        //        },
        //        new ChangeInfoRequests()
        //        {
        //            Id=2,
        //            UserId="2",
        //            FieldName=FieldName.Email,
        //            FieldValue="assw",
        //            Status=InfoStatus.Pending

        //        },
        //        new ChangeInfoRequests()
        //        {
        //            Id=3,
        //            UserId="1",
        //            FieldName=FieldName.Email,
        //            FieldValue="assw",
        //            Status=InfoStatus.Rejected
        //        },
        //        new ChangeInfoRequests()
        //        {
        //            Id=4,
        //            UserId="3",
        //            FieldName=FieldName.Email,
        //            FieldValue="asswddddd",
        //            Status=InfoStatus.Pending
        //        }
        //    };
        //    Session["Posts"] = new List<Posts>()
        //    {
        //        new Posts()
        //        {
        //            Id=1,
        //            Title="hhhdjjjdjjj",
        //            Body=new HtmlString("jjhkhkhkjh hjkhjhkh hjhkjhkhh hkhhkjhh\njhjhjgjhghjghgjhgjggjhg"),
        //            Like=20,
        //            Dislike=15,
        //            Activity=PostActivity.Active,
        //            Status=PostStatus.Unsolved,
        //            UserId="3"
        //        },new Posts()
        //        {
        //            Id=2,
        //            Title="kkkkkkkkk",
        //            Body= new HtmlString("lklklkklklk hjkhjhkh hjhkjhkhh hkhhkjhh\njhjh jgjhg hjghgjh gjggjhg"),
        //            Like=10,
        //            Dislike=25,
        //            Activity=PostActivity.Active,
        //            Status=PostStatus.Unsolved,
        //            UserId="2"
        //        },
        //        new Posts()
        //        {
        //            Id=3,
        //            Title="lkjkjsa aslkjkljlksa",
        //            Body= new HtmlString("jjhkhkhkjh kdkkkdkkkh hjhkjhkhh hkhhkjhh\njhjhjgjhghjghgjhgjggjhg"),
        //            Like=27,
        //            Dislike=25,
        //            Activity=PostActivity.Active,
        //            Status=PostStatus.Solved,
        //            UserId="4"
        //        },
        //        new Posts()
        //        {
        //            Id=4,
        //            Title="zzzzzzzzzz",
        //            Body=new HtmlString("jjhkhkhkjh kdkkkdkkkh hjhkjhkhh hkhhkjhh\njhjhjgjhghjghgjhgjggjhg"),
        //            Like=27,
        //            Dislike=25,
        //            Activity=PostActivity.Hidden,
        //            Status=PostStatus.Unsolved,
        //            UserId="1"
        //        }
        //    };
        //    Session["Complains"] = new List<Complains>()
        //    {
        //        new Complains()
        //        {
        //            Id=1,
        //            FromUser="1",
        //            ToUser="2",
        //            Subject="jkhjkhjkhaskj",
        //            Description="haslkjh kjhjhsad hjhdfajs ashkjhfdas ajkhdsafkjh dhjkhfsd",
        //            Date=System.DateTime.Now.Date,
        //            NotificationSeen=NotificationSeen.Unseen,
        //            Status=ComplainStatus.Rejected
        //        },
        //        new Complains()
        //        {
        //            Id=2,
        //            FromUser="2",
        //            ToUser="1",
        //            Subject="sakjshsajh haskj",
        //            Description="hsaljksjalkj hahjsakshkd hjhdfajs ashkjhfdas ajkhdsafkjh dhjkhfsd",
        //            Date=System.DateTime.Now.Date,
        //            NotificationSeen=NotificationSeen.Unseen,
        //            Status=ComplainStatus.Pending
        //        },
        //        new Complains()
        //        {
        //            Id=3,
        //            FromUser="3",
        //            ToUser="4",
        //            Subject="ajkjlsakdjl jkhaskj",
        //            Description="haslkjh saDDDD dddkjhjhsad hjhdfajs ashkjhfdas ajkhdsafkjh dhjkhfsd",
        //            Date=System.DateTime.Now.Date,
        //            NotificationSeen=NotificationSeen.Seen,
        //            Status=ComplainStatus.Aproved
        //        },
        //        new Complains()
        //        {
        //            Id=4,
        //            FromUser="4",
        //            ToUser="3",
        //            Subject="j al;skdj  dddd hjkhaskj",
        //            Description="haslkjh k alk;sj saljl; hsad hjhdfajs ashkjhfdas ajkhdsafkjh dhjkhfsd",
        //            Date=System.DateTime.Now.Date,
        //            NotificationSeen=NotificationSeen.Unseen,
        //            Status=ComplainStatus.Pending
        //        }
        //    };
        //    Session["ComplainReplays"] = new List<ComplainReplays>();
        //}
    }
}
