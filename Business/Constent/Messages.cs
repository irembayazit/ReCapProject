using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constent
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarAddInvalid = "Gecersiz deger.Araba eklenemedi!";
        public static string BrandNameInvalid = "Marka adı gecersiz";
        public static string MaintenanceTime = "Sistem bakimda";
        public static string CarListed = "Arabalar listelendi";
        public static string CarDeleted = "Araba bilgileri silindi";
        public static string CarUpdated = "Araba bilgileri güncellendi";
        public static string CustomerAdded = "Müşteri bilgileri eklendi";
        public static string CustomerDelete = "Müşteri bilgileri silindi";
        public static string CustomerUpdate = "Müşteri bilgileri güncellendi";
        public static string RentalNotAdd = "Kiralama işlemi eklenemedi.Müşteri bilgilerini eklediğinizden emin olunuz!";
        public static string RentalAdd = "Kiralama blgileri eklendi.";
        public static string RentalDelete = "Kiralama blgileri silindi.";
        public static string RentalUpdate = "Kiralama blgileri güncellendi.";
        public static string UserAdd = "Kullanıcı blgileri eklendi.";
        public static string UserDelete = "Kullanıcı blgileri silindi.";
        public static string UserUpdate = "Kullanıcı blgileri güncellendi.";
        public static string FailAddedImageLimit = "Daha fazla resim yüklenemez!";
        public static string ImagesAdded = "resim eklendi";
        public static string CarIdNotFound = "kayıtlı id bulunamadı";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok!";
        public static string BrandListed = "markalar listelendi";
        public static string ColorListed = "renkler listeendi";
        public static string CustomerListed = "müşteriler listelendi";
        public static string RentalListed = "kiralık araç bilgileri listelendi";
        public static string BradndIdNotFound = "ilgili id bulunamadı";
        public static string GetErrorCarMessage = "Araç bilgisi / bilgileri getirilemedi.";
        public static string GetSuccessCarMessage = "Araç bilgisi / bilgileri getirildi.";
    }
}
