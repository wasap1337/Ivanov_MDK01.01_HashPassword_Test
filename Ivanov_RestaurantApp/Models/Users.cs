namespace RestaurantModel
{
    public partial class Users
    {
        public int IdUser { get; set; }
        public string LoginUser { get; set; }
        public string PasswordHash { get; set; }
        public int IdRole { get; set; }

        public virtual Roles Roles { get; set; }
    }
}
