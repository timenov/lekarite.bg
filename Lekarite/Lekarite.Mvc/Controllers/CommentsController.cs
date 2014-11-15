namespace Lekarite.Mvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Lekarite.Data.Interfaces;
    using Lekarite.Models;
    using Lekarite.Mvc.Models.Comments;

    public class CommentsController : BaseController
    {
        public CommentsController(ILekariteData data)
            : base(data)
        { }

        public ActionResult GetById(int doctorId)
        {
            if (!this.Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return this.Content("This action can be invoke only by AJAX call");
            }

            var comments = this.Data
                .Doctors
                .Find(doctorId)
                .Comments
                .OrderByDescending(c => c.CreatedOn)
                .AsQueryable()
                .Project().To<CommentViewModel>();

            if (comments == null)
            {
                this.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return this.Content("Comment are not found");
            }

            return this.PartialView("_All", comments);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(int id, CommentViewModel comment)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Content("Content is required");
            }

            var newComment = new Comment
            {
                Content = comment.Content,
                CreatedOn = DateTime.Now,
                User = this.User,
                DoctorId = id
            };

            this.Data.Comments.Add(newComment);
            this.Data.SaveChanges();

            var model = this.Data
                .Comments
                .All()
                .Where(c => c.DoctorId == id)
                .OrderByDescending(c => c.CreatedOn)
                .Project().To<CommentViewModel>()
                .ToList();

            return this.PartialView("_All", model);
        }
    }
}