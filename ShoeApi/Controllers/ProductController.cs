using ShoeApi.DataContext;
using ShoeApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ShoeApi.Controllers
{
    public class ProductController : ApiController
    {
        private ShoeApiContext db;
        DateTime createdDate = DateTime.Now;

        //Get ALL
        public HttpResponseMessage GetAllProduct()
        {

            using (db = new ShoeApiContext())
            {
                var products = db.tProducts.ToList();

                var result = products.Select(p => new
                {
                    Prod_Id = p.Prod_Id,
                    Prod_Name = p.Prod_Name,
                    Prod_ShortName = p.Prod_ShortName,
                    Prod_Price = p.Prod_Price,
                    Prod_Selling = p.Prod_Selling,
                    Prod_Description = p.Prod_Description,
                    //Prod_Image = p.Prod_Image_Path,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId,
                    SizeId = p.SizeId
                }).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
        }


        //Get by ID
        public HttpResponseMessage GetProductbyId(int id)
        {

            using (db = new ShoeApiContext())
            {
                var p = db.tProducts.Where(x => x.Prod_Id == id).FirstOrDefault();


                var result = new
                {
                    Prod_Id = p.Prod_Id,
                    Prod_Name = p.Prod_Name,
                    Prod_ShortName = p.Prod_ShortName,
                    Prod_Price = p.Prod_Price,
                    Prod_Selling = p.Prod_Selling,
                    Prod_Description = p.Prod_Description,
                    //Prod_Image = p.Prod_Image_Path,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId,
                    SizeId = p.SizeId
                };

                return Request.CreateResponse(HttpStatusCode.OK, result);

            }

        }


        //Add Product
        public HttpResponseMessage PostProduct(tblProducts t)
        {
            using (db = new ShoeApiContext())
            {
                if (t != null)
                {

                    if (db.tProducts.Any(x => x.Prod_Name == t.Prod_Name))
                    {
                        return Request.CreateResponse(HttpStatusCode.Found, "Product Name already Exists");
                    }
                    else
                    {
                        //string myfile = Path.GetFileNameWithoutExtension(t.ImgFile.FileName);
                        
                        //HttpPostedFileBase postfile = t.ImgFile;
                        //string extention = Path.GetExtension(t.ImgFile.FileName);
                        //myfile = myfile + extention;
                        //t.Prod_Image_Path = "~/Images/" + myfile;
                        //string databaseImage = t.Prod_Image_Path;
                        //myfile = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/"), myfile);
                        //t.ImgFile.SaveAs(myfile);
                        tblProducts products = new tblProducts
                        {
                            Prod_Name = t.Prod_Name,
                            Prod_ShortName = t.Prod_ShortName,
                            Prod_Price = t.Prod_Price,
                            Prod_Selling = t.Prod_Selling,
                            Prod_Description = t.Prod_Description,
                            //Prod_Image_Path = databaseImage,
                            BrandId = t.BrandId,
                            CategoryId = t.CategoryId,
                            SizeId = t.SizeId,
                            Prod_CreatedDate = createdDate
                        };
                        db.tProducts.Add(t);
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.Created, t);
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Provide Required Info");
                }
            }
        }

       

        //Update Product
        public HttpResponseMessage PutProduct(int id, tblProducts t)
        {
            using (db = new ShoeApiContext())
            {
                var editProd = db.tProducts.Where(x => x.Prod_Id == id).FirstOrDefault();

                if (editProd != null)
                {
                    editProd.Prod_Name = t.Prod_Name;
                    editProd.Prod_ShortName = t.Prod_ShortName;
                    editProd.Prod_Price = t.Prod_Price;
                    editProd.Prod_Selling = t.Prod_Selling;
                    editProd.Prod_Description = t.Prod_Description;
                    //editProd.Prod_Image_Path = t.Prod_Image_Path;
                    editProd.BrandId = t.BrandId;
                    editProd.CategoryId = t.CategoryId;
                    editProd.SizeId = t.SizeId;
                    editProd.Prod_CreatedDate = createdDate;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, editProd);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Product id " + id + " Not Found");
                }
            }
        }


        //Delete Product
        public HttpResponseMessage DeleteProduct(int id)
        {

            using (db = new ShoeApiContext())
            {
                var delProdcut = db.tProducts.Where(x => x.Prod_Id == id).FirstOrDefault();

                if (delProdcut != null)
                {
                    db.tProducts.Remove(delProdcut);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Product with id = " + id + " not found");
                }

            }
        }
    }
}
