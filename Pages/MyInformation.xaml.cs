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
using PetShop.Functions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PetShop.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyInformation : Page
    {
        private const string API_URI = "https://2-dot-backup-server-003.appspot.com/_api/v2/members/information";
        
        
        public MyInformation()
        {
            this.InitializeComponent();
        }
        /*
         * Note : get "token" value from Login.xaml.cs throught override method OnNavigateTO()
         * private string token ;
         * protected override void OnNavigatedTo(NavigationEventArgs e)
         *  {
         *      base.OnNavigatedTo(e);

         *      token = e.Parameter.ToString();

         *   }
         *   Asyn phải có await
         */

        private void GetInfo_Click(object sender, RoutedEventArgs e)
        {
            //Read token from file
            IOFile ioFile = new IOFile();
            string tiktok = ioFile.ReadAFile();

            //Create new request and add token to header of request
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + tiktok); 
           
            //Send the GET request
            String Response =  httpClient.GetAsync(API_URI).Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine(Response);

            //Deserialize Json to get Info
            MemRegister mem = JsonConvert.DeserializeObject<MemRegister>(Response);
            this.address.Text = mem.address;
            this.firstName.Text = mem.firstName;
            this.lastName.Text = mem.lastName ;
            this.avatar.Text = mem.avatar;
            this.phone.Text = mem.phone;
            this.address.Text = mem.address;
            this.introdution.Text = mem.introduction;
            this.gender.Text = mem.gender;
            this.birthday.Text = mem.birthday;
            this.email.Text = mem.email; 
        }

        private void EditInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
