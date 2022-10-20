using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Decarator
{

    public partial class MainWindow : Window
    {
        interface IService
        {
            string GetServiceType();
        }

        class Facebook : IService
        {
            public string GetServiceType()
            {
                return " Hello ";
            }
        }

        class Service : IService
        {
            private IService _service;

            public Service(IService service)
            {
                _service = service;
            }

            public virtual string GetServiceType()
            {
                return _service.GetServiceType();
            }
        }

        class FacebookDecarator : Service
        {
            public FacebookDecarator(IService service) : base(service)
            {
            }

            public override string GetServiceType()
            {
                string type = base.GetServiceType();
                type += " Facebook";
                return type;
            }
        }

        class InstagramDecarator : Service
        {
            public InstagramDecarator(IService service) : base(service)
            {

            }

            public override string GetServiceType()
            {
                string type = base.GetServiceType();
                type += " Instagram";
                return type;
            }
        }

        class TwitterDecarator : Service
        {
            public TwitterDecarator(IService service) : base(service)
            {
            }

            public override string GetServiceType()
            {
                string type = base.GetServiceType();
                type += " Twitter";
                return type;
            }
        }

        class SmsDecarator : Service
        {
            public SmsDecarator(IService service) : base(service)
            {
            }

            public override string GetServiceType()
            {
                string type = base.GetServiceType();
                type += " Sms";
                return type;
            }
        }
        public MainWindow()
        {
            InitializeComponent();


            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IService service = new Facebook();
            listBox.Text = String.Empty;
            foreach (var item in canvas.Children)
            {
                if (item is CheckBox ch)
                {
                    if (ch.IsChecked==true&&ch.Name=="facebookCh")
                    {
                        IService facebook = new FacebookDecarator(service);
                        listBox.Text += facebook.GetServiceType();
                    }
                    else if (ch.IsChecked == true && ch.Name == "instagramCh")
                    {
                        IService instagram = new InstagramDecarator(service);
                        listBox.Text += instagram.GetServiceType();
                    }
                    else if (ch.IsChecked == true && ch.Name == "smsCh")
                    {
                        IService sms = new SmsDecarator(service);
                        listBox.Text +=   sms.GetServiceType();
                    }
                    else if (ch.IsChecked == true && ch.Name == "twitterCh")
                    {
                        IService twitter = new TwitterDecarator(service);
                        listBox.Text +=  twitter.GetServiceType();
                    }

                }
            }
        }
    }
}
