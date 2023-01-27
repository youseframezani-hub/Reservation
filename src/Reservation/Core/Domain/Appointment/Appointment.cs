using Domain.Schedule;
using Domain.Service;
using Domain.Supplier;

namespace Domain.Appointment;

internal class Appointment
{
    public GuidId Id { get; set; }
    public List<GuidId> ServiceIds { get; set; }//Choosing at least 1 service 
    public GuidId Supplier { get; set; }//(required)
    public GuidId CustomerId { get; set; }//(optional)
    public DateTime Date { get; set; }//(required)
    public TimeSpan Time { get; set; }//(required)
    public DurationTime Interval { get; set; }//(required)
    public AppointmentStatus Status { get; set; }//(required)
    public string Note { get; set; }
    public DateTime BookingTime { get; set; }
    public DateTime TimeBeforeReschedule { get; set; }
    public string BookedBy { get; set; }
    public string CanceledBy { get; set; }
    public Currency cost { get; set; }
    public int quantity { get; set; }
    public bool IsApproved { get; set; }
    public bool IsCancelled { get; set; }
    public bool IsFailed { get; set; }
    public bool IsRecurring { get; set; }
    public bool IsRescheduled { get; set; }
    public void Cancel()
    {
        ////            [
        ////  {
        ////                "id": 55195098,
        ////    "orderId": 48021980,
        ////    "staffId": 532470,
        ////    "staffName": "yousef ",
        ////    "serviceId": 919926,
        ////    "serviceName": "rish",
        ////    "serviceColor": "#0099BC",
        ////    "customerId": 13650072,
        ////    "customerFirstName": "yousef",
        ////    "customerLastName": "ramezani",
        ////    "customerUserName": "youseframezani68@gmail.com",
        ////    "customerProfileImage": "",
        ////    "customerContact": {
        ////                    "cell": "9192335843",
        ////      "home": "",
        ////      "work": ""
        ////    },
        ////    "customerTimezone": "Tehran (GMT +03:30)",
        ////    "customerAddress": "yaftabad , Adana, Adana Turkey",
        ////    "customerMood": 0,
        ////    "isCustomerFBPageFan": false,
        ////    "customerRemark": "",
        ////    "customerLastAppointmentStatus": "",
        ////    "inviteeCustomerId": 0,
        ////    "appointmentStartTime": "2023-01-05T20:20:00",
        ////    "appointmentEndTime": "2023-01-05T20:40:00",
        ////    "appointmentBookingTime": "2023-01-05T17:28:00",
        ////    "lastActivityDateTime": "2023-01-05T17:27:30.883",
        ////    "appointmentTimeBeforeReschedule": "1970-01-01T00:00:00",
        ////    "customForm": [],
        ////    "note": "",
        ////    "arrivalStatus": 1,
        ////    "cost": 350.0000,
        ////    "quantity": 1,
        ////    "discountCode": "",
        ////    "discountAmount": 0.00,
        ////    "discountDescription": "",
        ////    "offerAmount": 0.00,
        ////    "isOfferGiven": false,
        ////    "isOfferApplied": false,
        ////    "offerDescription": "",
        ////    "offerIn": 0,
        ////    "isPromoted": false,
        ////    "promotionType": "",
        ////    "giftCertificateName": "",
        ////    "giftCertificateAmount": 0.0,
        ////    "isApproved": true,
        ////    "isCancelled": false,
        ////    "isFailed": false,
        ////    "isPaid": false,
        ////    "isRecurring": false,
        ////    "isRescheduled": false,
        ////    "isShowFaliedBooking": true,
        ////    "paymentModeId": 0,
        ////    "isPaymentNotificationValid": false,
        ////    "isAskedForReview": false,
        ////    "isReviewGiven": false,
        ////    "bookedByWhom": 0,
        ////    "platform": "",
        ////    "integration": "",
        ////    "referenceName": "Admin",
        ////    "referenceId": 1,
        ////    "resourceName": null,
        ////    "resourceId": 0,
        ////    "amountPaid": 0.0000,
        ////    "eventId": ""
        ////  }
        ////]
    }
    public void Reschedule(DateTime date, TimeSpan time)
    {
        //{
        //  "orderId": 48021980,
        //  "discount": 0.00,
        //  "extraCharges": 0.00,
        //  "amountPaid": 0.0,
        //  "addOn": [],
        //  "addOnAmount": 0.0000,
        //  "note": "zxczxc",
        //  "appointments": [
        //    {
        //      "id": 55195098,
        //      "serviceId": 919926,
        //      "serviceName": "rish",
        //      "staffId": 532470,
        //      "staffName": "yousef ",
        //      "customerId": 13650072,
        //      "startTime": "2023-01-05T20:25:00",
        //      "endTime": "2023-01-05T20:41:00",
        //      "cost": 350.0000,
        //      "customField": [],
        //      "discountCode": "",
        //      "discountAmount": 0.00,
        //      "discountDescription": "",
        //      "isRecurring": false,
        //      "quantity": 1,
        //      "addOn": [],
        //      "addOnAmount": 0.0000,
        //      "staff": {
        //        "id": 532470,
        //        "name": "yousef ",
        //        "email": "youseframezani68@gmail.com",
        //        "emailVerified": false,
        //        "description": "",
        //        "mobile": "",
        //        "profilePicture": null,
        //        "userName": "",
        //        "priority": 1,
        //        "isLoginEnable": false,
        //        "isManager": true,
        //        "isDisable": false,
        //        "hasReportedAbuse": false,
        //        "isHiddenFromAdmin": false,
        //        "assignedService": [],
        //        "performs": null,
        //        "defaultCalendarView": "DAY"
        //      },
        //      "service": {
        //        "id": 919926,
        //        "title": "rish",
        //        "description": "",
        //        "durationInMinutes": 20,
        //        "price": 350.0000,
        //        "capacity": 1,
        //        "priority": 1,
        //        "color": "#0099BC",
        //        "category": {
        //          "id": 392649,
        //          "name": "Default Category",
        //          "priority": 0
        //        },
        //        "isDisable": false,
        //        "isHiddenFromAdmin": false,
        //        "slotType": 1,
        //        "slotValue": "",
        //        "dependentServiceIds": [],
        //        "image": {
        //          "cover": null,
        //          "gallery": []
        //        },
        //        "performedBy": null
        //      },
        //      "appointmentStatus": {
        //        "id": 7292,
        //        "status": "test",
        //        "isCustom": false
        //      },
        //      "isCancelled": false,
        //      "isApproved": true,
        //      "isPaid": false,
        //      "isFailed": false,
        //      "resourceId": 0,
        //      "resourceName": "",
        //      "history": [
        //        {
        //          "activity": "rescheduled",
        //          "activityTime": "2023-01-05T19:47:07.3233365+00:00",
        //          "role": "admin",
        //          "name": "yousef ",
        //          "email": "youseframezani68@gmail.com",
        //          "username": "yousef68",
        //          "meta": {
        //            "id": "532470",
        //            "name": "yousef ",
        //            "appointmentTime": "01/05/2023 20:25:00"
        //          }
        //        },
        //        {
        //          "activity": "rescheduled",
        //          "activityTime": "2023-01-05T19:41:32.2883042+00:00",
        //          "role": "admin",
        //          "name": "yousef ",
        //          "email": "youseframezani68@gmail.com",
        //          "username": "yousef68",
        //          "meta": {
        //            "id": "532470",
        //            "name": "yousef ",
        //            "appointmentTime": "01/05/2023 20:20:00"
        //          }
        //        },
        //        {
        //          "activity": "status",
        //          "activityTime": "2023-01-05T19:30:59.2318035+00:00",
        //          "role": "admin",
        //          "name": "yousef ",
        //          "email": "youseframezani68@gmail.com",
        //          "username": "yousef68",
        //          "meta": {
        //            "id": "2",
        //            "status": "As Scheduled"
        //          }
        //        },
        //        {
        //          "activity": "status",
        //          "activityTime": "2023-01-05T19:29:14.3928118+00:00",
        //          "role": "admin",
        //          "name": "yousef ",
        //          "email": "youseframezani68@gmail.com",
        //          "username": "yousef68",
        //          "meta": {
        //            "id": "1",
        //            "status": "Set Status"
        //          }
        //        },
        //        {
        //          "activity": "booked",
        //          "activityTime": "2023-01-05T17:27:30.882734+00:00",
        //          "role": "admin",
        //          "name": "yousef ",
        //          "email": "youseframezani68@gmail.com",
        //          "username": "yousef68",
        //          "meta": null
        //        }
        //      ]
        //    }
        //  ],
        //  "customerId": 0,
        //  "customer": {
        //    "id": 13650072,
        //    "firstName": "yousef",
        //    "lastName": "ramezani",
        //    "userName": "youseframezani68@gmail.com",
        //    "password": null,
        //    "profilePicture": "",
        //    "address": {
        //      "address1": "yaftabad ",
        //      "city": {
        //        "id": 18140,
        //        "name": "Adana"
        //      },
        //      "state": {
        //        "id": 4192,
        //        "name": "Adana"
        //      },
        //      "country": {
        //        "id": 246,
        //        "name": "Turkey",
        //        "callingCode": 0
        //      },
        //      "zipCode": "",
        //      "latitude": null,
        //      "longitude": null
        //    },
        //    "timezone": {
        //      "id": 70,
        //      "name": "Asia/Tehran",
        //      "description": "Tehran (GMT +03:30)",
        //      "timezoneOffset": 210,
        //      "windowsTimeZoneId": "Iran Standard Time"
        //    },
        //    "contactNumber": {
        //      "cell": "9192335843",
        //      "home": "",
        //      "work": ""
        //    },
        //    "registrationDate": "2021-12-16T15:43:00",
        //    "source": "Created By Admin",
        //    "refference": "ADMIN",
        //    "registeredUsing": "ADMIN",
        //    "isEmailVerified": true,
        //    "isMobileVerified": false,
        //    "isHomeVerified": false,
        //    "isWorkVerified": false,
        //    "profile": {
        //      "note": "",
        //      "totalAppointments": 4,
        //      "lastAppointmentDate": "2023-01-05T20:20:00",
        //      "userTag": "",
        //      "mood": "NOTSET",
        //      "isDiscounted": false,
        //      "isSocial": false,
        //      "isFBPageFan": false,
        //      "isRestricted": false
        //    }
        //  },
        //  "hasPaymentHistory": false
        //}
    }
    public void EditAppointmentInterval(DurationTime interval)
    {
        //    {
        //  "orderId": 48025109,
        //  "discount": 0.00,
        //  "extraCharges": 0.00,
        //  "amountPaid": 0.0,
        //  "addOn": [],
        //  "addOnAmount": 0.0000,
        //  "note": "",
        //  "appointments": [
        //    {
        //      "id": 55198836,
        //      "serviceId": 919926,
        //      "serviceName": "rish",
        //      "staffId": 532470,
        //      "staffName": "yousef ",
        //      "customerId": 1,
        //      "startTime": "2023-01-05T20:35:00",
        //      "endTime": "2023-01-05T20:55:00",
        //      "cost": 350.0000,
        //      "customField": [],
        //      "discountCode": "",
        //      "discountAmount": 0.00,
        //      "discountDescription": "",
        //      "isRecurring": false,
        //      "quantity": 1,
        //      "addOn": [],
        //      "addOnAmount": 0.0000,
        //      "staff": {
        //        "id": 532470,
        //        "name": "yousef ",
        //        "email": "youseframezani68@gmail.com",
        //        "emailVerified": false,
        //        "description": "",
        //        "mobile": "",
        //        "profilePicture": null,
        //        "userName": "",
        //        "priority": 1,
        //        "isLoginEnable": false,
        //        "isManager": true,
        //        "isDisable": false,
        //        "hasReportedAbuse": false,
        //        "isHiddenFromAdmin": false,
        //        "assignedService": [],
        //        "performs": null,
        //        "defaultCalendarView": "DAY"
        //      },
        //      "service": {
        //        "id": 919926,
        //        "title": "rish",
        //        "description": "",
        //        "durationInMinutes": 20,
        //        "price": 350.0000,
        //        "capacity": 1,
        //        "priority": 1,
        //        "color": "#0099BC",
        //        "category": {
        //          "id": 392649,
        //          "name": "Default Category",
        //          "priority": 0
        //        },
        //        "isDisable": false,
        //        "isHiddenFromAdmin": false,
        //        "slotType": 1,
        //        "slotValue": "",
        //        "dependentServiceIds": [],
        //        "image": {
        //          "cover": null,
        //          "gallery": []
        //        },
        //        "performedBy": null
        //      },
        //      "appointmentStatus": {
        //        "id": 2,
        //        "status": "As Scheduled",
        //        "isCustom": false
        //      },
        //      "isCancelled": false,
        //      "isApproved": true,
        //      "isPaid": false,
        //      "isFailed": false,
        //      "resourceId": 0,
        //      "resourceName": "",
        //      "history": [
        //        {
        //          "activity": "status",
        //          "activityTime": "2023-01-05T20:08:47.4213752+00:00",
        //          "role": "admin",
        //          "name": "yousef ",
        //          "email": "youseframezani68@gmail.com",
        //          "username": "yousef68",
        //          "meta": {
        //            "id": "1",
        //            "status": "Set Status"
        //          }
        //        },
        //        {
        //          "activity": "booked",
        //          "activityTime": "2023-01-05T20:06:10.0095646+00:00",
        //          "role": "admin",
        //          "name": "yousef ",
        //          "email": "youseframezani68@gmail.com",
        //          "username": "yousef68",
        //          "meta": null
        //        }
        //      ]
        //    },
        //    {
        //      "id": 55198837,
        //      "serviceId": 919925,
        //      "serviceName": "Hair Cut",
        //      "staffId": 532470,
        //      "staffName": "yousef ",
        //      "customerId": 1,
        //      "startTime": "2023-01-05T21:05:00",
        //      "endTime": "2023-01-05T22:05:00",
        //      "cost": 1000.0000,
        //      "customField": [],
        //      "discountCode": "",
        //      "discountAmount": 0.00,
        //      "discountDescription": "",
        //      "isRecurring": false,
        //      "quantity": 1,
        //      "addOn": [],
        //      "addOnAmount": 0.0000,
        //      "staff": {
        //        "id": 532470,
        //        "name": "yousef ",
        //        "email": "youseframezani68@gmail.com",
        //        "emailVerified": false,
        //        "description": "",
        //        "mobile": "",
        //        "profilePicture": null,
        //        "userName": "",
        //        "priority": 1,
        //        "isLoginEnable": false,
        //        "isManager": true,
        //        "isDisable": false,
        //        "hasReportedAbuse": false,
        //        "isHiddenFromAdmin": false,
        //        "assignedService": [],
        //        "performs": null,
        //        "defaultCalendarView": "DAY"
        //      },
        //      "service": {
        //        "id": 919925,
        //        "title": "Hair Cut",
        //        "description": "sajhd asld haslkdhaskjdhadhakdjha dlhsa <br />asd asda dasdjhak<br />asdasdasd<br />asdasdsadasd asahs dahsdkjahd ",
        //        "durationInMinutes": 60,
        //        "price": 1000.0000,
        //        "capacity": 1,
        //        "priority": 2,
        //        "color": "#0063B1",
        //        "category": {
        //          "id": 392649,
        //          "name": "Default Category",
        //          "priority": 0
        //        },
        //        "isDisable": false,
        //        "isHiddenFromAdmin": false,
        //        "slotType": 1,
        //        "slotValue": "",
        //        "dependentServiceIds": [],
        //        "image": {
        //          "cover": null,
        //          "gallery": []
        //        },
        //        "performedBy": null
        //      },
        //      "appointmentStatus": {
        //        "id": 2,
        //        "status": "As Scheduled",
        //        "isCustom": false
        //      },
        //      "isCancelled": false,
        //      "isApproved": true,
        //      "isPaid": false,
        //      "isFailed": false,
        //      "resourceId": 0,
        //      "resourceName": "",
        //      "history": [
        //        {
        //          "activity": "rescheduled",
        //          "activityTime": "2023-01-05T20:10:18.6841349+00:00",
        //          "role": "admin",
        //          "name": "yousef ",
        //          "email": "youseframezani68@gmail.com",
        //          "username": "yousef68",
        //          "meta": {
        //            "id": "532470",
        //            "name": "yousef ",
        //            "appointmentTime": "01/05/2023 20:55:00"
        //          }
        //        },
        //        {
        //          "activity": "booked",
        //          "activityTime": "2023-01-05T20:06:10.0095646+00:00",
        //          "role": "admin",
        //          "name": "yousef ",
        //          "email": "youseframezani68@gmail.com",
        //          "username": "yousef68",
        //          "meta": null
        //        }
        //      ]
        //    }
        //  ],
        //  "customerId": 0,
        //  "customer": {
        //    "id": 1,
        //    "firstName": "Unknown",
        //    "lastName": "User",
        //    "userName": "UnKnown",
        //    "password": null,
        //    "profilePicture": "https://www.gravatar.com/avatar/ad921d60486366258809553a3db49a4a?d=https%3a%2f%2fwww.appointy.com%2fImages%2fnoImagelarge.jpg&s=200",
        //    "address": {
        //      "address1": "",
        //      "city": {
        //        "id": 42629,
        //        "name": "No City"
        //      },
        //      "state": {
        //        "id": 5656,
        //        "name": "No Region"
        //      },
        //      "country": {
        //        "id": 254,
        //        "name": "United States",
        //        "callingCode": 0
        //      },
        //      "zipCode": "",
        //      "latitude": null,
        //      "longitude": null
        //    },
        //    "timezone": {
        //      "id": 70,
        //      "name": "Asia/Tehran",
        //      "description": "Tehran (GMT +03:30)",
        //      "timezoneOffset": 210,
        //      "windowsTimeZoneId": "Iran Standard Time"
        //    },
        //    "contactNumber": {
        //      "cell": "",
        //      "home": "",
        //      "work": ""
        //    },
        //    "registrationDate": "2008-05-18T00:00:00",
        //    "source": "Self Registered",
        //    "refference": "SELF",
        //    "registeredUsing": "SELF",
        //    "isEmailVerified": true,
        //    "isMobileVerified": false,
        //    "isHomeVerified": false,
        //    "isWorkVerified": false,
        //    "profile": {
        //      "note": "",
        //      "totalAppointments": 3,
        //      "lastAppointmentDate": "2023-01-05T20:55:00",
        //      "userTag": "",
        //      "mood": "NOTSET",
        //      "isDiscounted": false,
        //      "isSocial": false,
        //      "isFBPageFan": false,
        //      "isRestricted": false
        //    }
        //  },
        //  "hasPaymentHistory": false
        //}
    }
}

class AppointmentStatus
{
    public int id { get; set; }
    public string status { get; set; }
    public bool isCustom { get; set; }
}
