namespace MathExpressionGenerator.Desktop
{
    using Common.ViewModels;
    using Common.Languages;
    using MathExpressionGenerator.Common.Containers;
    using MathExpressionGenerator.Models.Enums;
    using Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using MathExpressionGenerator.Models.Expressions.Еquations.Division;
    using MathExpressionGenerator.Common;

    public partial class MainWindow : Window
    {
        private const string BrowseText = "Browse...";

        private readonly string DesktopPath = Environment
            .GetFolderPath(Environment.SpecialFolder.Desktop);
        private readonly string MyDocumentsPath = Environment
            .GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private readonly ILanguageContainer languageContainer;
        private readonly IMathExpressionService mathService;
        private readonly IExpressionExtractor expressionExtractor;
        private readonly IExpressionContainer expressionContainer;
        private readonly IFileService fileService;
        private ILanguage currentLanguage;
        private string chosenPath;
        private HashSet<ExpressionOperation> checkedOperations;

        public MainWindow(
            ILanguageContainer languageContainer,
            IMathExpressionService mathService,
            IFileService fileService,
            IExpressionExtractor expressionExtractor,
            IExpressionContainer expressionContainer)
        {
            InitializeComponent();

            this.languageContainer = languageContainer;
            this.mathService = mathService;
            this.expressionExtractor = expressionExtractor;
            this.fileService = fileService;
            this.expressionContainer = expressionContainer;

            this.checkedOperations = new HashSet<ExpressionOperation>();
            this.InitializeLanguages();
            this.CheckExpressionOperations();
            this.InitializeExpressionTypes();
            this.ClearAlertBox();
        }

        private void CheckExpressionOperations()
        {
            this.chkBoxAddition.IsChecked = true;
            this.chkBoxSubtraction.IsChecked = true;
            this.chkBoxMultiplication.IsChecked = true;
            this.chkBoxDivision.IsChecked = true;
            this.chkBoxPowering.IsChecked = true;
            this.chkBoxRooting.IsChecked = true;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            this.expressionContainer.Clear();

            this.txtBoxResults.Text = string.Empty;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var expression = this.comboBoxExpressionType.SelectedItem as ExpressionViewModel;
            var isMinValid = int.TryParse(this.txtBoxMinNumber.Text, out int minValue);
            var isMaxValid = int.TryParse(this.txtBoxMaxNumber.Text, out int maxValue);
            var isCountValid = int.TryParse(this.txtBoxCount.Text, out int count);
            var areAllNumbersValid = isMinValid && isMaxValid && isCountValid;
            if (!areAllNumbersValid)
            {
                return;
            }

            var randomize = this.chkBoxRandomize.IsChecked.HasValue 
                ? chkBoxRandomize.IsChecked.Value 
                : false;

            if (minValue > maxValue)
            {
                this.SetAlertBox(this.currentLanguage.InvalidDifferenceMinMaxValue);

                return;
            }

            if (count > Constants.ExpressionsCountMaxValue)
            {
                this.SetAlertBox(this.currentLanguage.MaxCountOfExpressionsExceeded);

                return;
            }

            var mathExpressions = this.mathService
                .GenerateMathExpressions(expression.Type, minValue, maxValue, count, randomize);

            if (mathExpressions.Any())
            {
                this.expressionContainer.Add(mathExpressions);
            }

            this.txtBoxResults.Text = this.expressionContainer.GetExpressionsAsString();

            var isDivision = (mathExpressions.First() as BaseDivisionEquation) != null;
            if (isDivision)
            {
                this.SetAlertBox(this.currentLanguage.DivisionWarningMessage, Brushes.Orange);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileWhenReady = this.chkBoxOpenFileWhenReady.IsChecked.HasValue 
                ? chkBoxOpenFileWhenReady.IsChecked.Value 
                : false;
            var textFile = this.txtFileFormat.IsSelected;

            if (this.expressionContainer.GetExpressionsAsString().Length == 0)
            {
                return;
            }

            Task.Run(() =>
            {
                if (textFile)
                {
                    var fullPath = Path.Combine(
                        this.chosenPath, $"{this.currentLanguage.ExpressionsFileName}.txt");

                    this.fileService.CreateTextFile(
                        this.expressionContainer.GetExpressionsAsString(), fullPath, openFileWhenReady);
                }
                else
                {
                    var fullPath = Path.Combine(
                        this.chosenPath, $"{this.currentLanguage.ExpressionsFileName}.doc");

                    this.fileService.CreateWordFile(
                        this.expressionContainer.GetExpressionsAsString(), fullPath, openFileWhenReady);
                }
            });
        }

        private void ValidateNumbers(object sender, RoutedEventArgs e)
        {
            var alertMessage = string.Empty;

            var minNumberAsText = this.txtBoxMinNumber.Text;
            var maxNumberAsText = this.txtBoxMaxNumber.Text;
            var countNumberAsText = this.txtBoxCount.Text;

            alertMessage += this.BuildAlertMessage(minNumberAsText, int.MinValue, int.MaxValue);
            alertMessage += this.BuildAlertMessage(maxNumberAsText, int.MinValue, int.MaxValue);
            alertMessage += this.BuildAlertMessage(countNumberAsText, 1, int.MaxValue);

            this.SetAlertBox(alertMessage);
        }

        private void Desktop_Selected(object sender, RoutedEventArgs e)
        {
            this.chosenPath = DesktopPath;
            if (this.comboBoxFolderBrowser != null)
            {
                this.comboBoxFolderBrowser.Content = BrowseText;
            }
        }

        private void MyDocuments_Selected(object sender, RoutedEventArgs e)
        {
            this.chosenPath = MyDocumentsPath;
            if (this.comboBoxFolderBrowser != null)
            {
                this.comboBoxFolderBrowser.Content = BrowseText;
            }
        }

        private void BrowseDirectory_Selected(object sender, RoutedEventArgs e)
        {
            var folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            var result = folderBrowser.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.chosenPath = folderBrowser.SelectedPath;
                this.comboBoxFolderBrowser.Content = this.chosenPath
                    .Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries)
                    .Last();
            }
        }

