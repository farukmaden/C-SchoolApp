using AdoNetExample.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetExample
{
    public interface IDataAccess
    {
        void add(StudentModel studentModel);
        void delete(int selectedId);
        void update(int selectedId, StudentModel studentModel);
        void getAll();
        void getById(int selectedId);
        void addColumn();
        void getByUserType(int selectedType);
    }
}
