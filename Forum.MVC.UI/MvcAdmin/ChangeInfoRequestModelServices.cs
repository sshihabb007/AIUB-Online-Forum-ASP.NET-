using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.MVC.UI.Models;
using Forum.MVC.UI.MvcAdmin.Interface;
using Forum.Admin.Service.Interface;
using Forum.Entity;

namespace Forum.MVC.UI.MvcAdmin
{
    public class ChangeInfoRequestModelServices: IChangeInfoRequestModelService
    {
        private IChangeInfoRequestService _ChangeInfo;
        private IUsersServices _usersServices;
        public ChangeInfoRequestModelServices(IChangeInfoRequestService changeInfo,IUsersServices usersServices)
        {
            _ChangeInfo = changeInfo;
            _usersServices = usersServices;
        }
        public bool ApproveById(int Id)
        {
                _ChangeInfo.ApproveById(Id);
                User userlst = new User();
                    var cirlst = _ChangeInfo.SelectById(Id);
                    var usr = _usersServices.SelectById(cirlst.user_id);
                userlst.user_id = usr.user_id;
                userlst.full_name = usr.full_name;
                userlst.address = usr.address;
                userlst.blood_group = usr.blood_group;
                userlst.cgpa = usr.cgpa;
                userlst.dateOfBirth = usr.dateOfBirth;
                userlst.department = usr.department;
                userlst.email = usr.email;
                userlst.gender = usr.gender;
                userlst.phone = usr.phone;
                userlst.photo = usr.photo;
                userlst.religion = usr.religion;
                userlst.user_type = usr.user_type;
                    switch (cirlst.field_name)
                    {
                        case FieldName.address:
                            userlst.address = cirlst.field_value;
                            break;
                        case FieldName.blood_group:
                            switch (cirlst.field_value)
                            {
                                case "ABneg":
                                    userlst.blood_group = BloodGroup.ABneg;
                                    break;
                                case "ABpos":
                                    userlst.blood_group = BloodGroup.ABpos;
                                    break;
                                case "Aneg":
                                    userlst.blood_group = BloodGroup.Aneg;
                                    break;
                                case "Apos":
                                    userlst.blood_group = BloodGroup.Apos;
                                    break;
                                case "Bneg":
                                    userlst.blood_group = BloodGroup.Bneg;
                                    break;
                                case "Bpos":
                                    userlst.blood_group = BloodGroup.Bpos;
                                    break;
                                case "Oneg":
                                    userlst.blood_group = BloodGroup.Oneg;
                                    break;
                                case "Opos":
                                    userlst.blood_group = BloodGroup.Opos;
                                    break;
                            }
                            break;
                        case FieldName.dateOfBirth:
                            userlst.dateOfBirth = Convert.ToDateTime(cirlst.field_value);
                            break;
                        case FieldName.department:
                            switch (cirlst.field_value)
                            {
                                case "CS":
                                    userlst.department = Department.CSE;
                                    break;
                                case "EEE":
                                    userlst.department = Department.EEE;
                                    break;
                                case "BBA":
                                    userlst.department = Department.BBA;
                                    break;
                                case "ARCI":
                                    userlst.department = Department.ARCH;
                                    break;
                            }
                            break;
                        case FieldName.email:
                            userlst.email = cirlst.field_value;
                            break;
                        case FieldName.gender:
                            switch (cirlst.field_value)
                            {
                                case "Male":
                                    userlst.gender = Gender.Male;
                                    break;
                                case "Female":
                                    userlst.gender = Gender.Female;
                                    break;
                                case "Other":
                                    userlst.gender = Gender.Other;
                                    break;
                            }
                            break;
                        case FieldName.full_name:
                            userlst.full_name = cirlst.field_value;
                            break;
                        case FieldName.phone:
                            userlst.phone = cirlst.field_value;
                            break;
                        case FieldName.religion:
                            userlst.religion = cirlst.field_value;
                            break;
                    }
                _usersServices.EditInfo(userlst);
            return true;
        }

        public IEnumerable<ChangeInfoRequests> GetAllList()
        {
            var model = _ChangeInfo.GetAllList();
            var usr = _usersServices.GetAll();
            List<ChangeInfoRequests> lst = new List<ChangeInfoRequests>();
            foreach(var item in model)
            {
                using (ChangeInfoRequests changeInfoRequests = new ChangeInfoRequests())
                {
                    changeInfoRequests.FieldName = item.field_name;
                    changeInfoRequests.FieldValue = item.field_value;
                    changeInfoRequests.Id = item.request_id;
                    changeInfoRequests.Status = item.status;
                    changeInfoRequests.UserId = item.user_id;
                    changeInfoRequests.NameOfUser = usr.Where(u => u.user_id == item.user_id).Select(u=>u.full_name).SingleOrDefault();
                    lst.Add(changeInfoRequests);
                }
            }
            return lst;
        }

        public bool RejectById(int Id)
        {
            _ChangeInfo.RejectById(Id);
            return true;
        }

        public ChangeInfoRequests SelectById(int id)
        {
            var model = _ChangeInfo.SelectById(id);
            var usr = _usersServices.SelectById(model.user_id);
            var info = new ChangeInfoRequests();
            info.Id=model.request_id;
            info.FieldName = model.field_name;
            info.FieldValue = model.field_value;
            switch (info.FieldName)
            {
                case FieldName.address:
                    info.NameOfUser = usr.address;
                    break;
                case FieldName.blood_group:
                    info.NameOfUser = usr.blood_group.ToString();
                    break;
                case FieldName.dateOfBirth:
                    info.NameOfUser = usr.dateOfBirth.ToString();
                    break;
                case FieldName.department:
                    info.NameOfUser = usr.department.ToString();
                    break;
                case FieldName.email:
                    info.NameOfUser = usr.email; 
                    break;
                case FieldName.gender:
                    info.NameOfUser = usr.gender.ToString();
                    break;
                case FieldName.full_name:
                    info.NameOfUser = usr.full_name;
                    break;
                case FieldName.phone:
                    info.NameOfUser = usr.phone;
                    break;
                case FieldName.religion:
                    info.NameOfUser = usr.religion;
                    break;
            }
            return info;
        }
        public Object Search(String search)
        {
            var completelst = this.GetAllList();
            var stdlist = (_usersServices.GetAll());
            var compositelist = (from complite in completelst
            join usr in stdlist on complite.UserId equals usr.user_id
            where usr.user_id.ToString() == search && complite.Status != RequestStatus.Pending
            select new
            {
                complite.UserId,
                complite.NameOfUser,
                Status = Enum.GetName(typeof(RequestStatus), complite.Status),
                UserType = Enum.GetName(typeof(UserType), usr.user_type)
            }).AsEnumerable();
            return compositelist;
}
    }
}