using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FacebookLoginTesting.Models;
using System.IO;
using Microsoft.AspNet.Identity;

namespace FacebookLoginTesting.Controllers
{
    public class post_recipeController : Controller
    {
        private cookingapp_latestEntities db = new cookingapp_latestEntities();

        // GET: post_recipe
        public ActionResult Index()
        {
            var post_recipe = db.post_recipe.Include(p => p.user_list);
            return View(post_recipe.ToList());
        }

        // GET: post_recipe/Details/5
        public ActionResult Post_RecipeDetails(int? id)
        {
            List<post_ingredient> post_ingredientList;
            List<post_instruction> post_instructionList;
            Post_RecipeIngredientInstructionVM postrecipeVM;

            using (db)
            {
                if (id != null)
                {
                    post_recipe post_recipe = db.post_recipe.Find(id);
                    ViewBag.RecipeName = post_recipe.post_recipe_name;
                    post_ingredientList = db.post_ingredient.ToArray().Where(x => x.post_recipe_id == post_recipe.post_recipe_id).ToList();
                    post_instructionList = db.post_instruction.ToArray().Where(x => x.post_recipe_id == post_recipe.post_recipe_id).ToList();
                    postrecipeVM = new Post_RecipeIngredientInstructionVM(post_recipe, post_ingredientList, post_instructionList);
                }
                else
                {
                    return Redirect("Index");
                }
            }
            return View(postrecipeVM);
        }

        // GET: post_recipe/Create
        public ActionResult Create()
        {
            //ViewBag.userid = new SelectList(db.user_list, "userid", "username");
            return View();
        }

        // POST: post_recipe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "post_recipe_id,post_ImageName,post_ImagePath,post_recipe_name")] post_recipe post_recipe, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string FileName = Path.GetFileName(file.FileName);
                        string FilePath = Path.Combine(Server.MapPath("~/Images"), FileName);
                        file.SaveAs(FilePath);
                        string tmp_name = User.Identity.GetUserName();
                        user_list user = db.user_list.Where(x => x.user_email == tmp_name).FirstOrDefault();
                        post_recipe.userid = user.userid;
                        post_recipe.post_ImageName = FileName;
                        ViewBag.post_ImageName = FileName;
                        db.post_recipe.Add(post_recipe);
                        db.SaveChanges();
                    }
                    ViewBag.Message = "File Uploaded Successfully!!";
                }
                catch
                {
                    ViewBag.Message = "File upload failed!!";
                }
                //return RedirectToAction("Index");
            }

            return View();
            //if (ModelState.IsValid)
            //{
            //    db.post_recipe.Add(post_recipe);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.userid = new SelectList(db.user_list, "userid", "username", post_recipe.userid);
            //return View(post_recipe);
        }

        // GET: post_recipe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post_recipe post_recipe = db.post_recipe.Find(id);
            if (post_recipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.userid = new SelectList(db.user_list, "userid", "username", post_recipe.userid);
            return View(post_recipe);
        }

        // POST: post_recipe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "post_recipe_id,userid,post_ImageName,post_ImagePath,post_recipe_name")] post_recipe post_recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post_recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userid = new SelectList(db.user_list, "userid", "username", post_recipe.userid);
            return View(post_recipe);
        }

        // GET: post_recipe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post_recipe post_recipe = db.post_recipe.Find(id);
            if (post_recipe == null)
            {
                return HttpNotFound();
            }
            return View(post_recipe);
        }

        // POST: post_recipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            post_recipe post_recipe = db.post_recipe.Find(id);
            db.post_recipe.Remove(post_recipe);
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
    }
}
