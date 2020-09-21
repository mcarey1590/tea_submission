using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using student_api.Models;
using student_api.ViewModels;

namespace student_api.Repositories
{
    public interface IStudentsRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Transcript> GetTranscript(int id);
        bool Exists(int studentID);
    }
}
