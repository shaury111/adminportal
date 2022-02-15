using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class PaymentMode
{
    public static int PaymentModes_Debit_Card = 1;
    public static int PaymentModes_Credit_Card = 2;
    public static int PaymentModes_Netbanking = 3;
    public static int PaymentModes_NEFT_RTGS = 4;
    public static int PaymentModes_CashOnDelivery = 5;
    public static int PaymentModes_Wallet = 6;
    public static int PaymentModes_GiftCard = 7;
    public static int PaymentModes_DigitalPayment = 8;

    public static int Payment_Full = 1;
    public static int Payment_Partial = 2;
    public static int Payment_Zero = 3;

    public enum PaymentModes
    {
        Debit_Card = 1,
        Credit_Card = 2,
        Netbanking = 3,
        NEFT_RTGS = 4,
        CashOnDelivery = 5,
        Wallet = 6,
        GiftCard = 7,
        DigitalPayment = 8
    }

    public enum PaymentModes_Getway
    {
        netbanking = 1,
        card = 2,        
        credit = 3,
        debit = 4,
        wallet = 5,
        upi = 6,
        emi = 7
    }

    public enum Payment
    {
        Full = 1,
        Partial = 2,
        Zero = 3
    }
}