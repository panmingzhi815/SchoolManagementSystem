using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace DataService.service
{
    interface BaseService
    {
        string jsonPage(int page,int row,Object obj);

        string add(Object obj);

        string del(Object obj);

        string updata(Object obj);

    }
}
