using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;

namespace EntregarAdventureWorksMVCEntityFrameworks.Models
{
    [ModelMetadataType(typeof(ProductMetadata))]
    public partial class Product { }
    public class ProductMetadata
    {
        /// <summary>
        /// Primary key for Product records.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 5000)]
        public int ProductId { get; set; }

        /// <summary>
        /// Name of the product.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [MinLength(2)]
        [MaxLength(45)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Unique product identification number.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [MinLength(6)]
        [MaxLength(15)]
        public string ProductNumber { get; set; } = null!;

        /// <summary>
        /// 0 = Product is purchased, 1 = Product is manufactured in-house.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 1)]
        public bool MakeFlag { get; set; }

        /// <summary>
        /// 0 = Product is not a salable item. 1 = Product is salable.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 1)]
        public bool FinishedGoodsFlag { get; set; }

        /// <summary>
        /// Product color.
        /// </summary>
        [MaxLength(10)]
        public string? Color { get; set; }

        /// <summary>
        /// Minimum inventory quantity. 
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 20000)]
        public short SafetyStockLevel { get; set; }

        /// <summary>
        /// Inventory level that triggers a purchase order or work order. 
        /// </summary>
        [Range(0,1000)]
        [Microsoft.Build.Framework.Required]
        public short ReorderPoint { get; set; }

        /// <summary>
        /// Standard cost of the product.
        /// </summary>
        
        [Microsoft.Build.Framework.Required]
        [Range(0,1000000)]
        public decimal StandardCost { get; set; }

        /// <summary>
        /// Selling price.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 1000000)]
        public decimal ListPrice { get; set; }

        /// <summary>
        /// Product size.
        /// </summary>
        [MaxLength(15)]
        public string? Size { get; set; }

        /// <summary>
        /// Unit of measure for Size column.
        /// </summary>
        [MaxLength(10)]
        public string? SizeUnitMeasureCode { get; set; }

        /// <summary>
        /// Unit of measure for Weight column.
        /// </summary>
        [MaxLength(15)]
        public string? WeightUnitMeasureCode { get; set; }

        /// <summary>
        /// Product weight.
        /// </summary>
        [Range(0, 1000000)]
        public decimal? Weight { get; set; }

        /// <summary>
        /// Number of days required to manufacture the product.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 1000)]
        public int DaysToManufacture { get; set; }

        /// <summary>
        /// R = Road, M = Mountain, T = Touring, S = Standard
        /// </summary>
        [MaxLength(15)]
        public string? ProductLine { get; set; }

        /// <summary>
        /// H = High, M = Medium, L = Low
        /// </summary
        [MaxLength(15)]
        public string? Class { get; set; }

        /// <summary>
        /// W = Womens, M = Mens, U = Universal
        /// </summary>
        [MaxLength(15)]
        public string? Style { get; set; }

        /// <summary>
        /// Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. 
        /// </summary>
        [Range(0,1000000)]
        public int? ProductSubcategoryId { get; set; }

        /// <summary>
        /// Product is a member of this product model. Foreign key to ProductModel.ProductModelID.
        /// </summary>
        [Range(0, 1000000)]
        public int? ProductModelId { get; set; }

        /// <summary>
        /// Date the product was available for sale.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        public DateTime SellStartDate { get; set; }

        /// <summary>
        /// Date the product was no longer available for sale.
        /// </summary>
        public DateTime? SellEndDate { get; set; }

        /// <summary>
        /// Date the product was discontinued.
        /// </summary>
        public DateTime? DiscontinuedDate { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        public DateTime ModifiedDate { get; set; }
    }
}
