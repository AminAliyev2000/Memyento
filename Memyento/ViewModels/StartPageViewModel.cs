using Memyento.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Memyento.ViewModels
{
    public class StartPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _index;
        public StartPageViewModel()
        {
            SaveCommand = new RelayCommand(SaveClick);
            PreviousStateCommand = new RelayCommand(PreviousClick);
            NextStateCommand = new RelayCommand(NextClick);

        }
        private string _currentMessage;
        public string CurrentMessage
        {
            get { return _currentMessage; }
            set { _currentMessage = value; OnPropertyChanged(); }
        }
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ObservableCollection<string> Messages { get; set; } = new ObservableCollection<string>();
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand PreviousStateCommand { get; set; }
        public RelayCommand NextStateCommand { get; set; }
        private void SaveClick(object parameter = null)
        {
            if (string.IsNullOrWhiteSpace(CurrentMessage) == false)
            {
                int count = Messages.Count;
                if (count > 0 && Messages[count - 1] == CurrentMessage)
                {
                    return;
                }
                ObservableCollection<string> temp = new ObservableCollection<string>();
                for (int i = 0; i < count; i++)
                {
                    if (CurrentMessage.Contains(Messages[i]) == false)
                    {
                        break;
                    }
                    temp.Add(Messages[i]);
                }
                temp.Add(CurrentMessage);
                Messages = temp;
                _index = Messages.Count;
               
                MessageBox.Show("Your text saved succesfully...");
            }
        }
        private void PreviousClick(object parameter = null)
        {
            if (_index - 1 >= 0)
            {
                _index = _index - 1;
                CurrentMessage = Messages[_index];
                (parameter as TextBox).SelectionStart = CurrentMessage.Length;
            }
            MessageBox.Show("Your text changed to the previous saved memento..");
        }
        private void NextClick(object parameter = null)
        {
            if (_index + 1 < Messages.Count)
            {
                _index = _index + 1;
                CurrentMessage = Messages[_index];
                (parameter as TextBox).SelectionStart = CurrentMessage.Length;
            }
            MessageBox.Show("Your text changed to the next saved memento..");
        }
        
       
    }
}
