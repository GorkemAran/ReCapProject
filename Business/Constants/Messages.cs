using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi.";
        public static string CantAdded = "Araç adı iki karakterden fazla olmalı ya da günlük fiyat sıfırdan fazla olmalı";
        public static string CarListed = "Araçlar listelendi.";
        public static string CarUpdated = "Araç güncellendi.";
        public static string CarDeleted = "Araç silindi.";

        public static string BrandAdded = "Marka eklendi.";
        public static string BrandListed = "Markalar listelendi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandDeleted = "Marka silindi.";

        public static string ColorAdded = "Renk eklendi.";
        public static string ColorListed = "Renkler listelendi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorDeleted = "Renk silindi.";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";

        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerAdded = "Müşteri eklendi";

        public static string RentalUpdated = "Kiralama bilgisi güncellendi.";
        public static string RentalAdded = "Kiralama bilgisi eklendi.";
        public static string RentalDeleted = "Kiralama bilgisi silindi.";
        public static string RentalFail = "Kiralama başarısız.";

        public static string AddedImage = "Resim eklendi.";
        public static string DeletedImage = "Resim silindi.";
        public static string UpdatedImage = "Resim güncellendi.";
        public static string CarImageLimitExceeded = "Resim limitine ulaşıldı !";

        public static string AuthorizationDenied = "Doğrulama başarısız !";
    }
}
