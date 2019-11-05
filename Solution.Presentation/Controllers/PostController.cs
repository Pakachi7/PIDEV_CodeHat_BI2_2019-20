using Solution.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Solution.Service;
using Solution.Domain.Entities;
using System.IO;
namespace Solution.Presentation.Controllers
{
    public class PostController : Controller
    {
        IPostService Service = null;
        public PostController()
        {
            Service = new PostService();
        }
        // GET: Post
        public ActionResult Index()
        {
            return View(Service.GetMany());
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            Post post = Service.GetById(id);
            

            return View(post);
        }
        // POST: Post/Details/5/like
        public ActionResult Like(int id)
        {
            Post p = Service.GetById(id);
            Service.LikePost(id);
            Service.Update(p);
            Service.Commit();
            return RedirectToAction("index");
        }
        // POST: Post/Details/5/dislike
        public ActionResult DisLike(int id)
        {
            Post p = Service.GetById(id);
            Service.DisLikePost(id);
            Service.Update(p);
            Service.Commit();
            return RedirectToAction("index");
        }
        // GET: Post/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(PostVM fvm, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid ||
                file == null ||
                file.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            
            Post p = new Post()
            {
                PostId = fvm.PostId,
                UserId = fvm.UserId,
                Content = fvm.Content,
                UrlImage = file.FileName,
                UrlVideo = fvm.UrlVideo,
                PostDate = fvm.PostDate,
                NbrLikes = fvm.NbrLikes
            };
            Service.Add(p);
            Service.Commit();
            //Service.Dispose();
            //ajout d'image sous dossier
            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.
                    Combine(Server.MapPath("~/Content/Uploads/"),
                    fileName);
                file.SaveAs(path);
            }


            return RedirectToAction("Index");
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {

            Post post = Service.GetById(id);
            PostVM p = new PostVM();
            p.PostId = post.PostId;
            p.UserId = post.UserId;
            p.Content = post.Content;
            p.UrlImage = post.UrlImage;
            p.UrlVideo = post.UrlVideo;
            p.PostDate = post.PostDate;
            p.NbrLikes = post.NbrLikes;

            return View(p);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PostVM fvm)
        {
            Post p = Service.GetById(id);
            p.Content = fvm.Content;
            p.UrlImage = fvm.UrlImage;
            p.UrlVideo = fvm.UrlVideo;
            p.PostDate = fvm.PostDate;
            p.NbrLikes = fvm.NbrLikes;

            Service.Update(p);
            Service.Commit();
            //Service.Dispose();


            return RedirectToAction("Index");
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
