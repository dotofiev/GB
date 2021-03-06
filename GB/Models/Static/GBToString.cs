﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GB.Models.Static
{
    public static class GBToString
    {
        public static string Oui_Non(bool donnee)
        {
            return
                donnee ? App_Lang.Lang.Yes
                       : App_Lang.Lang.No;
        }

        public static string Activer_Desactiver(bool donnee)
        {
            return
                donnee ? App_Lang.Lang.Activated
                       : App_Lang.Lang.Disabled;
        }

        public static string Statut_iCheck(bool donnee)
        {
            return
                donnee ? "check"
                       : "uncheck";
        }

        public static string MontantToString(object value)
        {
            return
                Convert.ToDecimal(value)
                .ToString(
                    "C",
                    new NumberFormatInfo()
                    {
                        CurrencyGroupSeparator = " ",
                        CurrencySymbol = string.Empty,
                        CurrencyDecimalDigits = 0
                        //CurrencyPositivePattern = 3,
                        //CurrencyNegativePattern = 8
                    }
                );
        }

        public static string PeriodiciteDePret(string donnee)
        {
            return
                donnee == "MOIS" ? App_Lang.Lang.Month
                                 : donnee == "TRIMESTRE" ? App_Lang.Lang.Quarter
                                                         : donnee == "ANNEE" ? App_Lang.Lang.Year
                                                                             : string.Empty;
        }

        public static string TypeClassificationProvisionsPret(string donnee)
        {
            return
                donnee == "CAUTIONED" ? App_Lang.Lang.Cautioned
                                      : donnee == "MORTGAGE" ? App_Lang.Lang.Mortgage
                                                             : string.Empty;
        }

        public static string TypeCompteAgence(string donnee)
        {
            return
                donnee == "TIERS" ? "Tiers"
                                  : donnee == "FONDS" ? App_Lang.Lang.Funds
                                                      : donnee == "COMPENSATION" ? App_Lang.Lang.Clearing
                                                                                 : donnee == "NONMEMBER" ? App_Lang.Lang.Non_member
                                                                                                         : string.Empty;
        }

        public static string TypeProfitabilite(string donnee)
        {
            return
                donnee == "PROFITABILITY" ? App_Lang.Lang.Profitability
                                          : donnee == "EXPENSE" ? App_Lang.Lang.Expense
                                                                : donnee == "INSURANCE" ? App_Lang.Lang.Insurance
                                                                                        : string.Empty;
        }

        public static string TypeSociete(string donnee)
        {
            return
                donnee == "Machine Number" ? App_Lang.Lang.Machine_number
                                          : donnee == "Customer Account Number" ? App_Lang.Lang.Customer_account_number
                                                                                : string.Empty;
        }

        public static string BaseCalculSociete(string donnee)
        {
            return
                donnee == "SOLDE" ? "SOLDE"
                                  : donnee == "SALARY" ? App_Lang.Lang.Salary
                                                       : string.Empty;
        }

        public static string FormuleClassificationProvisionsPret(string donnee)
        {
            return
                donnee == "BETWEEN" ? App_Lang.Lang.Between
                                      : donnee == "GREATER THAN" ? App_Lang.Lang.Greater_than
                                                                 : string.Empty;
        }

        public static string NatureTypeGarantie(string donnee)
        {
            return
                donnee == "GarantieEtat" ? App_Lang.Lang.State_guarantee
                                         : donnee == "SureteReelle" ? App_Lang.Lang.Real_safety
                                                                    : string.Empty;
        }

        public static string NatureCompte(string donnee)
        {
            return
                donnee == "Credit" ? App_Lang.Lang.Credit
                                   : donnee == "Debit" ? App_Lang.Lang.Debit
                                                       : donnee == "Both" ? App_Lang.Lang.Both
                                                                           : App_Lang.Lang.Not_required;
        }

        public static string StatutCompte(string donnee)
        {
            return
                donnee == "Close" ? App_Lang.Lang.Close
                                  : donnee == "Open" ? App_Lang.Lang.Open
                                                     : App_Lang.Lang.Not_required;
        }
    }
}