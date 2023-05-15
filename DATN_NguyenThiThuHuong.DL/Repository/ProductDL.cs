using Dapper;
using DATN_NguyenThiThuHuong.Common;
using DATN_NguyenThiThuHuong.Common.Constants;
using DATN_NguyenThiThuHuong.Common.Models;
using DATN_NguyenThiThuHuong.Common.Models.DTO;
using DATN_NguyenThiThuHuong.DL.Database;
using DATN_NguyenThiThuHuong.DL.Interfaces;
using System.Collections.Specialized;
using System.Data;
using static Dapper.SqlMapper;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace DATN_NguyenThiThuHuong.DL.Repository
{
    public class ProductDL : BaseDL<Product>, IProductDL
    {
        private IDatabaseConnection _databaseConnection;
        public ProductDL(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        /// <summary>
        /// Lấy danh sách có bộ lọc
        /// </summary>
        /// <param name="parametersFilter">Param bộ lọc truyền vào truyền vào</param>
        /// <returns>Danh sách đối tượng</returns>
        public object GetByFilterDetail(object parametersFilter)
        {
            try
            {
                // Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.GetByFilterDetail, tableName);

                var parameters = new DynamicParameters();
                parameters.Add("@TotalRecords", direction: ParameterDirection.Output);
                foreach (PropertyInfo propertyInfo in parametersFilter.GetType().GetProperties())
                {
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(parametersFilter));
                }

                // Mở kết nối
                _databaseConnection.Open();
                // Xử lý lấy dữ liệu trong stored
                var ProductDB = _databaseConnection.Connection().Query<ProductDB>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
                // Lấy số lượng

                //var ProductDB = result.Read<ProductDB>();
                var productRespone = ProductDB.GroupBy(x => x.ProductId).Select(x => new
                {
                    ProductId = x.Select(x => x.ProductId).FirstOrDefault(),
                    ProductCode = x.Select(x => x.ProductCode).FirstOrDefault(),
                    ProductName = x.Select(x => x.ProductName).FirstOrDefault(),
                    Discount = x.Select(x => x.Discount).FirstOrDefault(),
                    PublicDate = x.Select(x => x.PublicDate).FirstOrDefault(),
                    Sold = x.Select(x => x.Sold).FirstOrDefault(),
                    TypeId = x.Select(x => x.TypeId).FirstOrDefault(),
                    TypeName = x.Select(x => x.TypeName).FirstOrDefault(),
                    BrandId = x.Select(x => x.BrandId).FirstOrDefault(),
                    BrandName = x.Select(x => x.BrandName).FirstOrDefault(),
                    Description = x.Select(x => x.Description).FirstOrDefault(),
                    PriceDel = x.Select(x => x.PriceDel).FirstOrDefault(),
                    Quantity = x.Select(x => x.Quantity).FirstOrDefault(),
                    PriceSale = x.Select(x => x.PriceSale).FirstOrDefault(),
                    Images = x.GroupBy(x => x.ImageId).Select(x => new Image()
                    {
                        ImageId = x.Select(x => x.ImageId).FirstOrDefault(),
                        ImageLink = x.Select(x => x.ImageLink).FirstOrDefault(),
                        ImageName = x.Select(x => x.ImageName).FirstOrDefault(),
                    }).ToList(),
                    ProductVariants = x.GroupBy(x => new { x.ProductVariantId, x.ColorId }).Select(x => new ProductVariant()
                    {
                        ProductVariantId = x.Key.ProductVariantId,
                        ColorId = x.Key.ColorId,
                        ColorCode = x.Select(x => x.ColorCode).FirstOrDefault(),
                        Sizes = x.GroupBy(x => x.SizeId).Select(x => new Size()
                        {
                            SizeId = x.Key,
                            SizeNumber = x.Select(x => x.SizeNumber).FirstOrDefault()
                        }).ToList()
                    }).ToList()
                }).ToList();
                storedProcedureName = "Proc_Product_GetTotalProduct";

                int totalProduct = _databaseConnection.Connection().QueryFirstOrDefault<int>(storedProcedureName, commandType: CommandType.StoredProcedure);

                var data = new
                {
                    Total = totalProduct,
                    Data = productRespone.ToList()
                };

                // Đóng kết nối
                _databaseConnection.Close();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh sách có bộ lọc
        /// </summary>
        /// <param name="parametersFilter">Param bộ lọc truyền vào truyền vào</param>
        /// <returns>Danh sách đối tượng</returns>
        public override PagingResult<Product> GetByFilter(object parametersFilter)
        {
            try
            {
                //Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.GetByFilter, tableName);

                var parameters = new DynamicParameters();
                foreach (PropertyInfo propertyInfo in parametersFilter.GetType().GetProperties())
                {
                    // Add parameters
                    parameters.Add("p_" + propertyInfo.Name, propertyInfo.GetValue(parametersFilter));
                }

                // Mở kết nối
                _databaseConnection.Open();
                // Xử lý lấy dữ liệu trong stored
                var ProductDB = _databaseConnection.Connection().Query<ProductDB>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
                // Lấy số lượng 

                //var ProductDB = result.Read<ProductDB>();
                var productDictionary = new Dictionary<Guid, Product>();
                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.Connection().Query<Product, Image, Product>(
                                    storedProcedureName,
                                    (product, image) =>
                                    {
                                        Product productEntry;
                                        if (!productDictionary.TryGetValue(product.ProductId, out productEntry))
                                        {
                                            productEntry = product;
                                            productEntry.Images = new List<Image>();
                                            productDictionary.Add(productEntry.ProductId, productEntry);
                                        }
                                        if (image != null)
                                            productEntry.Images.Add(image);
                                        return productEntry;
                                    }, commandType: CommandType.StoredProcedure, param: parameters,
                                    splitOn: "ImageId")
                                    .Distinct()
                                    .ToList();
                var data = new PagingResult<Product>
                {
                    Total = result.Count(),
                    Data = result.ToList()
                };

                // Đóng kết nối
                _databaseConnection.Close();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
        public override Product GetById(Guid id)
        {
            try
            {
                // Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.GetById, typeof(Product).Name);

                // Thêm parameter
                var parameters = new DynamicParameters();
                parameters.Add($"p_{tableName}Id", id);

                // Mở kết nối
                _databaseConnection.Open();

                var productDictionary = new Dictionary<Guid, Product>();
                // Xử lý lấy dữ liệu trong stored
                var result = _databaseConnection.Connection().Query<Product, Image, Product>(
                                    storedProcedureName,
                                    (product, image) =>
                                    {
                                        Product productEntry;
                                        if (!productDictionary.TryGetValue(product.ProductId, out productEntry))
                                        {
                                            productEntry = product;
                                            productEntry.Images = new List<Image>();
                                            productDictionary.Add(productEntry.ProductId, productEntry);
                                        }

                                        productEntry.Images.Add(image);
                                        return productEntry;
                                    }, commandType: CommandType.StoredProcedure, param: parameters,
                                    splitOn: "ImageId")
                                    .Distinct()
                                    .ToList();

                // Đóng kết nối
                _databaseConnection.Close();

                return result[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

        public object GetByIDDetail(Guid id)
        {
            try
            {
                // Tên store procedure
                string storedProcedureName = string.Format(NameProcedureConstants.GetByIdDetail, typeof(Product).Name);

                // Thêm parameter
                var parameters = new DynamicParameters();
                parameters.Add($"p_{tableName}Id", id);

                // Mở kết nối
                _databaseConnection.Open();

                // Xử lý lấy dữ liệu trong stored
                var ProductDB = _databaseConnection.Connection().Query<ProductDB>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
                // Lấy số lượng 

                var productRespone = ProductDB.GroupBy(x => x.ProductId).Select(x => new
                {
                    ProductId = x.Select(x => x.ProductId).FirstOrDefault(),
                    ProductCode = x.Select(x => x.ProductCode).FirstOrDefault(),
                    ProductName = x.Select(x => x.ProductName).FirstOrDefault(),
                    Discount = x.Select(x => x.Discount).FirstOrDefault(),
                    PublicDate = x.Select(x => x.PublicDate).FirstOrDefault(),
                    Sold = x.Select(x => x.Sold).FirstOrDefault(),
                    TypeId = x.Select(x => x.TypeId).FirstOrDefault(),
                    BrandId = x.Select(x => x.BrandId).FirstOrDefault(),
                    BrandName = x.Select(x => x.BrandName).FirstOrDefault(),
                    TypeName = x.Select(x => x.TypeName).FirstOrDefault(),
                    Description = x.Select(x => x.Description).FirstOrDefault(),
                    PriceDel = x.Select(x => x.PriceDel).FirstOrDefault(),
                    Quantity = x.Select(x => x.Quantity).FirstOrDefault(),
                    PriceSale = x.Select(x => x.PriceSale).FirstOrDefault(),
                    Images = x.GroupBy(x => x.ImageId).Select(x => new
                    {
                        ImageId = x.Select(x => x.ImageId).FirstOrDefault(),
                        ImageLink = x.Select(x => x.ImageLink).FirstOrDefault(),
                        ImageName = x.Select(x => x.ImageName).FirstOrDefault(),
                    }).ToList(),
                    Colors = x.GroupBy(x => new { x.ColorId }).Select(x => new
                    {
                        ColorId = x.Key.ColorId,
                        ColorCode = x.Select(x => x.ColorCode).FirstOrDefault(),
                        ColorName = x.Select(x => x.ColorName).FirstOrDefault(),
                        Sizes = x.GroupBy(x => new { x.SizeId, x.ProductVariantId }).Select(x => new
                        {
                            ProductVariantId = x.Key.ProductVariantId,
                            SizeId = x.Key.SizeId,
                            Quantity = x.Key.ProductVariantId,
                            SizeNumber = x.Select(x => x.SizeNumber).FirstOrDefault(),
                            ProductVariantQuantity = x.Select(x => x.ProductVariantQuantity).FirstOrDefault()
                        }).ToList()
                    }).ToList(),
                    Sizes = x.GroupBy(x => x.SizeId).Select(x => new
                    {
                        SizeId = x.Key,
                        SizeNumber = x.Select(x => x.SizeNumber).FirstOrDefault(),
                    }).ToList(),
                }).ToList().ElementAt(0);

                // Đóng kết nối
                _databaseConnection.Close();

                return productRespone;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Đóng kết nối
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }
        public bool UpdateSold(Guid productId, int sold)
        {
            try
            {
                string query = $"Update {tableName} set Sold = {sold} where {tableName}Id = {productId}";

                //Mở kết nối
                _databaseConnection.Open();
                _databaseConnection.BeginTransaction();

                //Xử lý update dữ liệu số lượng bán
                int numberUpdate = _databaseConnection.Execute(query, commandType: CommandType.Text);
                if (numberUpdate == 0)
                {
                    return false;
                }
                _databaseConnection.CommitTransaction();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _databaseConnection.RollbackTransaction();
                _databaseConnection.Close();
                throw new MExceptionResponse(ex.Message);
            }
        }

    }
}
