using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.service.basic
{
    class ServiceException : Exception
    {
        public ServiceException(string message) {
            throw new Exception(message);
        }
    }
}
