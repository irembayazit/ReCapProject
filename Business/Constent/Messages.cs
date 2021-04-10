using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constent
{
    public static class Messages
    {
        public static string ColorAdded = "Color added";
        public static string ColorListed = "Colors listed";
        public static string ColorUpdated = "Color information updated";

        public static string BrandAdded = "Brand added";
        public static string BrandNameInvalid = "Brand name is invalid";
        public static string BrandListed = "Brands listed";
        public static string BradndIdNotFound = "The corresponding id could not be found";

        public static string CarAdded = "Car  added";
        public static string CarAddInvalid = "Invalid value.The car could not be added!";
        public static string CarListed = "Cars listed";
        public static string CarDeleted = "Car information deleted";
        public static string CarUpdated = "Car information updated";
        public static string CarIdNotFound = "The corresponding id could not be found";
        public static string GetErrorCarMessage = "Vehicle information / information could not be listed";
        public static string GetSuccessCarMessage = "Listed vehicle information / information";

        public static string MaintenanceTime = "System is under maintenance";
        
        public static string CustomerAdded = "Customer information added";
        public static string CustomerDelete = "Customer information deleted";
        public static string CustomerUpdate = "Customer information updated";
        public static string CustomerListed = "Customer information listed";

        public static string RentalNotAdd = "Could not add rental transaction.Make sure to add customer information!";
        public static string RentalAdd = "Rental information added";
        public static string RentalDelete = "Rental information deleted";
        public static string RentalUpdate = "Rental information updated";
        public static string RentalListed = "Rental information listed";
        public static string NotRental = "Cannot be rented between these dates";

        public static string UserAdd = "User information added";
        public static string UserDelete = "User information deleted";
        public static string UserUpdate = "User information updated";
        public static string UserRegistered = "Registration successful";
        public static string UserNotFound = "User not found";
        public static string UserAlreadyExists = "User available";
        public static string UserDetailsUpdated = "Your information has been updated";

        public static string FailAddedImageLimit = "No more images can be uploaded!";
        public static string ImagesAdded = "Picture added";

        public static string PasswordError = "Password error";
        public static string SuccessfulLogin = "Successful login";
        public static string AccessTokenCreated = "Token created";
        public static string AuthorizationDenied = "You have no authorization!";
        public static string NotFindex = "Findex points insufficient";
        public static string NotPassword = "Passwords do not match";

        public static string CreditCardAdded = "Credit card added";
        public static string CreditCardDeleted = "Credit card deleted";
        public static string CreditCardUpdated = "Credit card updated";
        public static string CreditCardControl = "Registered credit cards listed";
        public static string CreditCardControlNot = "No credit card registered";

    }
}
