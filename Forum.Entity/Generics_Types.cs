using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Entity
{
    public enum UserType
    {
        Admin, Moderator, Student
    }
    public enum UserStatus
    {
        Active, Pending, Blocked
    }

    public enum Department
    {
        ARCH, BBA, CSE, EEE, LAW
    }

    public enum Gender
    {
        Male, Female, Other
    }

    public enum BloodGroup
    {
        Apos, Aneg, Bpos, Bneg, ABpos, ABneg, Opos, Oneg
    }

    public enum PostStatus
    {
        Solved, Unsolved
    }

    public enum PostActivity
    {
        Active, Inactive
    }

    public enum CommentStatus
    {
        Correct, Incorrect,None
    }

    public enum VoteStatus
    {
        Like, Dislike, None
    }

    public enum ComplainStatus
    {
        Approved, Pending, Rejected
    }

    public enum NotificationStatus
    {
        Seen, Unseen
    }

    public enum FieldName
    {
        user_name, password, full_name, email, phone, cgpa, department, dateOfBirth, gender, blood_group, religion, address, status
    }

    public enum RequestStatus
    {
        Approved, Pending, Rejected
    }
    public class Generics_Types
    {
    }
}
