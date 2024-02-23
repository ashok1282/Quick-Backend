using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserAuth
    {
     
            public string Id { get; set; }

            /// <summary>Gets or sets the name of the DWN STRM org.</summary>
            /// <value>The name of the DWN STRM org.</value>
            public string Email { get; set; }
            public string Password {  get; set; }
           
        
    }

}