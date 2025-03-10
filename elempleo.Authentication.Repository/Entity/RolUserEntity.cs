namespace elempleo.Authentication.Repository.Entity
{
    public class RolUserEntity : Base.Entity
	{
		public string Name { get; set; }
		public IEnumerable<UserEntity> Users { get; set; }
	}
}
