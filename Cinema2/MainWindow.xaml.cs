using System.Windows;
using System.Timers;
using System.Threading;

namespace Cinema2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cinema _c;
        public Cinema Cinema => _c;
        public void StartThread(object sender, ElapsedEventArgs e) {
            Thread t = new Thread(() => Cinema.AddUser(new User())) { IsBackground = true };
            t.Start();
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _c = new Cinema();
            System.Timers.Timer t = new System.Timers.Timer { Interval = 10 };
            t.Elapsed += StartThread;
            t.Start();

        }
    }
}
