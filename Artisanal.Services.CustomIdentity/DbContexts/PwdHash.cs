using System.Security.Cryptography;
using System.Text;

namespace Artisanal.Services.CustomIdentity.DbContexts{
    public class PwdHash {
        public string ComputeHash(string password){
            var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var strHash = Encoding.UTF8.GetString(hash,0,hash.Length);
            return strHash;
        } 
        public bool Verify(string password , string hash){
            var strHash = ComputeHash(password) ;
            return strHash == hash;
        }
    }    
}
