using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace EntregarAdventureWorksMVCEntityFrameworks.Models
{
    [ModelMetadataType(typeof(SalesOrderHeaderMetadata))]
    public partial class SalesOrderHeader { }
    public class SalesOrderHeaderMetadata
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 100000)]
        public int SalesOrderId { get; set; }

        /// <summary>
        /// Incremental number to track changes to the sales order over time.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 10)]
        public byte RevisionNumber { get; set; }

        /// <summary>
        /// Dates the sales order was created.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Date the order is due to the customer.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Date the order was shipped to the customer.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        public DateTime? ShipDate { get; set; }

        /// <summary>
        /// Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0,10)]
        public byte Status { get; set; }

        /// <summary>
        /// 0 = Order placed by sales person. 1 = Order placed online by customer.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0,1)]
        public bool OnlineOrderFlag { get; set; }

        /// <summary>
        /// Unique sales order identification number.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [MinLength((4))]
        [MaxLength(10)]
        public string SalesOrderNumber { get; set; } = null!;

        /// <summary>
        /// Customer purchase order number reference. 
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [MinLength((5))]
        [MaxLength(20)]
        public string? PurchaseOrderNumber { get; set; }

        /// <summary>
        /// Financial accounting number reference.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [MinLength((5))]
        [MaxLength(20)]
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Customer identification number. Foreign key to Customer.BusinessEntityID.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0,90000)]
        public int CustomerId { get; set; }

        /// <summary>
        /// Sales person who created the sales order. Foreign key to SalesPerson.BusinessEntityID.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 1000)]
        public int? SalesPersonId { get; set; }

        /// <summary>
        /// Territory in which the sale was made. Foreign key to SalesTerritory.SalesTerritoryID.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 20)]
        public int? TerritoryId { get; set; }

        /// <summary>
        /// Customer billing address. Foreign key to Address.AddressID.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        public int BillToAddressId { get; set; }

        /// <summary>
        /// Customer shipping address. Foreign key to Address.AddressID.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 50000)]
        public int ShipToAddressId { get; set; }

        /// <summary>
        /// Shipping method. Foreign key to ShipMethod.ShipMethodID.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0,10)]
        public int ShipMethodId { get; set; }

        /// <summary>
        /// Credit card identification number. Foreign key to CreditCard.CreditCardID.
        /// </summary>
        [Range(0, 50000)]
        public int? CreditCardId { get; set; }

        /// <summary>
        /// Approval code provided by the credit card company.
        /// </summary>
        [MaxLength(30)]
        public string? CreditCardApprovalCode { get; set; }

        /// <summary>
        /// Currency exchange rate used. Foreign key to CurrencyRate.CurrencyRateID.
        /// </summary>
        [Range(0, 20000)]
        public int? CurrencyRateId { get; set; }

        /// <summary>
        /// Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.
        /// </summary>
        [Range(0, 20000)]
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Tax amount.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 2000000)]
        public decimal TaxAmt { get; set; }

        /// <summary>
        /// Shipping cost.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 100000)]
        public decimal Freight { get; set; }

        /// <summary>
        /// Total due from customer. Computed as Subtotal + TaxAmt + Freight.
        /// </summary>
        [Microsoft.Build.Framework.Required]
        [Range(0, 2000000)]
        public decimal TotalDue { get; set; }

        /// <summary>
        /// Sales representative comments.
        /// </summary>
        [MaxLength(1100)]
        public string? Comment { get; set; }

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

    }
}
