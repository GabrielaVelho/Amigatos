using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoAmigatos.Models;
using ProjetoAmigatos.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProjetoAmigatos.Controllers
{
    public class GatosController : Controller
    {
        private GatoDBContext db = new GatoDBContext();

        // GET: Gatos
        public ActionResult Index(int? SelectedRaca)
        {
            var racas = db.Racas.OrderBy(r => r.Nome).ToList();
            ViewBag.SelectedRaca = new SelectList(racas, "RacaID", "Nome", SelectedRaca);
            int racaID = SelectedRaca.GetValueOrDefault();
            var gatos = db.Gatos.Where(g => !SelectedRaca.HasValue || g.RacaID == racaID).Include(g=>g.Sexo);

            return View(gatos);
        }

        // GET: Gatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gato gato = db.Gatos.Find(id);
            if (gato == null)
            {
                return HttpNotFound();
            }
            return View(gato);
        }

        // GET: Gatos/Create
        [Authorize(Users = "admin@mvc.br")]
        public ActionResult Create()
        {
            ViewBag.RacaID = new SelectList(db.Racas, "RacaID", "Nome");
            ViewBag.SexoID = new SelectList(db.Sexos, "SexoID", "Nome");
            return View();
        }

        // POST: Gatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GatoID,Nome,Idade,Adotado,DataAdocao,RacaID,SexoID")] Gato gato)
        {
            if (ModelState.IsValid)
            {
                db.Gatos.Add(gato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RacaID = new SelectList(db.Racas, "RacaID", "Nome", gato.RacaID);
            ViewBag.SexoID = new SelectList(db.Sexos, "SexoID", "Nome", gato.SexoID);
            return View(gato);
        }

        // GET: Gatos/Edit/5
        [Authorize(Users = "admin@mvc.br")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gato gato = db.Gatos.Find(id);
            if (gato == null)
            {
                return HttpNotFound();
            }
            ViewBag.RacaID = new SelectList(db.Racas, "RacaID", "Nome", gato.RacaID);
            ViewBag.SexoID = new SelectList(db.Sexos, "SexoID", "Nome", gato.SexoID);
            return View(gato);
        }

        // POST: Gatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int gatoID, String nome,
            int idade, int racaID, int sexoID, string imageUrl,
            HttpPostedFileBase imageName)

        {
            var gato = db.Gatos.Find(gatoID);
            if (ModelState.IsValid && gato != null)
            {
                gato.Nome = nome;
                gato.Idade = idade;
                gato.RacaID = racaID;
                gato.SexoID = sexoID;
                gato.ImageUrl = imageUrl;

                if (imageName != null) {
                    gato.ImageMimeType = imageName.ContentType;
                    gato.ImageFile = new byte[imageName.ContentLength];
                    imageName.InputStream.Read(gato.ImageFile, 0, imageName.ContentLength);
                }

                db.Entry(gato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RacaID = new SelectList(db.Racas, "RacaID", "Nome", gato.RacaID);
            ViewBag.SexoID = new SelectList(db.Sexos, "SexoID", "Nome", gato.SexoID);
            return View(gato);
        }

        // GET: Gatos/Delete/5
        [Authorize(Users = "admin@mvc.br")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gato gato = db.Gatos.Find(id);
            if (gato == null)
            {
                return HttpNotFound();
            }
            return View(gato);
        }

        // POST: Gatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gato gato = db.Gatos.Find(id);
            db.Gatos.Remove(gato);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GetImage(int id) {
            Gato gato = db.Gatos.Find(id);
            if(gato != null && gato.ImageFile != null) {
                return File(gato.ImageFile, gato.ImageMimeType);
            }
            else {
                return new FilePathResult("~/Images/nao-disponivel.jpg", "image/jpeg");
            }
        }
        [Authorize]
        public ActionResult Adotar(int id) {
            Gato gato = db.Gatos.Find(id);
            //o gato ainda não possui dono
            if (gato.User == null)
            {
                gato.User = User.Identity.GetUserName();
                db.Entry(gato).State = EntityState.Modified;
                db.SaveChanges();
            }
            //caso o gato já tenha dono
            else
            {
                RedirectToAction("Details");
            }
            return View(gato);
        }

        public ActionResult About()
        {
            var info = from gato in db.Gatos
                       group gato by gato.Raca into infoRaca
                       select new RacaAbout
                       {
                           NomeRaca = infoRaca.Key.Nome,
                           Qtd = infoRaca.Count(),
                           TotalAdocoes = infoRaca.Where(s => s.User != null).Count(),
                           numMasculino = infoRaca.Where(s => s.Sexo.Nome == "Masculino").Count(),
                           numFeminino = infoRaca.Where(s => s.Sexo.Nome == "Feminino").Count()
                       };
            return View(info.ToList());
        }
    }
}
