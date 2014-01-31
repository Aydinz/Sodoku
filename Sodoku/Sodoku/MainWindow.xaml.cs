using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Sodoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SuperLabel[,] labelArray = new SuperLabel[9,9];
        int[,] numbers = new int[9, 9];
        Grid DynamicGrid = new Grid();

        public MainWindow()
        {
            InitializeComponent();
            populateGrid();
        }

        public void populateGrid()
        {
            DynamicGrid.Width = 297;
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.Background = Brushes.LightGray;

            // Creating the columns
            ColumnDefinition[] gridCol = new ColumnDefinition[9];
            for (int i = 0; i < 9; i++)
            {
                gridCol[i] = new ColumnDefinition();
                gridCol[i].Width = new GridLength(33);
                DynamicGrid.ColumnDefinitions.Add(gridCol[i]);
            }
            // Creating the rows
            RowDefinition[] gridRow = new RowDefinition[9];
            for (int i = 0; i < 9; i++)
            {
                gridRow[i] = new RowDefinition();
                gridRow[i].Height = new GridLength(33);
                DynamicGrid.RowDefinitions.Add(gridRow[i]);
            }

            // c = columns
            // r = rows
            for (int r = 0; r < 9; r++)
            {

                for (int c = 0; c < 9; c++)
                {
                    labelArray[c, r] = new SuperLabel();
                    //labelArray[c, r].Content = c.ToString() + r.ToString();
                    Grid.SetRow(labelArray[c, r], c);
                    Grid.SetColumn(labelArray[c, r], r);

                    // Adding thick borders to define the sections
                    //
                    //
                    if (r == 0 || r == 3 || r == 6)
                    {
                        labelArray[c, r].BorderThickness = new Thickness(1.5, 0.25, 0.25, 0.25);
                    }
                    else if (r == 2 || r == 5 || r == 8)
                    {
                        labelArray[c, r].BorderThickness = new Thickness(0.25, 0.25, 1.5, 0.25);
                    }
                    if (c == 0 || c == 3 || c == 6)
                    {
                        if (r == 0 || r == 3 || r == 6)
                        {
                            labelArray[c, r].BorderThickness = new Thickness(1.5, 1.5, 0.25, 0.25);
                        }
                        else if (r == 2 || r == 5 || r == 8)
                        {
                            labelArray[c, r].BorderThickness = new Thickness(0.25, 1.5, 1.5, 0.25);
                        }
                        else
                        {
                            labelArray[c, r].BorderThickness = new Thickness(0.25, 1.5, 0.25, 0.25);
                        }
                    }
                    else if (c == 2 || c == 5 || c == 8)
                    {
                        if (r == 0 || r == 3 || r == 6)
                        {
                            labelArray[c, r].BorderThickness = new Thickness(1.5, 0.25, 0.25, 1.5);
                        }
                        else if (r == 2 || r == 5 || r == 8)
                        {
                            labelArray[c, r].BorderThickness = new Thickness(0.25, 0.25, 1.5, 1.5);
                        }
                        else
                        {
                            labelArray[c, r].BorderThickness = new Thickness(0.25, 0.25, 0.25, 1.5);
                        }
                    }

                    //numbers[c, r] = Convert.ToInt32(labelArray[c, r].Content);
                    DynamicGrid.Children.Add(labelArray[c, r]);
                }
            }

            outer.Children.Add(DynamicGrid);
        }

        private void showInstructions(object sender, RoutedEventArgs e)
        {
            string instructions = "How to play Sudoku: \n \n Each 3x3 square, row \n and column should \n contain the numbers \n 1-9. \n But no number can \n occur more than once \n in each 3x3 square, \n row or column.";
            instructionBox.Content = instructions;
        }//showInstructions
        private void changeBackground(object sender, RoutedEventArgs e)
        {
            if (black.IsChecked == true)
            {
                this.Background = Brushes.Black;
                instructionBox.Foreground = Brushes.White;
            }
            else if (white.IsChecked == true)
            {
                this.Background = Brushes.White;
                instructionBox.Foreground = Brushes.Black;
            }
            else
            {
                this.Background = Brushes.LightCoral;
            }
        }//changeBackground
        private void startNewGame(object sender, RoutedEventArgs e)
        {/*
            //createGameFields();
            if (easy.IsChecked == true)
            {
            }
            else if (medium.IsChecked == true)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (easy1[i, j] == 0)
                        {
                            Label labels = new Label();
                            labels.Width = 33;
                            labels.Height = 33;
                            labels.BorderThickness = new Thickness(0.5);
                            labels.BorderBrush = Brushes.Black;
                            labels.Content = "";
                            outer.Children.Add(labels);
                        }
                        else
                        {
                            Label labels = new Label();
                            labels.Width = 33;
                            labels.Height = 33;
                            labels.BorderThickness = new Thickness(0.5);
                            labels.BorderBrush = Brushes.Black;
                            labels.Content = easy1[i, j].ToString();
                            outer.Children.Add(labels);
                        }
                    }
                }
            }
            else if (hard.IsChecked == true)
            {
            }
          */
        }//startNewGame


        /************************************************
         * WALL OF CODE
         * ********************************************/
        int[,] easy1 = {{6, 0, 0, 0, 4, 0, 8, 3, 0},
                            {4, 8, 3, 6, 0, 0, 0, 0, 1},
                            {0, 1, 0, 8, 7, 0, 0, 4, 5},
                            {1, 2, 8, 4, 0, 0, 0, 9, 6},
                            {0, 0, 4, 0, 0, 9, 0, 0, 8},
                            {9, 6, 5, 2, 1, 0, 3, 7, 4},
                            {0, 0, 6, 7, 0, 1, 4, 0, 0},
                            {0, 7, 0, 0, 8, 4, 9, 0, 0},
                            {0, 0, 0, 0, 5, 0, 1, 0, 0}};
        static int[,] easy1Solv = {{6, 5, 7, 1, 4, 2, 8, 3, 9}, 
                                       {4, 8, 3, 6, 9, 5, 7, 2, 1}, 
                                       {2, 1, 9, 8, 7, 3, 6, 4, 5},
                                       {1, 2, 8, 4, 3, 7, 5, 9, 6},
                                       {7, 3, 4, 5, 6, 9, 2, 1, 8},
                                       {9, 6, 5, 2, 1, 8, 3, 7, 4},
                                       {8, 9, 6, 7, 2, 1, 4, 5, 3},
                                       {5, 7, 1, 3, 8, 4, 9, 6, 2},
                                       {3, 4, 2, 9, 5, 6, 1, 8, 7}};

        int[,] easy2 = {{0, 0, 6, 3, 5, 8, 0, 0, 4},
                            {0, 3, 1, 0, 4, 2, 0, 0, 6},
                            {8, 2, 0, 1, 0, 0, 0, 9, 0},
                            {3, 0, 5, 7, 2, 1, 0, 0, 0},
                            {7, 0, 0, 0, 6, 0, 0, 0, 9},
                            {4, 6, 2, 8, 3, 0, 0, 7, 0},
                            {2, 4, 0, 0, 0, 5, 8, 3, 7},
                            {0, 5, 0, 0, 8, 3, 0, 4, 0},
                            {0, 0, 0, 0, 9, 7, 6, 0, 0}};
        static int[,] easy2Solv = {{9, 7, 6, 3, 5, 8, 2, 1, 4},
                                       {5, 3, 1, 9, 4, 2, 7, 8, 6},
                                       {8, 2, 4, 1, 7, 6, 5, 9, 3},
                                       {3, 9, 5, 7, 2, 1, 4, 6, 8},
                                       {7, 1, 8, 5, 6, 4, 3, 2, 9},
                                       {4, 6, 2, 8, 3, 9, 1, 7, 5},
                                       {2, 4, 9, 6, 1, 5, 8, 3, 7},
                                       {6, 5, 7, 2, 8, 3, 9, 4, 1},
                                       {1, 8, 3, 4, 9, 7, 6, 5, 2}};

        int[,] easy3 = {{0, 0, 5, 0, 9, 4, 2, 1, 8},
                            {0, 2, 6, 1, 0, 3, 0, 7, 0},
                            {1, 8, 0, 7, 2, 5, 0, 6, 4},
                            {6, 0, 1, 0, 4, 0, 0, 0, 7},
                            {8, 0, 0, 2, 0, 1, 0, 0, 9},
                            {5, 0, 0, 0, 3, 0, 1, 4, 0},
                            {0, 0, 0, 4, 1, 2, 7, 0, 3},
                            {7, 0, 0, 0, 0, 0, 0, 0, 2},
                            {2, 0, 0, 0, 0, 6, 4, 8, 0}};
        static int[,] easy3Solv = {{3, 7, 5, 6, 9, 4, 2, 1, 8},
                                       {4, 2, 6, 1, 8, 3, 9, 7, 5},
                                       {1, 8, 9, 7, 2, 5, 3, 6, 4},
                                       {6, 3, 1, 5, 4, 9, 8, 2, 7},
                                       {8, 4, 7, 2, 6, 1, 5, 3, 9},
                                       {5, 9, 2, 8, 3, 7, 1, 4, 6},
                                       {9, 6, 8, 4, 1, 2, 7, 5, 3},
                                       {7, 1, 4, 3, 5, 8, 6, 9, 2},
                                       {2, 5, 3, 9, 7, 6, 4, 8, 1}};

        int[,] easy4 = {{3, 9, 1, 0, 0, 0, 0, 5, 8},
                            {0, 0, 2, 4, 9, 0, 0, 0, 6},
                            {0, 0, 7, 0, 3, 0, 9, 1, 2},
                            {7, 0, 3, 0, 8, 0, 0, 0, 5},
                            {8, 0, 9, 0, 5, 0, 0, 0, 1},
                            {4, 2, 5, 0, 0, 6, 0, 9, 0},
                            {9, 0, 6, 0, 4, 7, 2, 0, 3},
                            {0, 0, 0, 9, 0, 5, 1, 7, 4},
                            {0, 7, 4, 0, 0, 0, 0, 0, 0}};
        static int[,] easy4Solv = {{3, 9, 1, 6, 7, 2, 4, 5, 8},
                                       {5, 8, 2, 4, 9, 1, 7, 3, 6},
                                       {6, 4, 7, 5, 3, 8, 9, 1, 2},
                                       {7, 1, 3, 2, 8, 9, 6, 4, 5},
                                       {8, 6, 9, 7, 5, 4, 3, 2, 1},
                                       {4, 2, 5, 3, 1, 6, 8, 9, 7},
                                       {9, 5, 6, 1, 4, 7, 2, 8, 3},
                                       {2, 3, 8, 9, 6, 5, 1, 7, 4},
                                       {1, 7, 4, 8, 2, 3, 5, 6, 9}};

        int[,] medium1 = {{3, 0, 7, 4, 9, 0, 0, 2, 0},
                              {1, 0, 0, 0, 6, 0, 0, 3, 9},
                              {6, 2, 0, 5, 0, 0, 0, 0, 0},
                              {2, 1, 0, 9, 0, 0, 5, 0, 0},
                              {0, 0, 3, 0, 0, 0, 1, 0, 2},
                              {4, 0, 8, 0, 0, 2, 0, 9, 0},
                              {9, 0, 1, 0, 4, 0, 0, 0, 0},
                              {0, 0, 2, 1, 0, 3, 0, 7, 0},
                              {5, 0, 0, 0, 2, 9, 0, 0, 0}};
        static int[,] medium1Solv = {{3, 8, 7, 4, 9, 1, 6, 2, 5},
                                         {1, 4, 5, 2, 6, 7, 8, 3, 9},
                                         {6, 2, 9, 5, 3, 8, 4, 1, 7},
                                         {2, 1, 6, 9, 7, 4, 5, 8, 3},
                                         {7, 9, 3, 6, 8, 5, 1, 4, 2},
                                         {4, 5, 8, 3, 1, 2, 7, 9, 6},
                                         {9, 3, 1, 7, 4, 6, 2, 5, 8},
                                         {8, 6, 2, 1, 5, 3, 9, 7, 4},
                                         {5, 7, 4, 8, 2, 9, 3, 6, 1}};

        int[,] medium2 = {{0, 0, 0, 9, 2, 0, 0, 0, 8},
                              {0, 3, 9, 0, 0, 0, 1, 0, 5},
                              {2, 4, 0, 0, 0, 1, 0, 0, 0},
                              {0, 9, 8, 2, 0, 0, 5, 4, 6},
                              {0, 0, 0, 5, 0, 0, 0, 0, 2},
                              {0, 2, 0, 4, 0, 8, 7, 3, 0},
                              {9, 0, 0, 0, 0, 0, 0, 7, 1},
                              {0, 8, 0, 0, 7, 4, 0, 5, 3},
                              {6, 0, 0, 0, 0, 0, 0, 8, 0}};
        static int[,] medium2Solv = {{7, 1, 5, 9, 2, 3, 4, 6, 8},
                                         {8, 3, 9, 7, 4, 6, 1, 2, 5},
                                         {2, 4, 6, 8, 5, 1, 3, 9, 7},
                                         {3, 9, 8, 2, 1, 7, 5, 4, 6},
                                         {4, 6, 7, 5, 3, 9, 8, 1, 2},
                                         {5, 2, 1, 4, 6, 8, 7, 3, 9},
                                         {9, 5, 4, 3, 8, 2, 6, 7, 1},
                                         {1, 8, 2, 6, 7, 4, 9, 5, 3},
                                         {6, 7, 3, 1, 9, 5, 2, 8, 4}};

        int[,] medium3 = {{0, 8, 6, 1, 0, 5, 2, 0, 0},
                              {9, 0, 5, 3, 0, 0, 0, 0, 0},
                              {7, 0, 1, 0, 0, 0, 8, 0, 0},
                              {6, 9, 0, 0, 0, 1, 0, 0, 0},
                              {0, 1, 3, 0, 4, 0, 0, 8, 2},
                              {0, 7, 0, 0, 5, 8, 6, 0, 0},
                              {0, 0, 9, 8, 0, 3, 0, 0, 1},
                              {8, 0, 0, 0, 0, 4, 5, 0, 0},
                              {0, 6, 2, 0, 0, 7, 0, 0, 0}};
        static int[,] medium3Solv = {{3, 8, 6, 1, 7, 5, 2, 9, 4},
                                         {9, 4, 5, 3, 8, 2, 1, 7, 6},
                                         {7, 2, 1, 4, 6, 9, 8, 3, 5},
                                         {6, 9, 8, 2, 3, 1, 4, 5, 7},
                                         {5, 1, 3, 7, 4, 6, 9, 8, 2},
                                         {2, 7, 4, 9, 5, 8, 6, 1, 3},
                                         {4, 5, 9, 8, 2, 3, 7, 6, 1},
                                         {8, 3, 7, 6, 1, 4, 5, 2, 9},
                                         {1, 6, 2, 5, 9, 7, 3, 4, 8}};

        int[,] medium4 = {{0, 0, 3, 0, 0, 4, 2, 8, 9},
                              {0, 0, 0, 0, 2, 6, 0, 0, 5},
                              {0, 7, 0, 0, 0, 5, 0, 0, 0},
                              {0, 0, 1, 6, 5, 0, 8, 0, 2},
                              {0, 6, 5, 4, 8, 0, 0, 0, 1},
                              {7, 0, 4, 0, 0, 0, 3, 0, 6},
                              {5, 2, 7, 0, 0, 0, 0, 0, 0},
                              {0, 0, 9, 0, 0, 2, 1, 6, 8},
                              {8, 0, 0, 0, 0, 0, 0, 0, 0}};
        static int[,] medium4Solv = {{6, 5, 3, 7, 1, 4, 2, 8, 9},
                                         {1, 4, 8, 9, 2, 6, 7, 3, 5},
                                         {9, 7, 2, 8, 3, 5, 6, 1, 4},
                                         {3, 9, 1, 6, 5, 7, 8, 4, 2},
                                         {2, 6, 5, 4, 8, 3, 9, 7, 1},
                                         {7, 8, 4, 2, 9, 1, 3, 5, 6},
                                         {5, 2, 7, 1, 6, 8, 4, 9, 3},
                                         {4, 3, 9, 5, 7, 2, 1, 6, 8},
                                         {8, 1, 6, 3, 4, 9, 5, 2, 7}};

        int[,] hard1 = {{5, 0, 7, 0, 0, 0, 0, 8, 0},
                            {4, 0, 3, 0, 0, 0, 0, 0, 0},
                            {0, 6, 8, 3, 0, 1, 0, 9, 5},
                            {0, 0, 0, 1, 0, 0, 6, 0, 7},
                            {0, 0, 0, 7, 0, 0, 0, 0, 4},
                            {0, 3, 6, 0, 0, 5, 0, 0, 2},
                            {0, 5, 0, 0, 0, 0, 0, 2, 0},
                            {0, 0, 0, 6, 4, 0, 0, 0, 0},
                            {6, 0, 0, 0, 9, 0, 0, 0, 0}};
        static int[,] hard1Solv = {{5, 1, 7, 9, 6, 4, 2, 8, 3},
                                       {4, 9, 3, 2, 5, 8, 7, 6, 1},
                                       {2, 6, 8, 3, 7, 1, 4, 9, 5},
                                       {8, 4, 5, 1, 2, 9, 6, 3, 7},
                                       {1, 2, 9, 7, 3, 6, 8, 5, 4},
                                       {7, 3, 6, 4, 8, 5, 9, 1, 2},
                                       {9, 5, 4, 8, 1, 7, 3, 2, 6},
                                       {3, 8, 1, 6, 4, 2, 5, 7, 9},
                                       {6, 7, 2, 5, 9, 3, 1, 4, 8}};

        int[,] hard2 = {{4, 0, 0, 0, 0, 0, 6, 0, 9},
                            {7, 0, 0, 0, 0, 0, 3, 0, 0},
                            {5, 0, 0, 9, 4, 6, 0, 7, 0},
                            {0, 0, 3, 0, 0, 0, 0, 0, 0},
                            {0, 7, 0, 0, 0, 0, 0, 0, 0},
                            {0, 0, 0, 1, 0, 0, 0, 5, 0},
                            {9, 0, 2, 0, 7, 3, 1, 8, 0},
                            {0, 0, 0, 0, 6, 0, 5, 0, 0},
                            {1, 4, 6, 0, 0, 0, 0, 2, 0}};
        static int[,] hard2Solv = {{4, 2, 8, 3, 5, 7, 6, 1, 9},
                                       {7, 6, 9, 8, 1, 2, 3, 4, 5},
                                       {5, 3, 1, 9, 4, 6, 8, 7, 2},
                                       {2, 1, 3, 7, 9, 5, 4, 6, 8},
                                       {8, 7, 5, 6, 2, 4, 9, 3, 1},
                                       {6, 9, 4, 1, 3, 8, 2, 5, 7},
                                       {9, 5, 2, 4, 7, 3, 1, 8, 6},
                                       {3, 8, 7, 2, 6, 1, 5, 9, 4},
                                       {1, 4, 6, 5, 8, 9, 7, 2, 3}};

        int[,] hard3 = {{0, 0, 8, 3, 9, 0, 0, 0, 0},
                            {0, 0, 0, 8, 0, 6, 0, 4, 3},
                            {6, 0, 0, 0, 5, 0, 0, 9, 2},
                            {0, 0, 0, 0, 0, 0, 0, 3, 0},
                            {4, 0, 0, 0, 0, 0, 0, 6, 0},
                            {0, 0, 5, 1, 0, 4, 7, 0, 0},
                            {0, 7, 0, 0, 0, 0, 5, 0, 0},
                            {0, 0, 0, 0, 4, 9, 0, 0, 6},
                            {0, 0, 1, 0, 0, 0, 3, 7, 0}};
        static int[,] hard3Solv = {{1, 4, 8, 3, 9, 2, 6, 5, 7},
                                       {5, 2, 9, 8, 7, 6, 1, 4, 3},
                                       {6, 3, 7, 4, 5, 1, 8, 9, 2},
                                       {7, 1, 6, 9, 2, 8, 4, 3, 5},
                                       {4, 8, 2, 5, 3, 7, 9, 6, 1},
                                       {3, 9, 5, 1, 6, 4, 7, 2, 8},
                                       {2, 7, 4, 6, 1, 3, 5, 8, 9},
                                       {8, 5, 3, 7, 4, 9, 2, 1, 6},
                                       {9, 6, 1, 2, 8, 5, 3, 7, 4}};

        int[,] hard4 = {{0, 7, 0, 0, 0, 0, 0, 5, 0},
                            {0, 0, 8, 1, 0, 0, 0, 0, 6},
                            {6, 0, 0, 0, 4, 2, 7, 0, 8},
                            {0, 0, 5, 0, 0, 0, 0, 0, 9},
                            {0, 8, 4, 7, 0, 0, 0, 0, 0},
                            {0, 0, 0, 0, 5, 0, 3, 0, 2},
                            {0, 0, 9, 0, 0, 0, 0, 0, 0},
                            {2, 4, 0, 0, 0, 0, 0, 8, 0},
                            {0, 0, 0, 3, 1, 9, 0, 6, 0}};
        static int[,] hard4Solv = {{4, 7, 2, 8, 9, 6, 1, 5, 3},
                                       {5, 9, 8, 1, 3, 7, 4, 2, 6},
                                       {6, 3, 1, 5, 4, 2, 7, 9, 8},
                                       {3, 2, 5, 4, 6, 1, 8, 7, 9},
                                       {9, 8, 4, 7, 2, 3, 6, 1, 5},
                                       {7, 1, 6, 9, 5, 8, 3, 4, 2},
                                       {1, 6, 9, 2, 8, 4, 5, 3, 7},
                                       {2, 4, 3, 6, 7, 5, 9, 8, 1},
                                       {8, 5, 7, 3, 1, 9, 2, 6, 4}};
    } 

}
