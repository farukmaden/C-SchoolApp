using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetExample.Models.BaseModels
{
    public class BaseModel : IBaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
