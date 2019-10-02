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
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

using System.Text;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PetShop.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        private const string API_URI = "https://2-dot-backup-server-003.appspot.com/_api/v2/members";
        public Register()
        {
            this.InitializeComponent();
            
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            var memRegister = new MemRegister
            {
                passWord = this.password.Password,
                firstName = this.firstName.Text,
                lastName = this.lastName.Text,
                avatar = this.avatar.Text,
                phone = this.phone.Text,
                address = this.address.Text,
                introduction = this.introdution.Text,
                gender = this.gender.Text,
                birthday = this.birthday.Text,
                email = this.email.Text,
                password = this.password.Password
                //passWord = "123",
                //firstName = "123",
                //lastName = "123",
                //avatar = "123",
                //phone = "123",
                //address = "123",
                //introduction = "123",
                //gender = "123",
                //birthday = "2000-10-20",
                //email = "Duc@gmail.com",
                //password = "123",
            };
            //Debug.WriteLine(JsonConvert.SerializeObject(memRegister));
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic ");
            //var httpClient = new HttpClient();
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(memRegister), Encoding.UTF8, mediaType: "application/json"); // chi seriable 1 lan
            //Debug.WriteLine(httpClient.PostAsync(API_URI, httpContent).Result.Content.ReadAsStringAsync().Result);//ReadAsStringAsync() cho ket qua tra ve khi tat ca bat dong bo hoan thanh
            String responeContent = httpClient.PostAsync(API_URI, httpContent).Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine(message: "Respone :" + responeContent);
            MemRegister resMember = JsonConvert.DeserializeObject<MemRegister>(responeContent);
            Debug.WriteLine(resMember.email);

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            gender.Text = rb.Content.ToString();  
        }
    }
}
