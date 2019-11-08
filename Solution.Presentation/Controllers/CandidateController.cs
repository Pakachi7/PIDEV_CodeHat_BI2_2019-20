using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class CandidateController : Controller
    {
        ICandidatService candidateService = null;

        IExperienceService experienceService = null;
        public CandidateController()
        {
            candidateService = new CandidateService();
            experienceService = new ExperienceService();
        }
        // GET: Candidate
        public ActionResult Index()
        {

            var clients = new List<CandidateVM>();

            foreach (Candidate cdomain in candidateService.GetMany())
            {
                clients.Add(new CandidateVM()
                {
                    CandidateId = cdomain.CandidateId,
                    FirstName = cdomain.FirstName,
                    LastName = cdomain.LastName,
                    Gender = (GenderVM)cdomain.Gender,
                    DateOfBirthday = cdomain.DateOfBirthday,
                    PhoneNumber = cdomain.PhoneNumber,
                    Email = cdomain.Email,
                    Address = cdomain.Address,
                    ImageUrl = cdomain.ImageUrl,
                    bio = cdomain.bio,




                });
            }

            return View(clients);
            //return View();
        }

        // GET: Candidate/Details/5
        public ActionResult Details(int id)
        {
            Candidate cl = candidateService.GetById(id);
            if (cl == null)
            {

                return HttpNotFound();

            }

            return View(cl);
        }

        // GET: Candidate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidate/Create
        [HttpPost]
        public ActionResult Create(CandidateVM CVM, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid ||
            file == null ||
            file.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            Candidate CandidateDomain = new Candidate()
            {
                CandidateId = CVM.CandidateId,
                FirstName = CVM.FirstName,
                LastName = CVM.LastName,
                Gender = (Gender)CVM.Gender,
                DateOfBirthday = CVM.DateOfBirthday,
                Email = CVM.Email,
                Address = CVM.Address,
                PhoneNumber = CVM.PhoneNumber,

                ImageUrl = file.FileName,

                bio = CVM.bio
            };
            candidateService.Add(CandidateDomain);
            candidateService.Commit();
            //  candidateService.Dispose();
            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Uploads/"),
                    fileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Index");

        }


        // GET: Candidate/Edit/5
        public ActionResult Edit(int id)
        {
            Candidate cl = candidateService.GetById(id);
            if (cl == null)
            {

                return HttpNotFound();

            }

            return View(cl);


        }

        // POST: Candidate/Edit/5
        [HttpPost]
        public ActionResult Edit(Candidate cl)
        {
            Candidate c1 = candidateService.GetById(cl.CandidateId);

            c1.FirstName = cl.FirstName;
            c1.LastName = cl.LastName;
            c1.Gender = cl.Gender;
            c1.DateOfBirthday = cl.DateOfBirthday;
            c1.Email = cl.Email;
            c1.Address = cl.Address;
            c1.PhoneNumber = cl.PhoneNumber;
            c1.ImageUrl = cl.ImageUrl;
            c1.bio = cl.bio;

            if (ModelState.IsValid)
            {
                candidateService.Update(c1);
                candidateService.Commit();
                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Candidate/Delete/5
        public ActionResult Delete(int id)
        {
            Candidate cl = candidateService.GetById(id);



            if (candidateService.GetById(id) == null)

            {

                return HttpNotFound();

            }

            //   return View(ServiceC);
            return View(cl);
            //return View();
        }

        // POST: Candidate/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmedDelete(int id)
        {

            Candidate cl = candidateService.GetById(id);
            candidateService.Delete(cl);
            candidateService.Commit();

            return RedirectToAction("Index");
        }
        public ActionResult AddExperience(int id)
        {
            return View();
        }

        [HttpPost]
           public ActionResult AddExperience(ExperienceVM e,int id)
        {
            Candidate c = candidateService.GetById(id);
            Experience e1 = new Experience();
            e1.Designation = e.Designation;
            e1.Description = e.Description;
            e1.StartDate = e.StartDate;
            e1.EndDate = e.EndDate;
            e1.CandidateId = c.CandidateId;
            c.Experiences.Add(e1);
            candidateService.Update(c);
            candidateService.Commit();
            return RedirectToAction("Details",new { id });
        }


        
        public ActionResult DeleteExperience(int id, int ExperienceId)
        {
            Candidate c = candidateService.GetById(id);
            
            Experience e = experienceService.GetById(ExperienceId);
            c.Experiences.Remove(e);
            candidateService.Commit();
            experienceService.Delete(e);
            experienceService.Commit();
            return RedirectToAction("Details", new { id });
        }
    }
}
