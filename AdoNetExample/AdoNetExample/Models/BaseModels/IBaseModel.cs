using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetExample.Models.BaseModels
{
    public interface IBaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
