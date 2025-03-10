namespace elempleo.Authentication.Model.Dto
{
    public class UserDto
    {
		public int Id { get; set; }
		public string FullName { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public int IdRol { get; set; }
		public RolDto Rol { get; set; }
	}
}
