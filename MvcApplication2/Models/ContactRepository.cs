using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MvcApplication2.Models
{
    public class ContactRepository : IRepository
    {
        public readonly string _baseURL = ConfigurationManager.AppSettings["APIBaseURL"].ToString();
        public async Task<IEnumerable<ContactModel>> GetContacts()
        {
            List<ContactModel> ContactInfo = new List<ContactModel>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage Response = await client.GetAsync("api/contact");

                //Checking the response is successful or not which is sent using HttpClient
                if (Response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ContactResponse = Response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ContactInfo = JsonConvert.DeserializeObject<List<ContactModel>>(ContactResponse);
                }

                return ContactInfo;
            }
        }

        public async Task<ContactModel> GetContact(int contact_id)
        {
            ContactModel ContactInfo = new ContactModel();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage Response = await client.GetAsync("api/contact/" + contact_id);

                //Checking the response is successful or not which is sent using HttpClient
                if (Response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ContactResponse = Response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    ContactInfo = JsonConvert.DeserializeObject<ContactModel>(ContactResponse);
                }

                return ContactInfo;
            }
        }

        public bool SaveContact(ContactModel contact)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseURL);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ContactModel>("api/contact", contact);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool UpdateContact(int Contact_Id, ContactModel contact)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseURL);

                //HTTP POST
                var putTask = client.PutAsJsonAsync<ContactModel>("api/contact/" + Contact_Id, contact);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteContact(int Contact_Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseURL);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("api/contact/"+Contact_Id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
