using EntregarAdventureWorksMVCEntityFrameworks.Models;
using System.ComponentModel.DataAnnotations;

namespace EntregarAdventureWorksMVCEntityFrameworks.ViewModel
{
    public class SalesOrderDetailProductJoinViewModel
    {
        [Microsoft.Build.Framework.Required]
        [MinLength(2)]
        [MaxLength(45)]
        public string Name { get; set; } = null!;

        [MaxLength(10)]
        public string? Color { get; set; }

        [Microsoft.Build.Framework.Required]
        [Range(1, 100000)]
        public int SalesOrderId { get; set; }

        /// <summary>
        /// Primary key. One incremental unique number per product sold.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(1, 100000)]
        public int SalesOrderDetailId { get; set; }

        /// <summary>
        /// Shipment tracking number supplied by the shipper.
        /// </summary>
        [MaxLength(20)]
        public string? CarrierTrackingNumber { get; set; }

        /// <summary>
        /// Quantity ordered per product.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 9)]
        public short OrderQty { get; set; }

        /// <summary>
        /// Product sold to customer. Foreign key to Product.ProductID.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 1000)]
        public int ProductId { get; set; }

        /// <summary>
        /// Promotional code. Foreign key to SpecialOffer.SpecialOfferID.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 9)]
        public int SpecialOfferId { get; set; }

        /// <summary>
        /// Selling price of a single product.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 1000000)]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Discount amount.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 1000000)]
        public decimal UnitPriceDiscount { get; set; }

        /// <summary>
        /// Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 1000000000)]
        public decimal LineTotal { get; set; }

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [MaxLength(100)]
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        public DateTime ModifiedDate { get; set; }
        [Microsoft.Build.Framework.Required]
        public virtual SalesOrderHeader SalesOrder { get; set; } = null!;
    }
}