        private void InitializeLanguages()
        {
            var allLangs = this.languageContainer.All().OrderBy(l => l.ToString());

            this.comboBoxLang.ItemsSource = allLangs;
            this.comboBoxLang.SelectedIndex = 0;
        }

        private void InitializeExpressionTypes()
        {
            var allExpressions = this.expressionExtractor.Extract(this.checkedOperations);

            this.comboBoxExpressionType.ItemsSource = allExpressions;
            this.comboBoxExpressionType.SelectedIndex = 0;
        }

        private string BuildAlertMessage(string numberAsText, int minValue, int maxValue)
        {
            var alertMessage = string.Empty;

            if (!string.IsNullOrEmpty(numberAsText))
            {
                if (!int.TryParse(numberAsText, out int number))
                {
                    alertMessage += string.Format(
                        this.currentLanguage.InvalidNumberFormatErrorMsg, numberAsText);
                    alertMessage += Environment.NewLine;
                }
                else if (number < minValue)
                {
                    alertMessage += this.currentLanguage.InvalidNumberMinValueErrorMsg;
                    alertMessage += Environment.NewLine;
                }
                else if (number > maxValue)
                {
                    alertMessage += this.currentLanguage.InvalidNumberMaxValueErrorMsg;
                    alertMessage += Environment.NewLine;
                }
            }

            return alertMessage;
        }

        private void SetAlertBox(string message, SolidColorBrush color = null)
        {
            if (color == null)
            {
                color = Brushes.Red;
            }

            this.AlertBox.Foreground = color;
            this.AlertBox.Text = message;
        }

        private void ClearAlertBox() => this.AlertBox.Clear();

