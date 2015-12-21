/*
 * Created by SharpDevelop.
 * User: vladimir.kruglov
 * Date: 21.12.2015
 * Time: 11:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace test
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window, INotifyPropertyChanged
	{
		private int _selectedIndex;
		private ObservableCollection<string> _files = new ObservableCollection<string>();
		public Window1()
		{
			InitializeComponent();
			
			var thread = new Thread(timer_Tick);
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.Lowest;
            thread.Start();
            
            Files.Add("1");
            Files.Add("1");
            Files.Add("1");
            Files.Add("1");
            Files.Add("1");

			
		}
		
		
		void timer_Tick()
        {
            while (true)
            {

                try
            {
                WebRequest request = WebRequest.Create("localhost:1234");
                request.Headers.Add("Authorization", "1234");
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var stream = new StreamReader(response.GetResponseStream());
                    var responceStr = stream.ReadToEnd();
                    stream.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
                Thread.Sleep(500);
            }
        }
		
		public ObservableCollection<string> Files
        {
            get { return _files; }
            set
            {
                if (Equals(value, _files)) return;
                _files = value;
                OnPropertyChanged("Files");
            }
        }
		 public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (value == _selectedIndex) return;
                _selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }
		 
		 public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
		void Button_ClickUp(object sender, RoutedEventArgs e)
		{
			SelectedIndex--;
		}
		void Button_ClickDown(object sender, RoutedEventArgs e)
		{
			SelectedIndex++;
		}
	}
}