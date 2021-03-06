//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GB.Models.Entites
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientBnk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientBnk()
        {
            this.CpteClts = new HashSet<CpteClt>();
            this.TABMEMBERBENEFs = new HashSet<TABMEMBERBENEF>();
        }
    
        public string Agence { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public string Adresse3 { get; set; }
        public string BP { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string TypeResident { get; set; }
        public string AgentEco { get; set; }
        public string ActiviteEco { get; set; }
        public string NatClient { get; set; }
        public string LibNatClient { get; set; }
        public string NatJuridique { get; set; }
        public string Qualite { get; set; }
        public string Titre { get; set; }
        public string TypeClient { get; set; }
        public string CatClient { get; set; }
        public string LibAgence { get; set; }
        public Nullable<System.DateTime> DateNaissance { get; set; }
        public string LieuNaissance { get; set; }
        public string CNIPass { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }
        public string Telex { get; set; }
        public string Fax { get; set; }
        public Nullable<short> Groupe { get; set; }
        public string Nationalite { get; set; }
        public string NatBeac { get; set; }
        public string NomJeuneFille { get; set; }
        public string Sigle { get; set; }
        public string RaisonSociale { get; set; }
        public string SiegeSocial { get; set; }
        public string RegistreCce { get; set; }
        public string NomAbrege { get; set; }
        public string NumContrib { get; set; }
        public Nullable<System.DateTime> DateCreatSoc { get; set; }
        public string ObjetSocial { get; set; }
        public string LibNatBeac { get; set; }
        public string LibAgentEco { get; set; }
        public string LibActiviteEco { get; set; }
        public string LibNatJuridique { get; set; }
        public string LibVille { get; set; }
        public string LibTitre { get; set; }
        public string LibNationalite { get; set; }
        public string LibSiegeSocial { get; set; }
        public string PrecisNais { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
        public string NomJumelle { get; set; }
        public string Employe { get; set; }
        public string Nomemploye { get; set; }
        public string Profession { get; set; }
        public Nullable<System.DateTime> deathdate { get; set; }
        public Nullable<System.DateTime> Adhesiondate { get; set; }
        public Nullable<System.DateTime> datedeclaration { get; set; }
        public Nullable<System.DateTime> DateTransfert { get; set; }
        public string integritystatus { get; set; }
        public string CustRelCode { get; set; }
        public string CustRelName { get; set; }
        public string client { get; set; }
        public string gestionnaire { get; set; }
        public string email { get; set; }
        public string EbnkSub { get; set; }
        public Nullable<System.DateTime> DteIssueCNI { get; set; }
        public string PlaceIssueCNI { get; set; }
        public string CustomerRemark { get; set; }
        public string ANCIENMATRICULE { get; set; }
        public string COMPANYGRPE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CpteClt> CpteClts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TABMEMBERBENEF> TABMEMBERBENEFs { get; set; }
    }
}
