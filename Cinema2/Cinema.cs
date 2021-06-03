using Cinema2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cinema2
{
    public class Cinema : INotifyPropertyChanged
    {
        private ObservableCollection<User> _hall100, _hall100_2, _hall15, _hall15_2, _hall15_3;
        public ObservableCollection<User> Hall_1 => _hall100;
        public ObservableCollection<User> Hall_2 => _hall100_2;
        public ObservableCollection<User> Hall_3 => _hall15;
        public ObservableCollection<User> Hall_4 => _hall15_2;
        public ObservableCollection<User> Hall_5 => _hall15_3;
        public Cinema()
        {
            _hall100 = new ObservableCollection<User>();
            _hall100_2 = new ObservableCollection<User>();
            _hall15 = new ObservableCollection<User>();
            _hall15_2 = new ObservableCollection<User>();
            _hall15_3 = new ObservableCollection<User>();
        }
        public void AddUser(User u)
        {
            UpdateHalls();
            if (_hall100.Count < 100) { _hall100.Add(u); return; }
            else if (_hall100_2.Count < 100) { _hall100_2.Add(u); return; }
            else if (_hall15.Count < 15) { _hall15.Add(u); return; }
            else if (_hall15_2.Count < 15) { _hall15_2.Add(u); return; }
            else if (_hall15_3.Count < 15) { _hall15_3.Add(u); return; }
            if (_hall100.Count == 100 && _hall100_2.Count == 100 && _hall15.Count == 15 && _hall15_2.Count == 15 && _hall15_3.Count == 15)
            {
                Task.Delay(1000);
                ClearHalls();
            }
        }
        private void ClearHalls()
        {
            _hall100.Clear();
            _hall100_2.Clear();
            _hall15.Clear();
            _hall15_2.Clear();
            _hall15_3.Clear();
            UpdateHalls();
        }
        private void UpdateHalls()
        {
            foreach (var hall in new string[] { "Hall_1", "Hall_2", "Hall_3", "Hall_4", "Hall_5" })
            {
                OnPropertyChanged(hall);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}