        private void OnEnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.SaveButton_Click(sender, e);
            }
        }

        private void ComboBoxLang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.currentLanguage = this.comboBoxLang.SelectedItem as ILanguage;

            this.UpdateControlsLanguage();

            this.ValidateNumbers(sender, e);
        }

        private void UpdateControlsLanguage()
        {
            var x = this.AlertBox.Text;
            this.Title = this.currentLanguage.GeneratorTitle;

            this.lblChooseExpression.Content = this.currentLanguage.ChooseExpressionType;
            this.lblChooseMinNum.Content = this.currentLanguage.ChooseMinOperand;
            this.lblChooseMaxNum.Content = this.currentLanguage.ChooseMaxOperand;
            this.lblExprCount.Content = this.currentLanguage.ExpressionsCount;
            this.lblLanguage.Content = this.currentLanguage.Language;
            this.lblSaveAs.Content = this.currentLanguage.SaveAs;
            this.lblSaveTo.Content = this.currentLanguage.SaveTo;

            this.chkBoxRandomize.Content = this.currentLanguage.Randomize;
            this.chkBoxOpenFileWhenReady.Content = this.currentLanguage.OpenFileWhenReady;

            this.btnAdd.Content = this.currentLanguage.Add;
            this.btnClear.Content = this.currentLanguage.Clear;
            this.btnSave.Content = this.currentLanguage.Save;

            this.chkBoxAddition.Content = this.currentLanguage.Addition;
            this.chkBoxSubtraction.Content = this.currentLanguage.Subtraction;
            this.chkBoxMultiplication.Content = this.currentLanguage.Multiplication;
            this.chkBoxDivision.Content = this.currentLanguage.Division;
            this.chkBoxPowering.Content = this.currentLanguage.Powering;
            this.chkBoxRooting.Content = this.currentLanguage.SquareRooting;
        }

        private void ChkBoxDivision_Checked(object sender, RoutedEventArgs e)
        {
            this.SetAlertBox(this.currentLanguage.DivisionWarningMessage, Brushes.Orange);
            this.checkedOperations.Add(ExpressionOperation.Division);
            this.InitializeExpressionTypes();
        }

        private void ChkBoxDivision_Unchecked(object sender, RoutedEventArgs e)
        {
            this.ClearAlertBox();
            this.checkedOperations.Remove(ExpressionOperation.Division);
            this.InitializeExpressionTypes();
        }

        private void ChkBoxPowering_Checked(object sender, RoutedEventArgs e)
        {
            //this.checkedOperations.Add(ExpressionOperation.Powering);
            //this.InitializeExpressionTypes();
        }

        private void ChkBoxPowering_Unchecked(object sender, RoutedEventArgs e)
        {
            //this.checkedOperations.Remove(ExpressionOperation.Powering);
            //this.InitializeExpressionTypes();
        }

        private void ChkBoxRooting_Checked(object sender, RoutedEventArgs e)
        {
            //this.checkedOperations.Add(ExpressionOperation.SquareRooting);
            //this.InitializeExpressionTypes();
        }

        private void ChkBoxRooting_Unchecked(object sender, RoutedEventArgs e)
        {
            //this.checkedOperations.Remove(ExpressionOperation.SquareRooting);
            //this.InitializeExpressionTypes();
        }

        private void ChkBoxMultiplication_Unchecked(object sender, RoutedEventArgs e)
        {
            this.checkedOperations.Remove(ExpressionOperation.Multiplication);
            this.InitializeExpressionTypes();
        }

        private void ChkBoxMultiplication_Checked(object sender, RoutedEventArgs e)
        {
            this.checkedOperations.Add(ExpressionOperation.Multiplication);
            this.InitializeExpressionTypes();
        }

        private void ChkBoxSubtraction_Checked(object sender, RoutedEventArgs e)
        {
            this.checkedOperations.Add(ExpressionOperation.Subtraction);
            this.InitializeExpressionTypes();
        }

        private void ChkBoxSubtraction_Unchecked(object sender, RoutedEventArgs e)
        {
            this.checkedOperations.Remove(ExpressionOperation.Subtraction);
            this.InitializeExpressionTypes();
        }

        private void ChkBoxAddition_Checked(object sender, RoutedEventArgs e)
        {
            this.checkedOperations.Add(ExpressionOperation.Addition);
            this.InitializeExpressionTypes();
        }

        private void ChkBoxAddition_Unchecked(object sender, RoutedEventArgs e)
        {
            this.checkedOperations.Remove(ExpressionOperation.Addition);
            this.InitializeExpressionTypes();
        }
    }
}
