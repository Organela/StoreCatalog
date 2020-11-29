namespace Storage.Catalog.Domain.Entities
{
    public class Administrator
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsLogged { get; set; }
    }
}
