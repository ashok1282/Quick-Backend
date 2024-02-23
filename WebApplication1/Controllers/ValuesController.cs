// <copyright file="RequestController.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace WebApplication1.Controllers
{
    using Devlooped;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;
    using System.Web.UI.WebControls;
    using WebApplication1.Models;
    using WebApplication1.Value;
    //using Microsoft.Azure.Storage;
    //using Microsoft.Azure.Storage.Blob;
    //using Microsoft.WindowsAzure.Storage.Blob;
    using System.Web.Http.Results;
    using OfficeOpenXml;
    // using Microsoft.WindowsAzure.Storage.Blob;
    using Newtonsoft.Json;
    using System.Web.Mvc;
    using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;
    using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
    using RouteAttribute = System.Web.Http.RouteAttribute;
    using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
    using Azure.Storage.Blobs;
    //using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using CloudStorageAccount = Microsoft.Azure.Storage.CloudStorageAccount;
    using Utility.WebApi;



    /// <summary>
    ///   <br />
    /// </summary>
    [RoutePrefix("api/value")]
    public class ValuesController : ApiController
    {
        private readonly IValueProcessor valueProcessorasd;
        /// <summary>Initializes a new instance of the <see cref="RequestController" /> class.</summary>
        /// <param name="graphProcessor">The graph processor.</param>
        /// <param name="requestProcessor">The request processor.</param>
        /// <param name="computeFeedRequestProcessor">The Compute Feed request processor.</param>
        /// <param name="validationProcessor">The validation processor.</param>
        /// <param name="logger">The logger.</param>
        public ValuesController(IValueProcessor ValueProcessor)
        {
            this.valueProcessorasd = ValueProcessor;
        }

        /// <summary>Gets my requests.</summary>
        /// <returns>
        ///   <br />
        /// </returns>      
        [Route("getAdmindetails")]
        [HttpGet]
        public List<AdminModel> GetAdmindetails()
        {
            try
            {
                //var username = HttpContext.Current.Session[Constants.AUTHENTICATED_USER_UPN].ToString();
                return this.valueProcessorasd.GetAdmindetails();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Route("getExamDetails")]
        [HttpGet]
        public List<UserModel> GetExamDetails()
        {
            try
            {
                //var username = HttpContext.Current.Session[Constants.AUTHENTICATED_USER_UPN].ToString();
                return this.valueProcessorasd.GetExamDetails();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>Gets my requests.</summary>
        /// <returns>
        ///   <br />
        /// </returns>      
        [Route("getExamDropdown")]
        [HttpGet]
        public List<AdminexamModel> GetExamDropdown()
        {
            try
            {
                //var username = HttpContext.Current.Session[Constants.AUTHENTICATED_USER_UPN].ToString();
                return this.valueProcessorasd.GetExamDropdown();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// </returns>      
        [Route("getUserbyid")]
        [HttpGet]
        public List<AdminModel> GetUserbyid(int id)
        {
            try
            {
                //var username = HttpContext.Current.Session[Constants.AUTHENTICATED_USER_UPN].ToString();
                return this.valueProcessorasd.GetUserbyid(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [Route("deleteUserbyid")]
        [HttpGet]
        public IHttpActionResult DeleteUserbyid(int id)
        {
            try
            {
                //var username = HttpContext.Current.Session[Constants.AUTHENTICATED_USER_UPN].ToString();
                this.valueProcessorasd.DeleteUserbyid(id);
                return Ok("Admmin deleted successfully.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Route("createorUpdateuser")]
        [HttpPost]
        public IHttpActionResult CreateorUpdateuser(AdminModel model)
        {
            try
            {
                //var username = HttpContext.Current.Session[Constants.AUTHENTICATED_USER_UPN].ToString();
                this.valueProcessorasd.CreateorUpdateuser(model);
                return Ok("Admmin inserted successfully.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Route("CreateorUpdateExamuser")]
        [HttpPost]
        public IHttpActionResult CreateorUpdateExamuser(UserModel model)
        {
            try
            {
                //var username = HttpContext.Current.Session[Constants.AUTHENTICATED_USER_UPN].ToString();
                this.valueProcessorasd.CreateorUpdateExamuser(model);
                return Ok("User inserted successfully.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //[Route("Upload")]
        //[HttpPost]
        //public async Task<IHttpActionResult>  UploadBlob()
        //{
        //    try
        //    {
        //       // var username = HttpContext.Current.Session[Constants.AUTHENTICATED_USER_UPN].ToString();
        //      //  this.valueProcessorasd.UploadBlob();
        //        string connectionString = "DefaultEndpointsProtocol=https;AccountName=abhishekvardhan;AccountKey=6F/uKscWYqDbVbSaB/+mKy78zMUE9h4uaKtq2tJc7o9FbBBe4Q1gWAj6IUPmaFwM4M6PrLiVWA6y+AStlcrAtw==;EndpointSuffix=core.windows.net";
        //        string containerName = "abhishekvardhan";
        //        string blobName = Path.GetFileName(file.FileName);

        //        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
        //        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        //        CloudBlobContainer container = blobClient.GetContainerReference(containerName);

        //        //Create the container if it doesn't exist
        //        await container.CreateIfNotExistsAsync();

        //        CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
        //        await blockBlob.UploadFromStreamAsync(file.InputStream);
        //        return Ok("User inserted successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}


        //[Route("uploadBlob")]
        //[HttpPost]
        //public async Task<IHttpActionResult> UploadFile(HttpPostedFileBase file)
        //{
        //    try
        //    {
        //        if (file != null && file.ContentLength > 0)
        //        {
        //            var storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=abhishekvardhan;AccountKey=6F/uKscWYqDbVbSaB/+mKy78zMUE9h4uaKtq2tJc7o9FbBBe4Q1gWAj6IUPmaFwM4M6PrLiVWA6y+AStlcrAtw==;EndpointSuffix=core.windows.net";
        //            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
        //            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        //            CloudBlobContainer container = blobClient.GetContainerReference("abhishekvardhan");

        //            if (await container.CreateIfNotExistsAsync())
        //            {
        //                await container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
        //            }

        //            CloudBlockBlob blockBlob = container.GetBlockBlobReference(Path.GetFileName(file.FileName));
        //            await blockBlob.UploadFromStreamAsync(file.InputStream);

        //            //ViewBag.Message = "File uploaded successfully!";
        //            // return System.Web.Mvc.ActionResult.("File uploaded successfully.");
        //        }
        //        else
        //        {
        //            //ViewBag.Message = "No file provided.";
        //            //return BadRequest("No file uploaded.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //ViewBag.Message = $"Internal server error: {ex.Message}";
        //        //return InternalServerError(ex);
        //    }
        //    return Ok("success");



        //}

        [Route("uploadBlob")]
        [HttpPost]
        public async Task<IHttpActionResult> UploadFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=abhishekvardhan;AccountKey=6F/uKscWYqDbVbSaB/+mKy78zMUE9h4uaKtq2tJc7o9FbBBe4Q1gWAj6IUPmaFwM4M6PrLiVWA6y+AStlcrAtw==;EndpointSuffix=core.windows.net";

                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobClient.GetContainerReference("abhishekvardhan");

                    if (await container.CreateIfNotExistsAsync())
                    {
                        await container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                    }

                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        CloudBlockBlob blockBlob = container.GetBlockBlobReference(Path.GetFileName(postedFile.FileName));
                        await blockBlob.UploadFromStreamAsync(postedFile.InputStream);
                    }

                    return Ok("Files uploaded successfully!");
                }
                else
                {
                    return BadRequest("No file uploaded.");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[Route("VerifyAdminAccess")]
        //[HttpGet]

        ////public async Task<JsonResult> VerifyAdminAccess(string emailID = "")
        //{
        //    AdminAccess response = new AdminAccess();

        //    try
        //    {
        //        response.HasAdminAccess = false;
        //        string connectionString = "DefaultEndpointsProtocol=https;AccountName=abhishekvardhan;AccountKey=6F/uKscWYqDbVbSaB/+mKy78zMUE9h4uaKtq2tJc7o9FbBBe4Q1gWAj6IUPmaFwM4M6PrLiVWA6y+AStlcrAtw==;EndpointSuffix=core.windows.net";
        //        string containerName = "abhishekvardhan";
        //        string blobName = "adminFile.xlsx";

        //        // Parse the connection string and create a CloudStorageAccount object
        //        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

        //        // Create the blob client
        //        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

        //        // Get a reference to the container
        //        CloudBlobContainer container = blobClient.GetContainerReference(containerName);

        //        // Get a reference to the blob
        //        CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);



        //        // Now you can use EPPlus without encountering the LicenseException
        //        using (ExcelPackage package = new ExcelPackage(memoryStream))
        //        {
        //            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

        //            // Assuming the data starts from the first row (index 1) and the first column (index 1)
        //            int rowCount = worksheet.Dimension.Rows;
        //            int colCount = worksheet.Dimension.Columns;

        //            // Access the data
        //            for (int row = 3; row <= rowCount; row++)
        //            {
        //                string cellValue = worksheet.Cells[row, 2].GetValue<string>();

        //                // Check if the cell value matches the provided emailID
        //                if (cellValue == emailID)
        //                {
        //                    response.HasAdminAccess = true; // ID exists, return true
        //                }
        //            }
        //            Console.WriteLine(worksheet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions
        //        // You might want to log the exception or return a specific error response
        //    }

        //    return Json(response); // Wrap the response in a JsonResult and return
        //}


        //[route("uploadblob")]
        //[httppost]
        //public async task<ihttpactionresult> uploadfile()
        //{
        //    try
        //    {
        //        var httprequest = httpcontext.current.request;
        //        if (httprequest.files.count > 0)
        //        {
        //            string storageconnectionstring = "defaultendpointsprotocol=https;accountname=abhishekvardhan;accountkey=6f/ukscwyqdbvbsab/+mky78zmue9h4uaktq2tjc7o9fbbbe4q1gwaj6iupmafwm4m6prlivwa6y+astlcratw==;endpointsuffix=core.windows.net";

        //            cloudstorageaccount storageaccount = cloudstorageaccount.parse(storageconnectionstring);
        //            cloudblobclient blobclient = storageaccount.createcloudblobclient();
        //            cloudblobcontainer container = blobclient.getcontainerreference("abhishekvardhan");

        //            if (await container.createifnotexistsasync())
        //            {
        //                await container.setpermissionsasync(new blobcontainerpermissions { publicaccess = blobcontainerpublicaccesstype.blob });
        //            }

        //            foreach (string file in httprequest.files)
        //            {
        //                var postedfile = httprequest.files[file];
        //                cloudblockblob blockblob = container.getblockblobreference(path.getfilename(postedfile.filename));
        //                await blockblob.uploadfromstreamasync(postedfile.inputstream);
        //            }

        //            return ok("files uploaded successfully!");
        //        }
        //        else
        //        {
        //            return badrequest("no file uploaded.");
        //        }
        //    }
        //    catch (exception ex)
        //    {
        //        return internalservererror(ex);
        //    }
        //}

        [Route("VerifyAdminAccess")]
        [HttpGet]
        public async Task<ActionResult> VerifyAdminAccess(string emailID = "abhishekvardhan.danagalla@quadranttechnologies.com\r\n")
        {
            AdminAccess response = new AdminAccess
            {
                HasAdminAccess = false,
            };
            try
            {
                string connectionString = "DefaultEndpointsProtocol=https;AccountName=abhishekvardhan;AccountKey=6F/uKscWYqDbVbSaB/+mKy78zMUE9h4uaKtq2tJc7o9FbBBe4Q1gWAj6IUPmaFwM4M6PrLiVWA6y+AStlcrAtw==;EndpointSuffix=core.windows.net";
                string containerName = "abhishekvardhan";
                string blobName = "adminFile.xlsx";

                // Parse the connection string and create a CloudStorageAccount object
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

                // Create the blob client
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // Get a reference to the container
                CloudBlobContainer container = blobClient.GetContainerReference(containerName);

                // Get a reference to the blob
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);

                // Download the blob data to a memory stream
                MemoryStream memoryStream = new MemoryStream();
                await blockBlob.DownloadToStreamAsync(memoryStream);

                // Set the EPPlus license context
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // or LicenseContext.Commercial

                // Now you can use EPPlus without encountering the LicenseException
                using (ExcelPackage package = new ExcelPackage(memoryStream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    // Assuming the data starts from the first row (index 1) and the first column (index 1)
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    // Access the data
                    List<string> matchedEmails = new List<string>();
                    for (int row = 3; row <= rowCount; row++)
                    {
                        string cellValue = worksheet.Cells[row, 2].GetValue<string>();

                        // Check if the cell value matches the provided emailID
                        if (cellValue == emailID)
                        {
                            response.HasAdminAccess = true;
                            break;
                        }
                    }

                    // Determine if there are any matched emails
                    bool hasAccess = matchedEmails.Count > 0;

                    // Create an AdminAccessResponse object


                    // Return the response as JSON

                }
            }
            catch (Exception ex)
            {
                // Return error response if an exception occurs
                //return StatusCode(500, ex.Message);
            }
            return new JsonResult
            {
                Data = response,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        //[Route("upload")]
        //[HttpPost]
        //static async Task Main(string[] args)
        //{
        //    // Set your storage account connection string and blob container name
        //    string connectionString = "DefaultEndpointsProtocol=https;AccountName=abhishekvardhan;AccountKey=6F/uKscWYqDbVbSaB/+mKy78zMUE9h4uaKtq2tJc7o9FbBBe4Q1gWAj6IUPmaFwM4M6PrLiVWA6y+AStlcrAtw==;EndpointSuffix=core.windows.net";
        //    string containerName = "abhishekvardhan";

        //    // Set the path to your local file
        //    string filePath = "C:\\Users\\Quadrant";

        //    // Create a BlobServiceClient object which will be used to create a container client
        //    BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

        //    // Create a BlobContainerClient object which will be used to create a blob client
        //    BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        //    // Create a blob client object
        //    string fileName = Path.GetFileName(filePath);
        //    BlobClient blobClient = containerClient.GetBlobClient(fileName);

        //    // Upload the file
        //    using (FileStream fs = File.OpenRead(filePath))
        //    {
        //        await blobClient.UploadAsync(fs, true);
        //    }

        //    Console.WriteLine("File uploaded successfully.");
        //}
       
    }
}
