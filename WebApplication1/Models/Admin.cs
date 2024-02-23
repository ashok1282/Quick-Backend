// <copyright file="RequesterModel.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

using System;

namespace WebApplication1.Models
{
    public class AdminModel
    {
        public string Id { get; set; }

        /// <summary>Gets or sets the name of the DWN STRM org.</summary>
        /// <value>The name of the DWN STRM org.</value>
        public string Name { get; set; }
        public string Technologies { get; set; }
        public string TechnologiesPercentage { get; set; }
        public string Complexity { get; set; }
        public string NoOfQuestions { get; set; }
        public string TimeDuration { get; set; }
        public Boolean Internetreqirement { get; set; }
        public string UploadDocument { get; set; }
        public string PassPercentage { get; set; }
        public string CreatedBy { get; set; }
    }

    public class UserModel
    {
        public string Id { get; set; }

        /// <summary>Gets or sets the name of the DWN STRM org.</summary>
        /// <value>The name of the DWN STRM org.</value>
        public string ExamId { get; set; }
        public string ExamName { get; set; }
        public DateTime Exambookeddate { get; set; }
        public string Result { get; set; } 

        public string ExamResonse { get; set; }

        public string UserAnswers { get; set; }

        public DateTime ExamEndTime { get; set; }

        public string CreatedBy { get; set; }

    }
    public class AdminexamModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
     
    }
}
