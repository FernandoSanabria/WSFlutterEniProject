using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSFlutterEniProject.Interfaces;
using WSFlutterEniProject.Models;
using WSFlutterEniProject.Models.Requests;
using WSFlutterEniProject.Models.Responses;

namespace WSFlutterEniProject.Services
{
    public class ProductService : IProductInterface
    {


        public void Delete(int Id)
        {
  
            using(FlutterEniProjectContext db = new FlutterEniProjectContext())
            {
                try
                {
                    db.Product.RemoveRange(db.Product.Where(x => x.Id == Id  ));
                    db.ImagesProduct.RemoveRange(db.ImagesProduct.Where(x => x.IdProduct == Id));
                    db.SaveChanges();
                }
                catch (Exception err)
                {

                    throw new Exception(err.Message);
                }
            }
        }


        public void Update(ProductRequest productRequest)
        {
            using (FlutterEniProjectContext db = new FlutterEniProjectContext())
            {

                try
                {
                    var product = (from p in db.Product
                                        where p.Id == productRequest.Id
                                        select p
                                        ).SingleOrDefault();

                    product.IdCategory = productRequest.IdCategory;
                    product.Name = productRequest.Name;
                    product.BasePrice = productRequest.BasePrice;
                    product.Code = productRequest.Code;
                    product.Composition = productRequest.Composition;
                    product.Tissue = productRequest.Tissue;
                    product.Use = productRequest.Use;
                    product.WaterRepelence = productRequest.WaterRepelence;
                    db.Entry(product).State = EntityState.Modified;

                    db.SaveChanges();


                    if (productRequest.Images != null)
                    {
                        foreach (var image in productRequest.Images)
                        {
                            var imageProduct = new ImagesProduct();
                            imageProduct.IdProduct = product.Id;
                            imageProduct.UrlImage = image.UrlImage;
                            db.ImagesProduct.Add(imageProduct);
                            db.SaveChanges();
                        }

                    }



                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }

            }
        }



        public void Add(ProductRequest productRequest)
        {
            using (FlutterEniProjectContext db = new FlutterEniProjectContext())
            {
                try
                {
                    Product product = new Product();
                    product.IdCategory = productRequest.IdCategory;
                    product.BasePrice = productRequest.BasePrice;
                    product.Name = productRequest.Name;
                    product.Code = productRequest.Code;
                    product.Composition = productRequest.Composition;
                    product.Description = productRequest.Description;
                    product.Tissue = productRequest.Tissue;
                    product.WaterRepelence = productRequest.WaterRepelence;
                    product.Use = productRequest.Use;
                    db.Product.Add(product);
                    db.SaveChanges();

                    if (productRequest.Images != null)
                    {
                        foreach (var image in productRequest.Images)
                        {
                            var imageProduct = new ImagesProduct();
                            imageProduct.IdProduct = product.Id;
                            imageProduct.UrlImage = image.UrlImage;
                            db.ImagesProduct.Add(imageProduct);
                            db.SaveChanges();
                        }

                    }
                }
                catch (Exception err )
                {
                    throw new Exception(err.Message);
                }

            }
        }



        public List<ProductResponse> GetByCategory(int Id)
        {
            using (FlutterEniProjectContext db = new FlutterEniProjectContext())
            {
                try
                {

                    var listProducts = (from p in db.Product
                                        where p.IdCategory == Id
                                        select new ProductResponse
                                        {
                                            Id = p.Id,
                                            IdCategory = p.IdCategory,
                                            BasePrice = p.BasePrice,
                                            Name = p.Name,
                                            Code = p.Code,
                                            Composition = p.Composition,
                                            Tissue = p.Tissue,
                                            Use = p.Use,
                                            WaterRepelence = p.WaterRepelence,
                                            Images = (from i in db.ImagesProduct
                                                      where p.Id == i.IdProduct
                                                      select new ProductResponse.Image
                                                      {
                                                          Id = i.Id,
                                                          IdProduct= i.IdProduct,
                                                          UrlImage = i.UrlImage
                                                      }
                                            
                                            ).ToList()
                                        }
                                        ).ToList();


                    return listProducts;

                }
                catch (Exception err)
                {

                    throw new Exception(err.Message);
                }
            }

        }

        public ProductResponse GetById( int Id)
        {

            using (FlutterEniProjectContext db = new FlutterEniProjectContext())
            {
                try
                {

                    var listProducts = (from p in db.Product
                                        where p.Id == Id
                                        select new ProductResponse
                                        {
                                            Id = p.Id,
                                            IdCategory = p.IdCategory,
                                            Name = p.Name,
                                            BasePrice = p.BasePrice,
                                            Code = p.Code,
                                            Composition = p.Composition,
                                            Tissue = p.Tissue,
                                            Use = p.Use,
                                            WaterRepelence = p.WaterRepelence,
                                            Images = (from i in db.ImagesProduct
                                                      where p.Id == i.IdProduct
                                                      select new ProductResponse.Image
                                                      {
                                                          Id = i.Id,
                                                          IdProduct = i.IdProduct,
                                                          UrlImage = i.UrlImage
                                                      }

                                            ).ToList()
                                        }
                                        ).FirstOrDefault();


                    return listProducts;

                }
                catch (Exception err)
                {

                    throw new Exception(err.Message);
                }
            }



        }
    }
}
