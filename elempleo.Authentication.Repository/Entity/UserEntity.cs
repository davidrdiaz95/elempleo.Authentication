namespace elempleo.Authentication.Repository.Entity
{
    public class UserEntity : Base.Entity
	{
		public string FullName { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public bool IsActive { get; set; }
		public int IdRol { get; set; }
		public RolUserEntity Rol { get; set; }
	}
}
