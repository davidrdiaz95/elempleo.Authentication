namespace elempleo.Authentication.Repository.Entity.Base
{
    public class Entity
    {
		public int Id { get; set; }
		public DateTime DateCreate { get; set; }
		public int? IdUserUpdate { get; set; }
		public DateTime? DateUpdate { get; set; }
	}
}
