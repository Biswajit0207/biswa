using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DQWEB.Models;

namespace DQWEB.Controllers
{
    public class CompanyController : Controller
    {


        ///Comapny Name Code
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetComapnyDetails()
        {
            using (DQWEBDBContext contextobj = new DQWEBDBContext())
            {
                var complist = contextobj.C_cmp01.ToList();
                return Json(complist, JsonRequestBehavior.AllowGet);
            }
          }
        public JsonResult GetCompById(string id)
        {
            using (DQWEBDBContext contextObj = new DQWEBDBContext())
            {
                var COMP_SLNO = Convert.ToInt32(id);
                var complist = contextObj.C_cmp01.Find(COMP_SLNO);

                return Json(complist, JsonRequestBehavior.AllowGet);
            }
        }

        //Update Company
        public JsonResult UpdateCompany(_cmp01 comp)
        {
            if (comp != null)
            {
                using (DQWEBDBContext contextObj = new DQWEBDBContext())
                {
                    int COMP_SLNO = Convert.ToInt32(comp.COMP_SLNO);
                    _cmp01 _comp = contextObj.C_cmp01.Where(b => b.COMP_SLNO == COMP_SLNO).FirstOrDefault();
                    _comp.COMP_SLNO = comp.COMP_SLNO;
                    _comp.CMP_NM = comp.CMP_NM;
                    _comp.CMP_CD = comp.CMP_CD;
                    _comp.ADD1 = comp.ADD1;
                    _comp.CMP_TYPE = comp.CMP_TYPE;
                    contextObj.SaveChanges();
                    return Json("Company record updated successfully", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("Invalid Company record", JsonRequestBehavior.AllowGet);

            }
        }
        // Add Company
        public JsonResult AddCompany(_cmp01 cmp)
        {
            if (cmp != null)
            {
                using (DQWEBDBContext contextObj = new DQWEBDBContext())
                {
                    contextObj.C_cmp01.Add(cmp);
                    contextObj.SaveChanges();
                    return Json("Company record added successfully", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("Invalid Company record", JsonRequestBehavior.AllowGet);
            }
        }
        // Delete Company
        public JsonResult DeleteCompany(string Id)
        {

            if (!String.IsNullOrEmpty(Id))
            {
                try
                {
                    int COMP_SLNO = Int32.Parse(Id);
                    using (DQWEBDBContext contextObj = new DQWEBDBContext())
                    {
                        var _comp = contextObj.C_cmp01.Find(COMP_SLNO);
                        contextObj.C_cmp01.Remove(_comp);
                        contextObj.SaveChanges();
                        return Json(" Comp record deleted successfully", JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(ex, JsonRequestBehavior.AllowGet);

                }
            }
            else
            {
                return Json("Invalid Comp record", JsonRequestBehavior.AllowGet);
            }
        }

        //////// Comapny Details
        //public JsonResult GetCmpDetails()
        //{
        //    using (DQWEBDBContext contextobj = new DQWEBDBContext())
        //    {
        //        var complist = contextobj.C_cmp01.ToList();
        //        return Json(complist, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //public JsonResult GetCompById(string id)
        //{
        //    using (DQWEBDBContext contextObj = new DQWEBDBContext())
        //    {
        //        var COMP_SLNO = Convert.ToInt32(id);
        //        var complist = contextObj.C_cmp01.Find(COMP_SLNO);

        //        return Json(complist, JsonRequestBehavior.AllowGet);
        //    }
        //}

        ////Update Book
        //public JsonResult UpdateCompany(_cmp01 comp)
        //{
        //    if (comp != null)
        //    {
        //        using (DQWEBDBContext contextObj = new DQWEBDBContext())
        //        {
        //            int COMP_SLNO = Convert.ToInt32(comp.COMP_SLNO);
        //            _cmp01 _comp = contextObj.C_cmp01.Where(b => b.COMP_SLNO == COMP_SLNO).FirstOrDefault();
        //            _comp.COMP_SLNO = comp.COMP_SLNO;
        //            _comp.CMP_NM = comp.CMP_NM;
        //            _comp.CMP_CD = comp.CMP_CD;
        //            _comp.ADD1 = comp.ADD1;
        //            _comp.CMP_TYPE = comp.CMP_TYPE;
        //            contextObj.SaveChanges();
        //            return Json("Company record updated successfully", JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        return Json("Invalid Company record", JsonRequestBehavior.AllowGet);

        //    }
        //}
        //// Add book
        //public JsonResult AddCompany(_cmp01 cmp)
        //{
        //    if (cmp != null)
        //    {
        //        using (DQWEBDBContext contextObj = new DQWEBDBContext())
        //        {
        //            contextObj.C_cmp01.Add(cmp);
        //            contextObj.SaveChanges();
        //            return Json("Company record added successfully", JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        return Json("Invalid Company record", JsonRequestBehavior.AllowGet);
        //    }
        //}
        //// Delete book
        //public JsonResult DeleteCompany(string Id)
        //{

        //    if (!String.IsNullOrEmpty(Id))
        //    {
        //        try
        //        {
        //            int COMP_SLNO = Int32.Parse(Id);
        //            using (DQWEBDBContext contextObj = new DQWEBDBContext())
        //            {
        //                var _comp = contextObj.C_cmp01.Find(COMP_SLNO);
        //                contextObj.C_cmp01.Remove(_comp);
        //                contextObj.SaveChanges();
        //                return Json(" Comp record deleted successfully", JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return Json(ex, JsonRequestBehavior.AllowGet);

        //        }
        //    }
        //    else
        //    {
        //        return Json("Invalid Comp record", JsonRequestBehavior.AllowGet);
        //    }
        //}




    }
}