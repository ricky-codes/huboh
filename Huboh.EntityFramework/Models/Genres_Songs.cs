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
    
    public partial class Genres_Songs
    {
        public int genres_songsID { get; set; }
        public Nullable<int> genreID { get; set; }
        public Nullable<int> songID { get; set; }
    
        public virtual Genres Genres { get; set; }
        public virtual Songs Songs { get; set; }
    }
}
