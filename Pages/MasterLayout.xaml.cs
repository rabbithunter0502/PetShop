using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PetShop.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MasterLayout : Page
    {
        //Khởi tạo đối tượng Page và chèn thời gian
        DispatcherTimer Timer = new DispatcherTimer();
        public MasterLayout()
        {
            this.InitializeComponent();
            DataContext = this;
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }
        private void Timer_Tick(object sender, object e)
        {
            Time.Text = DateTime.Now.ToString("h:mm:ss tt");
        }
        
        //private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        //{

        //    HyperlinkButton hyperlink = sender as HyperlinkButton;
        //    if(hyperlink != null)
        //    {
        //        switch (hyperlink.Tag)
        //        {
        //            case "Login":
        //                this.MainContent.Navigate(typeof(Login));
        //                break;
        //            case "Register":
        //                this.MainContent.Navigate(typeof(Register));
        //                break;
        //            case "Myinfo":
        //                this.MainContent.Navigate(typeof(MyInformation));
        //                break;

        //        }
        //    };
        //}



        private void Navigation_Loaded(object sender, RoutedEventArgs e)
        {
           Navigation.IsPaneOpen = false;
            foreach (NavigationViewItemBase item in Navigation.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "Nav_Home")
                {
                    Navigation.SelectedItem = item;
                    break;
                }
            }
            
            MainContent.Navigate(typeof(WelCome));
            /*
             * add thêm sepatator cho view qua đối tượng của code behind
             * Thêm vào vị trí cuối cùng
             */
            //var navSeperator = new NavigationViewItemSeparator();
            //Navigation.MenuItems.Add(navSeperator);
            //Navigation.MenuItems.Add( new NavigationViewItem
            //{
            //    Content = "My content",
            //    Icon = new SymbolIcon((Symbol)0xF1AD),
            //    Tag = "content"
            //});
        }

        private void Navigation_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            
        }

        private void Navigation_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                MainContent.Navigate(typeof(Settings));
            }
            else
            {
                var item = args.InvokedItemContainer as NavigationViewItem;
                if (item != null)
                {
                    switch (item.Tag)
                    {
                        case "Nav_Home":
                            MainContent.Navigate(typeof(WelCome));
                            break;

                        case "Nav_Login":
                            MainContent.Navigate(typeof(Login));
                            break;

                        case "Nav_Register":
                            MainContent.Navigate(typeof(Register));
                            break;

                        case "Nav_Myinfo":
                            MainContent.Navigate(typeof(MyInformation));
                            break;
                        case "Nav_FileHandle":
                            MainContent.Navigate(typeof(CaptureHandle));
                            break;
                    }
                }
            }
            
        }

       
       
        private void Navigation_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (MainContent.CanGoBack)
            {
                MainContent.GoBack();
            }
        }

        private void NavigationViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {

        }
    }
}
