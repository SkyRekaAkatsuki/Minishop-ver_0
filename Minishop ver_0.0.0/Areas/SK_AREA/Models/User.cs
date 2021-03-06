//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.BrowseHistories = new HashSet<BrowseHistory>();
            this.MyFavorites = new HashSet<MyFavorite>();
            this.Questions = new HashSet<Question>();
            this.Carts = new HashSet<Cart>();
            this.OrderHeaders = new HashSet<OrderHeader>();
        }
    
        public int UserID { get; set; }
        public string UserName { get; set; }
        public byte[] UserPassword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string GUID { get; set; }
        public string VerificationCode { get; set; }
        public bool Gender { get; set; }
        public int RegionID { get; set; }
        public string Address { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public string TaxID { get; set; }
        public bool Admin { get; set; }
        public Nullable<int> PhotoID { get; set; }
        public bool Enabled { get; set; }
        public string OauthType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BrowseHistory> BrowseHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MyFavorite> MyFavorites { get; set; }
        public virtual Photo Photo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }
        public virtual Region Region { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderHeader> OrderHeaders { get; set; }
    }
}
