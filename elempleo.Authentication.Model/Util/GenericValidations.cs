namespace elempleo.Authentication.Model.Util
{
	public static class GenericValidations
	{
		public static bool OwnData<T>(IEnumerable<T> listaItemsValidacion)
		{
			return listaItemsValidacion?.Any() ?? false;
		}
	}
}
