using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Forum.Admin.Service.Interface;
using Forum.Entity;

namespace Forum.Admin.Service
{
    public class UsarService : IUsersServices
    {
        private DbContext _context;
        public UsarService(DbContext context)
        {
            _context = context;
        }
        public bool Delete(User user)
        {
            var userdel = _context.Set<User>().Where(u => u.user_id == user.user_id).SingleOrDefault();
            _context.Set<User>().Remove(userdel);
            var req = _context.Set<Change_Info_Request>().Where(u => u.user_id == user.user_id).ToList();
            if (req != null)
            {
                foreach(var item in req)
                {
                    _context.Set<Change_Info_Request>().Remove(item);
                }
            }
            var rnk = _context.Set<Ranking>().Where(r => r.user_id == user.user_id).SingleOrDefault();
            _context.Set<Ranking>().Remove(rnk);
            _context.SaveChanges();
            return true;
        }

        public bool EditInfo(User user)
        {
        var users = _context.Set<User>().Where(u => u.user_id == user.user_id).SingleOrDefault();
            users.full_name = user.full_name;
            users.user_name = user.user_name;
            users.email = user.email;
            users.phone = user.phone;
            users.dateOfBirth = user.dateOfBirth;
            users.gender = user.gender;
            users.blood_group = user.blood_group;
            users.religion = user.religion;
            users.address = user.address;
            users.cgpa = user.cgpa;
            users.department = user.department;
            if (user.photo==null)
            {
                users.photo = users.photo;
            }
            else
            {
                users.photo = user.photo;
            }
            _context.SaveChanges();
        return true;
        }

        public bool EditStatus(User user)
        {
            try
            {
                var userstutas = _context.Set<User>().Where(u => u.user_id == user.user_id).SingleOrDefault();
                if (userstutas.status == UserStatus.Pending)
                {
                    userstutas.status = user.status;
                    Ranking ranking = new Ranking();
                    ranking.user_id = userstutas.user_id;
                    ranking.points = 0;
                    _context.Set<Ranking>().Add(ranking);
                    _context.SaveChanges();
                }
                else
                {
                    userstutas.status = user.status;
                    _context.SaveChanges();
                }
                return true;
            }
            catch { return false; }

        }

        public IEnumerable<User> GetAll()
        {
            return _context.Set<User>().ToList();
        }

        public IEnumerable<User> GetAllModerator()
        {
            return _context.Set<User>().Where(u=>u.user_type==UserType.Moderator && u.status != UserStatus.Pending && u.status != UserStatus.Blocked).ToList();
        }

        public IEnumerable<User> GetAllStudent()
        {
            return _context.Set<User>().Where(u => u.user_type == UserType.Student && u.status != UserStatus.Pending && u.status != UserStatus.Blocked).ToList();
        }

        public User SelectById(int Id)
        {
            return _context.Set<User>().Find(Id);
        }
    }
}
