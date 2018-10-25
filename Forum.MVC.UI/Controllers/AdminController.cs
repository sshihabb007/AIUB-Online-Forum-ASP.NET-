using System;
using System.Linq;
using Forum.Entity;
using System.Web.Mvc;
using Forum.MVC.UI.Models;
using Forum.MVC.UI.MvcAdmin.Interface;
using Forum.MVC.UI.Filter;
namespace Forum.MVC.UI.Controllers
{
    [LoginValidation]
    public class AdminController : Controller
    {
        private IUsersModelServices _userService;
        private IPostModelServices _postServices;
        private IComplainModelService _comlainService;
        private IChangeInfoRequestModelService _changeInfoRequestService;
        private IRankingModelService _rankingService;
        private IComplainReplaysModelService _replayService;
        private IStarustic _starustic;
        public AdminController(IUsersModelServices usersServices , IPostModelServices postServices, IComplainModelService comlainService , IChangeInfoRequestModelService changeInfoRequestService, IRankingModelService rankingService, IComplainReplaysModelService replayService,IStarustic starustic)
        {
            _userService = usersServices;
            _postServices = postServices;
            _comlainService = comlainService;
            _changeInfoRequestService = changeInfoRequestService;
            _rankingService = rankingService;
            _replayService = replayService;
            _starustic = starustic;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View(_userService.GetAll());
        }
        public ActionResult UserStatusChange()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StudentList()
        {
            return View(_userService.GetAllStudent());
        }
        [HttpGet]
        public ActionResult ModeratorList()
        {
            return View(_userService.GetAllModerator());
        }
        [HttpGet]
        public ActionResult PostList()
        {
            return View(_postServices.GetAll());
        }
        [HttpGet]
        public ActionResult PostListOfUser(String id)
        {
            return View(_postServices.GetListByUser(id));
        }
        [HttpGet]
        public ActionResult ManagePost()
        {
            return View(_userService.GetAll());
        }
        [HttpGet]
        public ActionResult Complain()
        {
            return View(_comlainService.GetAll());
        }
        [HttpGet]
        public ActionResult Statistics()
        {
            return View(_starustic.GetInfo());
        }
        [HttpGet]
        public ActionResult LeaderBoard()
        {

            return View(_rankingService.GetAll());
        }
        [HttpGet]
        public ActionResult InfoChangeList()
        {
            return View(_changeInfoRequestService.GetAllList());
        }
        [HttpGet]
        public ActionResult StudentProfile(String id)
        {
            return View(_userService.SelectById(id));
        }
        [HttpGet]
        public ActionResult StudentEdit(String id)
        {
            return View(_userService.SelectById(id));
        }
        [HttpGet]
        public ActionResult UserPending()
        {
            return View(_userService.GetAllpendinguser());
        }
        [HttpGet]
        public ActionResult UserStatus(String id)
        {
            return View(_userService.SelectById(id));
        }
        [HttpPost]
        public ActionResult UserStatus(Models.Users users)
        {
            _userService.EditStatus(users);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UserBlock()
        {
            return View(_userService.GetAllBlockuser());
        }
        [HttpGet]
        public ActionResult UserOther()
        {
            return View(_userService.GetAllotheruser());
        }

        [HttpPost]
        public ActionResult StudentEdit(Models.Users user)
        {
            _userService.EditInfo(user);
           return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult StudentRemove(String id)
        {
            _userService.Delete(_userService.SelectById(id));
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult ModeratorProfile(String id)
        {
            return View(_userService.SelectById(id));
        }
        [HttpGet]
        public ActionResult ModeratorEdit(String id)
        {
            return View(_userService.SelectById(id));
        }
        [HttpPost]
        public ActionResult ModeratorEdit(Models.Users user)
        {
            _userService.EditInfo(user);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ModeratorRemove(String id)
        {
            _userService.Delete(_userService.SelectById(id)); ;
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult ReviewInfo(int id)
        {
            return View(_changeInfoRequestService.SelectById(id));
        }
        [HttpGet]
        public ActionResult AproveReview(int id)
        {
            _changeInfoRequestService.ApproveById(id);
            return RedirectToAction("InfoChangeList");
        }
        [HttpGet]
        public ActionResult RejectReview(int id)
        {
            _changeInfoRequestService.RejectById(id);
            return RedirectToAction("InfoChangeList");
        }
        [HttpGet]
        public ActionResult PostDetails(int id)
        {
            return View(_postServices.SelectById(id));
        }
        [HttpGet]
        public ActionResult PostDelete(int id)
        {
            _postServices.Delete(id);
            return RedirectToAction("PostList");
        }
        [HttpGet]
        public ActionResult ComplainView(int id)
        {
            return View(_comlainService.SelectById(id));
        }
        [HttpGet]
        public ActionResult ComplainRejected(int id)
        {
            _comlainService.Reject(id);
            return RedirectToAction("Complain");
        }
        [HttpGet]
        public ActionResult Replay(int id)
        {
            return View(_replayService.Preadd(id));
        }
        [HttpPost]
        public ActionResult Replay(ComplainReplays complainReplays)
        {
            _replayService.Add(complainReplays);
            return RedirectToAction("Complain");

        }
    }
}