using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using VLM.Data.Entities;

namespace VLM.Data
{
    public class VLMRepository : IVLMRepository
    {
        private readonly VLMDbContext db;

        public VLMRepository(VLMDbContext db)
        {
            this.db = db;
        }

        /// For Movies
        public IEnumerable<Movies> GetMovies()
        {
            var query = from m in db.Movies
                        orderby m.MoviesId
                        select m;
            if (query.Count() > 0)
                return query;
            return null;
        }

        public Movies GetMoviesById(int Id)
        {
            return db.Movies.Find(Id);
        }


        /// For User
        public IEnumerable<User> GetUsers()
        {
            var query = from u in db.Users
                        select u;
            return query;
        }

        public User GetUserByUsername(string username)
        {
            return db.Users.Find(username);
        }

        public string Add(User newUser)
        {
            var checkUser = GetUserByUsername(newUser.UserName);
            if (checkUser != null)
            {
                return "Username already exist";
            }
            db.Users.Add(newUser);
            return "Successfull";
        }

        public string Delete(string username)
        {
            var checkRecords = GetRecordsByUsername(username);
            if (checkRecords == null)
            {
                var user = GetUserByUsername(username);
                db.Users.Remove(user);
                return "Successfull";
            }
            return $"Not be able to delete your account, you have to return {checkRecords.Count()} movies first";
        }

        public User Update(User updatedUser)
        {
            var entity = db.Users.Attach(updatedUser);
            entity.State = EntityState.Modified;
            return updatedUser;
        }

        public string UserExist(string Username, string Password)
        {
            var User = GetUserByUsername(Username);
            if (User != null)
            {
                var result = User.Password.Equals(Password);
                if (!result)
                {
                    return "Incorrect Password";
                }
                return "Successfull";
            }
            return "Username not found";
        }


        //For Records
        public IEnumerable<Records> GetRecordsByUsername(string username)
        {
            var query = from r in db.Records.Include("Movies")
                        where r.User.UserName.Equals(username)
                        orderby r.TakenDate
                        select r;
            if (query.Count() > 0)
            {
                return query;
            }
            return null;
        }

        public Records GetRecordsById(int recordId)
        {
            var query = from r in db.Records.Include("Movies")
                        where r.RecordsId.Equals(recordId)
                        select r;
            if (query.Count() > 0)
            {
                return query.SingleOrDefault();
            }
            return null;
        }

        public bool DeleteRecord(Records Record)
        {
            if (Record != null)
            {
                db.Records.Remove(Record);
                return true;
            }
            return false;
        }

        public bool AddRecord(Records newRecord)
        {
            db.Records.Add(newRecord);
            return true;
        }


        //General
        public int Commit()
        {
            return db.SaveChanges();
        }

    }
}
