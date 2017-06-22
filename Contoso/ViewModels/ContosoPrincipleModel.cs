using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contoso.ViewModels
{
    public class ContosoPrincipleModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }
        
    }
}