using Postgrest.Models;

namespace folder
{
    [Postgrest.Attributes.Table("users")]
    public class Users : BaseModel
    {
        [Postgrest.Attributes.PrimaryKey("id")]
        public string id { get; set; }

        [Postgrest.Attributes.Column("username")]
        public string username { get; set; } = "";

    }
}
