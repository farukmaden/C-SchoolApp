using AdoNetExample.Enums;
using AdoNetExample.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetExample.Models.UserModels
{
    public class StudentModel : BaseModel
    {
        public StudentModel()
        {

        }
        public UserTypeEnum UserTypeEnum { get; set; }
    }
}
