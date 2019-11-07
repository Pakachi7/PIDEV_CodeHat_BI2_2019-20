using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyService Service = null;
        public CompanyController()
        {
            Service = new CompanyService();
        }
        // GET: Company
        public ActionResult Index(string searchString)
        {
            var companies = new List<CompanyVM>();
            IEnumerable<Company> companyDomain = Service.GetMany();
            if (!String.IsNullOrEmpty(searchString))
            {
                companyDomain = Service.GetCompanyByName(searchString).ToList();
            }


            foreach (Company cvm in companyDomain)
            {
                companies.Add(new CompanyVM()
                {
                    CompanyId=cvm.CompanyId,
                    Company_Name = cvm.Company_Name,
                    Company_Number = cvm.Company_Number,
                    Company_Email = cvm.Company_Email,
                    Company_Description = cvm.Company_Description,
                    Company_Website = cvm.Company_Website,
                    Company_Logo = cvm.Company_Logo,
                    Company_Address = cvm.Company_Address,
                   



                }) ;
            }

            return View(companies);
        }

      

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult Create(CompanyVM cvm, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid || file==null || file.ContentLength ==0)
            {
                return RedirectToAction("Create");
            }
            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                Console.WriteLine(fileName);
             

                var path = Path.Combine(Server.MapPath(@"/Content/Uploads/"), fileName);

                file.SaveAs(path);

            }




            Company newcompany = new Company()
            {
                Company_Name = cvm.Company_Name,
                Company_Number = cvm.Company_Number,
                Company_Email = cvm.Company_Email,
                Company_Description = cvm.Company_Description,
                Company_Website = cvm.Company_Website,
                Company_Logo = fileName,
                NumberOfEmployees = cvm.NumberOfEmployees,
                Company_Address=cvm.Company_Address

            };

            Service.Add(newcompany);
            Service.Commit();
           


            return RedirectToAction("Index");

        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Company c = Service.GetById(id);
            CompanyVM cvm = new CompanyVM()
            {
                CompanyId = c.CompanyId,
                Company_Name = c.Company_Name,
                Company_Number = c.Company_Number,
                Company_Email = c.Company_Email,
                Company_Description = c.Company_Description,
                Company_Website = c.Company_Website,
                Company_Logo = c.Company_Logo,
                NumberOfEmployees = c.NumberOfEmployees,
                Company_Address = c.Company_Address



            };
            if (c == null)
                return HttpNotFound();
            return View(cvm);



        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CompanyVM cvm, HttpPostedFileBase file)
        {
            //if (!ModelState.IsValid || file == null || file.ContentLength == 0)
            //{
            //    ViewBag.Message = "You have not specified a file.";
            //    //RedirectToAction("Create");
            //}
            var fileName = cvm.Company_Logo;
            if (file.FileName != fileName)
            {
                fileName = Path.GetFileName(file.FileName);
              


                var path = Path.Combine(Server.MapPath(@"/Content/Uploads/"), fileName);
                //var path = Path.Combine(Server.MapPath("~/Content/Uploads/"), fileName);

                file.SaveAs(path);
                ViewBag.Message = "File uploaded successfully";

            }
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    Company c = Service.GetById(id);
                    c.CompanyId = cvm.CompanyId;
                    c.Company_Name = cvm.Company_Name;
                    c.Company_Number = cvm.Company_Number;
                    c.Company_Email = cvm.Company_Email;
                    c.Company_Description = cvm.Company_Description;
                    c.Company_Website = cvm.Company_Website;
                    c.Company_Logo = fileName;
                    c.NumberOfEmployees = cvm.NumberOfEmployees;
                    c.Company_Address = cvm.Company_Address;





                    if (c == null)
                        return HttpNotFound();


                    // Service.UpdateCompany(c);
                    Service.Update(c);
                    Service.Commit();
                   

                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(cvm);

            }
            catch
            {
                return View();
            }

        }
        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Company c = Service.GetById(id);
            CompanyVM cvm = new CompanyVM()
            {
                CompanyId = c.CompanyId,
                Company_Name = c.Company_Name,
                Company_Number = c.Company_Number,
                Company_Email = c.Company_Email,
                Company_Description = c.Company_Description,
                Company_Website = c.Company_Website,
                Company_Logo = c.Company_Logo,
                NumberOfEmployees = c.NumberOfEmployees,
                Company_Address = c.Company_Address



            };
            if (c == null)
                return HttpNotFound();

            return View(cvm);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Company c = Service.GetById(id);
            CompanyVM cvm = new CompanyVM()
            {
                CompanyId = c.CompanyId,
                Company_Name = c.Company_Name,
                Company_Number = c.Company_Number,
                Company_Email = c.Company_Email,
                Company_Description = c.Company_Description,
                Company_Website = c.Company_Website,
                Company_Logo = c.Company_Logo,
                NumberOfEmployees = c.NumberOfEmployees,
                Company_Address = c.Company_Address



            };
            if (c == null)
                return HttpNotFound();
            return View(cvm);
        }

        // POST: Company/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CompanyVM aftervm)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    Company c = Service.GetById(id);
                    CompanyVM cvm = new CompanyVM()
                    {
                        CompanyId=c.CompanyId,
                        Company_Name = c.Company_Name,
                        Company_Number = c.Company_Number,
                        Company_Email = c.Company_Email,
                        Company_Description = c.Company_Description,
                        Company_Website = c.Company_Website,
                        Company_Logo = c.Company_Logo,
                        NumberOfEmployees = c.NumberOfEmployees,
                        Company_Address = c.Company_Address



                    };
                  
                    if (c == null)
                        return HttpNotFound();
                    Service.Delete(c);
                    Service.Commit();
                  

                    return RedirectToAction("Index");
            //    }
            //    // TODO: Add delete logic here
            //    return View(aftervm);

            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
