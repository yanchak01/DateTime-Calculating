using CSharpTest;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WorkDayCalculator WorkDayCalculator;
        List<WeekEnd> ends;
        public MainWindow()
        {
            InitializeComponent();
            WorkDayCalculator = new WorkDayCalculator();
            SetInstruction();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WeekEndsPanel.Items.Count!=0)
            {
                ends = new List<WeekEnd>();
                for (int i = 0; i < WeekEndsPanel.Items.Count; i++)
                {
                    string[] dateTimes = WeekEndsPanel.Items[i].ToString().Split(new char[] { '-' });
                    ends.Add(
                        new WeekEnd(DateTime.ParseExact(dateTimes[0],"dd.MM.yyyy",null), DateTime.ParseExact(dateTimes[1],"dd.MM.yyyy",null))
                        );
                }
                FinalDateLabel.Content = WorkDayCalculator.Calculate(DateTime.ParseExact(FirstDay.Text, "dd.MM.yyyy", null), int.Parse(Count.Text), ends.ToArray()).ToString();
            }
            else
                FinalDateLabel.Content = WorkDayCalculator.Calculate(DateTime.ParseExact(FirstDay.Text,"dd.MM.yyyy",null), int.Parse(Count.Text), null).ToString("dd.MM.yyyy");

            }
            catch
            {
                MessageBox.Show("Please enter corrext data");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StartWE.Text!="" && EndWE.Text!="")
                {
                    string s = StartWE.Text + "-" + EndWE.Text;
                    int k = 0;
                    for (int i = 0; i < WeekEndsPanel.Items.Count; i++)
                    {
                        if (s== WeekEndsPanel.Items[i].ToString())
                        {
                            k++;
                        }
                    }
                    if (k==0)
                    {
                        WeekEndsPanel.Items.Add(s);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please enter input values");
            }
        }

        private void SetInstruction()
        {
            InstructionBox.Text = "Instruction:" + Environment.NewLine + "Data must be in format:" + Environment.NewLine
                + "dd.MM.yyyy" + Environment.NewLine + "This is just a test project, not designed to handle exceptions of all kinds" + Environment.NewLine
                + "However, here you can safely calculate simple values";
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < WeekEndsPanel.Items.Count; i++)
            {
                WeekEndsPanel.Items.Remove(WeekEndsPanel.Items[i]);
            }
        }
    }
}
