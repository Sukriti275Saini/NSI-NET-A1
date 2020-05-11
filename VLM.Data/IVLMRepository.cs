using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLM.Data.Entities;

namespace VLM.Data
{
    public interface IVLMRepository
    {
        //For Movies
        IEnumerable<Movies> GetMovies();
        Movies GetMoviesById(int Id);

        //For User
        IEnumerable<User> GetUsers();
        string UserExist(string Email, string Password);
        User GetUserByUsername(string username);
        User Update(User updatedUser);
        string Add(User newUser);
        string Delete(string username);

        //For Records
        IEnumerable<Records> GetAllRecords();
        IEnumerable<Records> GetRecordsByUsername(string username);
        Records GetRecordsById(int recordId);
        bool DeleteRecord(Records Record);
        bool AddRecord(Records newRecord);

        //General
        int Commit();
    }
}
