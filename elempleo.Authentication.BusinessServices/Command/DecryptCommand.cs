using elempleo.Authentication.Model.Section;
using elempleo.Authentication.Services.Command;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace elempleo.Authentication.BusinessServices.Command
{
	public class DecryptCommand : IDecryptCommand
	{
		private readonly EncryptSection options;

		public DecryptCommand(IOptions<EncryptSection> options)
		{
			this.options = options.Value;
		}

		public async Task<string> Execute(string cipherText)
		{
			cipherText = cipherText.Replace(" ", "+");
			byte[] cipherBytes = Convert.FromBase64String(cipherText);
			using (Aes encryptor = Aes.Create())
			{
				var pdb = new Rfc2898DeriveBytes(this.options.Key, this.options.Ive, 10000, HashAlgorithmName.SHA256);
				encryptor.Key = pdb.GetBytes(32);
				encryptor.IV = pdb.GetBytes(16);
				using (MemoryStream ms = new MemoryStream())
				{
					using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
					{
						cs.Write(cipherBytes, 0, cipherBytes.Length);
						cs.Close();
					}
					cipherText = Encoding.Unicode.GetString(ms.ToArray());
				}
			}
			return cipherText;
		}
	}
}
