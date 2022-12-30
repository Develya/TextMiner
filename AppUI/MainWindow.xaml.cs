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
using AppCore.DAL;
using ApppCore.DAL;
using AppCore.BLL.Model;
using CorpusService.BLL.Control;
using DocumentDistanceService.BLL.Control;
using static CorpusService.BLL.Control.CorpusController;
using StringDistanceService.BLL.Control;
using StringDistanceService.BLL.Control;

namespace AppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CorpusController corpusController;
        IDocumentDAO documentDAOInDB;
        IDocumentDistanceDAO documentDistanceDAO;

        public MainWindow()
        {
            InitializeComponent();
            this.corpusController = new CorpusController();
            this.documentDAOInDB = new DBInMemDocumentDAO(InMemoryDatabase.GetInstance());
            this.documentDistanceDAO = new DBInMemDocumentDistanceeDAO(InMemoryDatabase.GetInstance());
        }

        private void DataLoad(object sender, RoutedEventArgs e)
        {
            this.DataGridCorpus.ItemsSource = this.corpusController.FindAllDocuments(this.documentDAOInDB);
        }

        private void CalculateDocumentSimilaritiesButton(object sender, RoutedEventArgs e)
        {
            DistanceAlgorithm algorithm;
            switch (this.AlgorithmInputComboBox.SelectedItem)
            {
                case "Jaccard":
                    JaccardDocumentDistanceService jaccardService = new();
                    algorithm = jaccardService.GetDistance;
                    break;
                case "MinHash":
                    MinHashDocumentDistanceService minHashService = new();
                    algorithm = minHashService.GetDistance;
                    break;
                default:
                    throw new ArgumentException("wtf bro");
            }



            this.DataGridDocumentSimilarities.ItemsSource = this.corpusController.FindAllSimilarDocuments((double) this.ThresholdInputSlider.Value / 100, algorithm, this.documentDAOInDB, this.documentDistanceDAO);
        }

        private void LoadAlgorithmsComboBox(object sender, RoutedEventArgs e)
        {
            IList<string> algorithms = new List<string> { "None", "Jaccard", "MinHash" };
            ComboBox? algorithmsComboBox = sender as ComboBox;
            algorithmsComboBox.ItemsSource = algorithms;
            algorithmsComboBox.SelectedIndex = 0;
        }

        private void LoadWordSimilarityAlgorithmsComboBox(object sender, RoutedEventArgs e)
        {
            IList<string> algorithms = new List<string> { "None", "Hamming", "Jaccard", "Jaro", "Levenshtein", "Ngram", "SMC" };
            ComboBox? algorithmsComboBox = sender as ComboBox;
            algorithmsComboBox.ItemsSource = algorithms;
            algorithmsComboBox.SelectedIndex = 0;
        }

        private void CalculateWordSimilarityButtonClick(object sender, RoutedEventArgs e)
        {
            IStringDistanceService algorithm;
            switch (this.AlgorithmInputComboBoxWordSimilarityView.SelectedItem)
            {
                case "Hamming":
                    algorithm = new HammingStringDistanceService();
                    break;
                case "Jaccard":
                    algorithm = new JaccardStringDistanceService();
                    break;
                case "Jaro":
                    algorithm = new JaroStringDistanceService();
                    break;
                case "Levenshtein":
                    algorithm = new HammingStringDistanceService();
                    break;
                case "Ngram":
                    algorithm = new NGramStringDistanceService();
                    break;
                case "SMC":
                    algorithm = new SMCStringDistanceService();
                    break;
                default:
                    throw new ArgumentException("wtf bro");
            }

            double distancePercentage = algorithm.GetDistance(this.Word1InputTextBox.Text, this.Word2InputTextBox.Text);
            this.WordSimilarityResultLabel.Content = $"{distancePercentage}%";
        }
    }
}
