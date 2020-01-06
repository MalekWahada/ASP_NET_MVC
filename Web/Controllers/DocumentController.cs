using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class DocumentController : Controller
    {
        Bibliothequeservice BS = new Bibliothequeservice();
        DocumentService DS = new DocumentService();


        // GET: Document
        public ActionResult Index()
        {
            
                List<DocumentViewModel> list = new List<DocumentViewModel>();
                var d = DS.GetAll();
                foreach (var i in d)
                {
                    DocumentViewModel Dvm = new DocumentViewModel();

                    Dvm.DocumentID = i.DocumentID;
                    Dvm.Titre = i.Titre;
                    Dvm.Categorie = i.Categorie;
                    Dvm.Etat = (Web.Models.Etat)i.Etat;
                    Dvm.BibliothequeFK = i.BibliothequeFK;
                list.Add(Dvm);
                }


                return View(list);
            
        }
        [HttpPost]
        public ActionResult Index(string recherche)
        {
            List<DocumentViewModel> list = new List<DocumentViewModel>();
            var a = DS.GetAll();
            foreach (var i in a)
            {
                DocumentViewModel Dvm = new DocumentViewModel();

                Dvm.DocumentID = i.DocumentID;
                Dvm.Titre = i.Titre;
                Dvm.Categorie = i.Categorie;
                Dvm.Etat = (Web.Models.Etat)i.Etat;
                Dvm.BibliothequeFK = i.BibliothequeFK;
                list.Add(Dvm);
            }
            if (!String.IsNullOrEmpty(recherche))
            {
                list = list.Where(m => m.Titre.Contains(recherche)).ToList();
            }

            return View(list);


        }

        // GET: Document/Details/5
        public ActionResult Details(int id)
        {
            var d = DS.GetById(id);
            DocumentViewModel Dvm = new DocumentViewModel();
            Dvm.Categorie = d.Categorie;
            Dvm.DocumentID = d.DocumentID;
            Dvm.Etat = (Web.Models.Etat)d.Etat;
            Dvm.Titre = d.Titre;
            Dvm.BibliothequeFK = d.BibliothequeFK;
            return View(Dvm);
        }

        // GET: Document/Create
      

        public ActionResult Create()
        {
            var Biblio = BS.GetAll();
            List<BibliothequeViewModel> Lbvm = new List<BibliothequeViewModel>();
            foreach (var i in Biblio)
            {
                BibliothequeViewModel Bvm = new BibliothequeViewModel();

                Bvm.BibliothequeCode = i.BibliothequeCode;
                Bvm.NbrDocument = i.BibliothequeCode;

                Lbvm.Add(Bvm);

            }

            ViewBag.Biblio = new SelectList(Biblio, "BibliothequeCode", "BibliothequeCode");
            return View();
            }

        // POST: Document/Create
        [HttpPost]
        public ActionResult Create(DocumentViewModel Dvm)
        {
            Document d = new Document();

            d.DocumentID = Dvm.DocumentID;

            d.Titre = Dvm.Titre;
            d.Categorie = Dvm.Categorie;

            d.Etat = (Domain.Entities.Etat)Dvm.Etat;

           d.Biblio = new Bibliotheque { BibliothequeCode = Dvm.BibliothequeFK };

            DS.Add(d);
            DS.Commit();
            return RedirectToAction("Index");

 //   }

//        try
//        {
//            // TODO: Add insert logic here

//            return RedirectToAction("Index");
//    }
//        catch
//        {
//            return View();
//}


    }

    // GET: Document/Edit/5
    public ActionResult Edit(int id)
        {
            var d = DS.GetById(id);
            DocumentViewModel Dvm = new DocumentViewModel();
            Dvm.Categorie = d.Categorie;
            Dvm.DocumentID = d.DocumentID;
            Dvm.Etat.Equals(d.Etat);
            Dvm.Titre = d.Titre;
            Dvm.BibliothequeFK = d.BibliothequeFK;

            var b = BS.GetAll();
            List<BibliothequeViewModel> Lbvm = new List<BibliothequeViewModel>();
            foreach (var i in b)
            {
                BibliothequeViewModel Bvm = new BibliothequeViewModel();
                Bvm.BibliothequeCode = i.BibliothequeCode;
                Bvm.NbrDocument = i.NbrDocument;
                Lbvm.Add(Bvm);
            }
            ViewData["Biblio"] = new SelectList(Lbvm, "BibliothequeCode", "BibliothequeCode");

            return View(Dvm);
        }

        // POST: Document/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DocumentViewModel DVM)
        {
            Document d = DS.GetById(id);
            d.Etat = (Domain.Entities.Etat)DVM.Etat;
            d.DocumentID = DVM.DocumentID;
            d.Titre = DVM.Titre; d.Categorie = DVM.Categorie;
            Bibliotheque b = BS.GetById(id);
            b = new Bibliotheque { BibliothequeCode = DVM.BibliothequeFK };
            DS.Update(d);
            DS.Commit();
            return RedirectToAction("Index");
        }

        // GET: Document/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Document/Delete/5
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
