using Avalonia.Controls;
using Avalonia.Interactivity; 
using System.Collections.ObjectModel; 
namespace SmartExpenseLogger;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }
    public ObservableCollection<Expense> MyExpenses { get; set; } = new ObservableCollection<Expense>();
    public void OnAddButtonClick(object sender, RoutedEventArgs e)
    {
        var descInput = this.FindControl<TextBox>("txtDescription");
        var amountInput = this.FindControl<TextBox>("txtAmount");

        if (descInput == null || amountInput == null) return;
        if (string.IsNullOrWhiteSpace(descInput.Text) || string.IsNullOrWhiteSpace(amountInput.Text))
            return;
        if (double.TryParse(amountInput.Text, out double parsedAmount))
        {
            var newExpense = new Expense 
            { 
                Description = descInput.Text, 
                Amount = double.Parse(amountInput.Text),
                Category = "General" 
            };

            MyExpenses.Add(newExpense);
        }
        descInput.Text = "";
        amountInput.Text = "";
    }
}
public class Expense
{
    public string Description { get; set; }
    public double Amount { get; set; }
    public string Category { get; set; }
    public override string ToString()
    {
        return $"{Description} - {Amount}€ ({Category})";
    }
}