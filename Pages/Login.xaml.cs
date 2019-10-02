using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PetShop.Utinity;
using Windows.System;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PetShop.Functions;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PetShop.Pages
{   /*
            * httpContent là interface, StringContent là con của httpContent có thể triển khai
            * Giống nhau về tên trường và trùng kiểu dữ liệu
            */
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }
        private const string API_URI = "https://2-dot-backup-server-003.appspot.com/_api/v2/members/authentication";

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //Tạo đối tượng member login từ giá trị của form
            var memberlogin = new MemberLogin
            {
                //email = this.Email.Text,
                //password = this.Password.Password
                email = "123@gmail.com",
                password = "123"
            };
            //validate
            //Send request
            StringContent dataContent = new StringContent(JsonConvert.SerializeObject(memberlogin), System.Text.Encoding.UTF8, mediaType: "application/json");
            HttpClient httpClient = new HttpClient();
            
            //Get response
            var responeContent = httpClient.PostAsync(API_URI, dataContent).Result.Content.ReadAsStringAsync().Result;

            //Parse Json Object to get token
            JObject jsonObject = JObject.Parse(responeContent);
            string token = jsonObject["token"].ToString();
            //var resMember = JsonConvert.DeserializeObject<MemRegister>(responeContent);
            
            //Write token to file
            IOFile ioFile = new IOFile();
            ioFile.CreateFile();
            ioFile.WriteToFile(token);

            //Navigate to MyInfo Page
            this.Frame.Navigate(typeof(MyInformation));

            //Navigate with token parameter
            //this.Frame.Navigate(typeof(MyInformation), token);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            this.Email.Text =string.Empty;
            this.Password.Password = string.Empty;
        }
    }
}
