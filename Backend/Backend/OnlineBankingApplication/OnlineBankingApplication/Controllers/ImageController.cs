﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using OnlineBankingApplication.Models;

namespace OnlineBankingApplication.Controllers
{
    [RoutePrefix("api/uploadimage")]
    public class ImageController : ApiController
    {
        [HttpPost]
        [Route("")]
        public HttpResponseMessage UploadImage()
        {
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            //Upload Image
            var postedFile = httpRequest.Files["Image"];
            //Create custom filename
            imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
            postedFile.SaveAs(filePath);

            //Save to DB
            using (ProjectContext db = new ProjectContext())
            {
                Image image = new Image()
                {
                    UserID = Convert.ToInt32(httpRequest["UserID"]),
                    ImageCaption = httpRequest["ImageCaption"],
                    ImageName = imageName,
                    ImageData = File.ReadAllBytes(filePath)
                };
                db.Images.Add(image);
                db.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            ProjectContext db = new ProjectContext();
            var data = from i in db.Images
                       where i.UserID == id
                       select i;
            Image img = (Image)data.SingleOrDefault();
            byte[] imgData = img.ImageData;
            MemoryStream ms = new MemoryStream(imgData);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
            return response;
        }
    }
}