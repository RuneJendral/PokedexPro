using System.Windows;

namespace PokedexWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var vm = new MainViewModel();
            DataContext = vm;

            Loaded += (_, __) =>
            {
                if (vm.SearchCommand.CanExecute(null))
                    vm.SearchCommand.Execute(null); 
            };
        }
    }
}