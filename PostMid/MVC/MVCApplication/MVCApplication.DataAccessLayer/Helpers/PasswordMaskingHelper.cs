using MVCApplication.DataAccessLayer.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MVCApplication.DataAccessLayer.Helpers
{
    internal class PasswordMaskingHelper
    {
        public string Mask(string input)
        {
            try
            {
                var engine = SHA256.Create();
                var buffer = input.Select(x => (byte)x).ToArray();
                var hash = engine.ComputeHash(buffer);
                var result = string.Join(string.Empty, hash.Select(x => (char)x));
                return result;
            }
            catch(Exception e)
            {
                throw ExceptionManager.Manage(e);
            }
        }
    }
}
