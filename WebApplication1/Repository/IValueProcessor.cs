// <copyright file="IRequestProcessor.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace WebApplication1.Value
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Newtonsoft.Json.Linq;
    using WebApplication1.Models;

    /// <summary>
    ///   <br />
    /// </summary>
    public interface IValueProcessor
    {
      
        List<AdminModel> GetAdmindetails();
        List<UserModel> GetExamDetails();
        List<AdminexamModel> GetExamDropdown();
        List<AdminModel> GetUserbyid(int id);
        void DeleteUserbyid(int id);
        void CreateorUpdateuser(AdminModel model);
        void CreateorUpdateExamuser(UserModel model);

       
  
    }
}