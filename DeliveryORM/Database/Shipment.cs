using System;

namespace AuctionSystem.ORM
{
    public class Shipment
    {
        public int Id{ get; set; }
        public string Type{ get; set; }
        public double Price{ get; set; }
        public double DeliveryPrice{ get; set; }
        public double Weight { get; set; }
        public string OrderTime { get; set; }
        public string DeliveryTime { get; set; }
        public int IsConfirmed { get; set; }
        public int CustomerId { get; set; }
        public int SellerStorageId { get; set; }
        public int ReceiveStorageId { get; set; }
        public Person Person { get; set; }
        public int? Delay { get; set; }
        public string Delivered { get; set; }
        public string DoneAt { get; set; }
        public string SellerStorage { get; set; }
        public string ReceiveStorage { get; set; }
        public string SellerStorageStreet { get; set; }
        public string SellerStorageCity { get; set; }
        public string ReceiveStorageStreet { get; set; }
        public string ReceiveStorageCity { get; set; }
        public string State { get; set; }


        public Shipment() { }


    }

}