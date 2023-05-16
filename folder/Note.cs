
using System;
using Postgrest.Models;
namespace folder
{
   
    [Postgrest.Attributes.Table("notes")]
    public class Note : BaseModel
    {
       
        public Note() { }

        [Postgrest.Attributes.PrimaryKey("id")]
        public int Id { get; set; }

        [Postgrest.Attributes.Column("user_id")]
        public Guid UserId { get; set; }

        [Postgrest.Attributes.Column("title")]
        public string Title { get; set; } = "";

        [Postgrest.Attributes.Column("content")]
        public string Content { get; set; } = "";

        [Postgrest.Attributes.Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Postgrest.Attributes.Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        
    }

}



   