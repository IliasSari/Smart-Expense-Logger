using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic; 
using System.Collections.ObjectModel; 

namespace SmartExpenseLogger;

public partial class MainWindow : Window
{
    public List<string> Categories { get; set; } = new List<string> 
    { 
        "Food", "Transport", "Entertainment", "Home", "Other" 
    };
    public ObservableCollection<Expense> MyExpenses { get; set; } = new ObservableCollection<Expense>();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public void OnAddButtonClick(object sender, RoutedEventArgs e)
    {
        var descInput = this.FindControl<TextBox>("txtDescription");
        var amountInput = this.FindControl<TextBox>("txtAmount");
        var comboInput = this.FindControl<ComboBox>("cmbCategory");

        if (string.IsNullOrWhiteSpace(descInput?.Text) || string.IsNullOrWhiteSpace(amountInput?.Text))
            return;
        if (double.TryParse(amountInput.Text, out double parsedAmount))
        {
            var newExpense = new Expense 
            { 
                Description = descInput.Text, 
                Amount = parsedAmount,
                Category = comboInput?.SelectedItem?.ToString() ?? "General" 
            };

            MyExpenses.Add(newExpense);
        }
        descInput.Text = "";
        amountInput.Text = "";
    }
}
public class Expense
{
    public string Description { get; set; } = string.Empty; 
    public double Amount { get; set; }
    public string Category { get; set; } = string.Empty;
    public override string ToString()
    {
        return $"{Description} - {Amount}€ ({Category})";
    }
}