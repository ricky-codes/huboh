//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Huboh.EntityFramework.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FilePaths
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FilePaths()
        {
            this.Songs = new HashSet<Songs>();
        }
    
        public int filePathID { get; set; }
        public string fileFilename { get; set; }
        public string fileDirectory { get; set; }
        public string fileFullpath { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Songs> Songs { get; set; }
    }
}