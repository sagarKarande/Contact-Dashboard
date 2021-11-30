using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Authentication : IAuthentication
    {
        AuthDBEntities _context = new AuthDBEntities();
        public bool Login(UserModel user)
        {
            bool IsValidUser = false;
            try
            {
                string encode = Authentication.base64Encode(user.Password);
                IsValidUser = _context.Users
                  .Any(u => u.Username.ToLower() == user
                  .Username.ToLower() && u.Password == encode);

            }
            catch (Exception ex)
            {

            }

            return IsValidUser;
        }

        public bool register(User user)
        {
            try
            {
                user.Password = Authentication.base64Encode(user.Password);
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

            }
            return false;
        }


        public static string base64Encode(string sData) // Encode    
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }


        public static string base64Decode(string sData) //Decode    
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }

        public bool CheckUserExist(string userName)
        {
            return (_context.Users.Any(x => x.Username == userName));
        }
    }
}