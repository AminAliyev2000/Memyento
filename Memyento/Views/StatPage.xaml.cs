using Memyento.ViewModels;
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
using System.Windows.Shapes;

namespace Memyento.Views
{
    /// <summary>
    /// Interaction logic for StatPage.xaml
    /// </summary>
    public partial class StatPage : Window
    {
        public StatPage()
        {
            InitializeComponent();
            TxtBxMessage.Focus();
            this.DataContext = new StartPageViewModel();
        }
    }
}
