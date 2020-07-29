using System;
namespace Services.ViewModels
{
    public class OrderInfo
    {
        /// <summary>
        /// Merchant OrderId
        /// </summary>
        public decimal OrderId { get; set; }
        /// <summary>
        /// Payment amount
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// VNPAY Transaction Id
        /// </summary>
        public decimal vnp_TransactionNo { get; set; }
        public string vpn_Message { get; set; }
        public string vpn_TxnResponseCode { get; set; }
    }
}
