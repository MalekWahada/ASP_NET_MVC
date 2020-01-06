using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class AuteurController : Controller


    {
        AuteurService As = new AuteurService();
        // GET: Auteur
        public ActionResult Index()
        {
            List<AuteurViewModel> list = new List<AuteurViewModel>();
            var a = As.GetAll();
            foreach (var i in a)
            {
                AuteurViewModel Avm = new AuteurViewModel();

                Avm.AuteurCode = i.AuteurCode;
                Avm.imageURL = i.Imageurl;
                Avm.NomComplet = new NomCompletViewModel() { Nom = i.NomComplet.Nom, Prenom = i.NomComplet.Prenom };
                list.Add(Avm);
            }


            return View(list);
        }

        [HttpPost]
        public ActionResult Index(string recherche)
        {
            List<AuteurViewModel> List = new List<AuteurViewModel>();
            var a = As.GetAll();
            foreach (var i in a)
            {
                AuteurViewModel Avm = new AuteurViewModel();

                Avm.AuteurCode = i.AuteurCode;

                Avm.NomComplet = new NomCompletViewModel { Nom = i.NomComplet.Nom, Prenom = i.NomComplet.Prenom };



                List.Add(Avm);
            }
            if (!String.IsNullOrEmpty(recherche))
            {
                List = List.Where(m => m.NomComplet.Nom.Contains(recherche)).ToList();
            }

            return View(List);


        }


        // GET: Auteur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Auteur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auteur/Create
        [HttpPost]
        public ActionResult Create(AuteurViewModel Avm, HttpPostedFileBase file)
        {
            Auteur a = new Auteur();
            a.AuteurCode = Avm.AuteurCode;
            a.NomComplet = new NomComplet() {Nom = Avm.NomComplet.Nom, Prenom = Avm.NomComplet.Prenom };
            a.Imageurl = file.FileName;
            As.Add(a);
            As.Commit();
            //try
            //{
            //    // TODO: Add insert logic here
            var fileName = "";
            if (file.ContentLength > 0)
            {
              

                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Auteur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Auteur/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auteur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Auteur/Delete/5
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
