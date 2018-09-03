using GB.Models.BO;
using GB.Models.DAO;
using GB.Models.Entites;
using GB.Models.Helper;
using GB.Models.Interfaces;
using GB.Models.Static;
using GB.Models.Tests;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace GB.Models.BO
{
    public class Parametre : BOClass, IBO<GeneralPara>
    {
        public int nombre_ligne_historique_compte { get; set; }
        public bool utilisation_chequier { get; set; }
        public int nombre_jour_avant_apuration_credit { get; set; }
        public int periode_dormante { get; set; }
        public int periode_litige { get; set; }
        public bool utilisation_version_centrale { get; set; }
        public int periode_de_non_paiement { get; set; }
        public bool controler_le_nombre_de_pret { get; set; }
        public bool controler_le_nombre_de_comptes { get; set; }
        public bool tva { get; set; }
        public bool controler_session { get; set; }
        public int duree_session { get; set; }
        public bool sms_banking { get; set; }
        public int nombre_de_jour_ouverture_back_date { get; set; }
        public string methode_de_post_interet_reserver { get; set; }
        public bool utilisation_litige_methode_cobac { get; set; }
        public bool modifier_les_attributs_client_dans_la_branch { get; set; }
        public bool conter_le_nombre_de_page_dans_historique { get; set; }
        public bool mise_a_jour_position_client { get; set; }
        public bool poster_credit { get; set; }
        public bool poster_litige_pret { get; set; }
        public bool poster_collection_locale { get; set; }
        public bool western_union { get; set; }
        public bool poster_bon_de_caisse_et_depot_a_terme { get; set; }
        public string methode_de_sauvegarde { get; set; }
        public string lien_sauvegarde_numero_1 { get; set; }
        public string lien_sauvegarde_numero_2 { get; set; }
        public string id_utilisateur_createur { get; set; }
        public Utilisateur utilisateur { get; set; }
        public string mot_de_passe { get; set; }
        public long date_creation { get; set; }
        public double? stmt_page_count { get; set; }
        public string collection_post { get; set; }
        public string lending_post { get; set; }
        public string check_book_verif { get; set; }
        public int? no_payment_periode { get; set; }
        public string use_compte_attente { get; set; }
        public string type_attente { get; set; }
        public int? day_contentieux { get; set; }
        public string use_loan_contentious { get; set; }
        public string new_config_photo { get; set; }
        public string cobac_lit_method { get; set; }
        public string deposit_post { get; set; }
        public string tarif_data_west { get; set; }
        public int? day_write_off { get; set; }
        public string nb_loan { get; set; }
        public int? delay_time { get; set; }
        public string use_session { get; set; }
        public double? day_back_date { get; set; }
        public string vat { get; set; }
        public string count_account { get; set; }
        public string ccul { get; set; }

        public Parametre(string id)
        {
            this.id = id;
        }

        public Parametre(GeneralPara entitie)
        {
            try
            {
                this.id = entitie.SerieNum.ToString();
                this.code = entitie.SerieNum.ToString();
                this.methode_de_sauvegarde = entitie.Backupmethod;
                this.id_utilisateur_createur = entitie.Employe;
                this.utilisateur = new UtilisateurDAO().ObjectCode(this.id_utilisateur_createur);
                this.mot_de_passe = entitie.Modspatt;
                this.stmt_page_count = entitie.STMTPageCount;
                this.count_account = entitie.countaccount;
                this.vat = entitie.Vat;
                this.day_back_date = entitie.DayBackDate;
                this.use_session = entitie.usesession;
                this.delay_time = entitie.DelayTime;
                this.nb_loan = entitie.NbLoan;
                this.utilisation_version_centrale = entitie.centralversion == "Yes";
                this.day_write_off = entitie.DayWriteoff;
                this.lien_sauvegarde_numero_1 = entitie.Pathfirstbackup;
                this.lien_sauvegarde_numero_2 = entitie.Pathlastbackup;
                this.tarif_data_west = entitie.TrfDataWest;
                this.conter_le_nombre_de_page_dans_historique = entitie.PageCount == "Yes";
                this.deposit_post = entitie.DepositPost;
                this.cobac_lit_method = entitie.CobacLitMethod;
                this.new_config_photo = entitie.NewConfigPhoto;
                this.use_loan_contentious = entitie.UseLoanContentious;
                this.day_contentieux = entitie.DayContentieux;
                this.type_attente = entitie.TypeAttente;
                this.use_compte_attente = entitie.UseCpteAttente;
                this.sms_banking = entitie.smsbnk == "Yes";
                this.no_payment_periode = entitie.Nopymentperiode;
                this.periode_dormante = entitie.Dormantperiode ?? 0;
                this.check_book_verif = entitie.CheckBookVerif;
                this.mise_a_jour_position_client = entitie.UpdatePosition == "Yes";
                this.lending_post = entitie.LendingPost;
                this.collection_post = entitie.CollectionPost;
                this.date_creation = entitie.DateCreation?.Ticks ?? DateTime.Now.Ticks;
                this.ccul = entitie.ccul;
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        public Parametre() { }

        public void Crer_Id()
        {
            this.id = (Program.db.parametres.Count + 1).ToString();
        }

        public GeneralPara ToEntities(Dictionary<string, object> parametres = null)
        {
            GeneralPara entitie = new GeneralPara();

            entitie.Backupmethod = this.methode_de_sauvegarde;
            entitie.ccul = this.ccul;
            entitie.CheckBookVerif = this.check_book_verif;
            entitie.CobacLitMethod = this.cobac_lit_method;
            entitie.SerieNum = int.Parse(this.code);
            entitie.CollectionPost = this.collection_post;
            entitie.PageCount = this.conter_le_nombre_de_page_dans_historique ? "Yes"
                                                                              : "No";
            entitie.centralversion = this.utilisation_version_centrale ? "Yes"
                                                                       : "No";
            entitie.countaccount = this.count_account;
            entitie.DayBackDate = this.day_back_date;
            entitie.DayContentieux = this.day_contentieux;
            entitie.DayWriteoff = this.day_write_off;
            entitie.DelayTime = this.delay_time;
            entitie.DepositPost = this.deposit_post;
            entitie.Dormantperiode = this.periode_dormante;
            entitie.Employe = this.id_utilisateur_createur;
            entitie.LendingPost = this.lending_post;
            entitie.Modspatt = this.mot_de_passe;
            entitie.NbLoan = this.nb_loan;
            entitie.NewConfigPhoto = this.new_config_photo;
            entitie.Nopymentperiode = this.no_payment_periode;
            entitie.Pathfirstbackup = this.lien_sauvegarde_numero_1;
            entitie.Pathlastbackup = this.lien_sauvegarde_numero_2;
            entitie.SerieNum = int.Parse(this.id);
            entitie.smsbnk = this.sms_banking ? "Yes"
                                              : "No";
            entitie.STMTPageCount = this.stmt_page_count;
            entitie.TrfDataWest = this.tarif_data_west;
            entitie.TypeAttente = this.type_attente;
            entitie.UpdatePosition = this.mise_a_jour_position_client ? "Yes"
                                                                      : "No";
            entitie.UseCpteAttente = this.use_compte_attente;
            entitie.UseLoanContentious = this.use_loan_contentious;
            entitie.usesession = this.use_session;
            entitie.Vat = this.vat;

            return entitie;
        }

        public void FromEntities(GeneralPara entitie)
        {
            try
            {
                this.id = entitie.SerieNum.ToString();
                this.code = entitie.SerieNum.ToString();
                this.methode_de_sauvegarde = entitie.Backupmethod;
                this.id_utilisateur_createur = entitie.Employe;
                this.utilisateur = new UtilisateurDAO().ObjectCode(this.id_utilisateur_createur);
                this.mot_de_passe = entitie.Modspatt;
                this.stmt_page_count = entitie.STMTPageCount;
                this.count_account = entitie.countaccount;
                this.vat = entitie.Vat;
                this.day_back_date = entitie.DayBackDate;
                this.use_session = entitie.usesession;
                this.delay_time = entitie.DelayTime;
                this.nb_loan = entitie.NbLoan;
                this.utilisation_version_centrale = entitie.centralversion == "Yes";
                this.day_write_off = entitie.DayWriteoff;
                this.lien_sauvegarde_numero_1 = entitie.Pathfirstbackup;
                this.lien_sauvegarde_numero_2 = entitie.Pathlastbackup;
                this.tarif_data_west = entitie.TrfDataWest;
                this.conter_le_nombre_de_page_dans_historique = entitie.PageCount == "Yes";
                this.deposit_post = entitie.DepositPost;
                this.cobac_lit_method = entitie.CobacLitMethod;
                this.new_config_photo = entitie.NewConfigPhoto;
                this.use_loan_contentious = entitie.UseLoanContentious;
                this.day_contentieux = entitie.DayContentieux;
                this.type_attente = entitie.TypeAttente;
                this.use_compte_attente = entitie.UseCpteAttente;
                this.sms_banking = entitie.smsbnk == "Yes";
                this.no_payment_periode = entitie.Nopymentperiode;
                this.periode_dormante = entitie.Dormantperiode ?? 0;
                this.check_book_verif = entitie.CheckBookVerif;
                this.mise_a_jour_position_client = entitie.UpdatePosition == "Yes";
                this.lending_post = entitie.LendingPost;
                this.collection_post = entitie.CollectionPost;
                this.stmt_page_count = entitie.STMTPageCount;
                this.date_creation = entitie.DateCreation?.Ticks ?? DateTime.Now.Ticks;
            }
            catch (Exception ex)
            {
                // -- Log -- //
                GBClass.Log.Error(ex);
            }
        }

        public void ModifyEntities(GeneralPara entitie)
        {
            entitie.Backupmethod = this.methode_de_sauvegarde;
            entitie.ccul = this.ccul;
            entitie.CheckBookVerif = this.check_book_verif;
            entitie.CobacLitMethod = this.cobac_lit_method;
            entitie.SerieNum = int.Parse(this.code);
            entitie.CollectionPost = this.collection_post;
            entitie.PageCount = this.conter_le_nombre_de_page_dans_historique ? "Yes"
                                                                              : "No";
            entitie.centralversion = this.utilisation_version_centrale ? "Yes"
                                                                       : "No";
            entitie.countaccount = this.count_account;
            entitie.DayBackDate = this.day_back_date;
            entitie.DayContentieux = this.day_contentieux;
            entitie.DayWriteoff = this.day_write_off;
            entitie.DelayTime = this.delay_time;
            entitie.DepositPost = this.deposit_post;
            entitie.Dormantperiode = this.periode_dormante;
            entitie.Employe = this.id_utilisateur_createur;
            entitie.LendingPost = this.lending_post;
            entitie.Modspatt = this.mot_de_passe;
            entitie.NbLoan = this.nb_loan;
            entitie.NewConfigPhoto = this.new_config_photo;
            entitie.Nopymentperiode = this.no_payment_periode;
            entitie.Pathfirstbackup = this.lien_sauvegarde_numero_1;
            entitie.Pathlastbackup = this.lien_sauvegarde_numero_2;
            entitie.SerieNum = int.Parse(this.id);
            entitie.smsbnk = this.sms_banking ? "Yes"
                                              : "No";
            entitie.STMTPageCount = this.stmt_page_count;
            entitie.TrfDataWest = this.tarif_data_west;
            entitie.TypeAttente = this.type_attente;
            entitie.UpdatePosition = this.mise_a_jour_position_client ? "Yes"
                                                                      : "No";
            entitie.UseCpteAttente = this.use_compte_attente;
            entitie.UseLoanContentious = this.use_loan_contentious;
            entitie.usesession = this.use_session;
            entitie.Vat = this.vat;

            // -- Non autorisé -- //
            //entitie.DateCreation = new DateTime(this.date_creation);
        }

        public override bool Equals(object obj)
        {
            return
                this.id == (obj as Parametre).id &&
                this.code == (obj as Parametre).code;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}