using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CodingAlgorithmsVisualizer
{
    public partial class MainWindow : Window
    {
        public MainWindow() { InitializeComponent(); }

        private string inputText = string.Empty;
        private string encodedText = string.Empty;
        private string decodedText = string.Empty;

        // GUI block
        private void EncodeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(inputText))
            {            
                inputText = InputTextBox.Text;
                if (RleRadioButton.IsChecked == true)
                    encodedText = ApplyRle(inputText);
                else if (HuffmanRadioButton.IsChecked == true)
                    encodedText = ApplyHuffman(inputText);
                else if (CabacRadioButton.IsChecked == true)
                    encodedText = ApplyCabac(inputText);

                EncOutputTextBox.Text = encodedText;
            }
        }
        private void DecodeButton_Click(object sender, RoutedEventArgs e)
        {
            if ( RleRadioButton.IsChecked == true)// & !string.IsNullOrEmpty(EncOutputTextBox.Text) )
                decodedText = Decode_rle(encodedText);
            else if (HuffmanRadioButton.IsChecked == true)
                decodedText = Decode_huffman(encodedText);
            else if (CabacRadioButton.IsChecked == true)
                decodedText = Decode_cabac(encodedText);
            DecOutputTextBox.Text = decodedText;
        }
        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputTextBox.Text))
            {
                PlaceholderTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                PlaceholderTextBlock.Visibility = Visibility.Hidden;
                inputText = InputTextBox.Text;
            }
        }

        // functions to work with an RLE-encoded strings
        private string ApplyRle(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            StringBuilder result = new StringBuilder(); // Initialize an empty string to store the encoded result
            int count = 1;                              // Initialize a counter for consecutive characters
            for (int i = 1; i < input.Length; i++)      // Loop through the input_string starting from the second character
            {
                if (input[i] == input[i - 1]) count++;  //If the current character is the same as the previous one, increment the counter
                else                                    // If a different character is encountered
                { 
                    result.Append(input[i - 1]);        // add the previous character 
                    result.Append(count);               // and its count to the encoded string
                    count = 1;                          // reset the counter
                }
            }
            result.Append(input[input.Length - 1]);     // Append the last character and its count
            result.Append(count);
            return result.ToString();
        }
        private string Decode_rle(string encoded_string)
        {   // Initialize an empty string to store the decoded result
            StringBuilder result = new StringBuilder();     
            for (int i = 0; i < encoded_string.Length; i++)
            {   // Use a for loop to have access to the index
                char chr = encoded_string[i];   // Get the current character
                if (!char.IsDigit(chr))         // If the character is a letter
                {   // Get the count of the character, char CANNOT be converted to int directly
                    int count = Convert.ToInt32(encoded_string[i + 1].ToString());
                    // Append the character 'count' times to the result
                    for (int j = 0; j < count; j++) result.Append(chr);
                } // else if chr is a number - do nothing, jump to a next item
            }
            return result.ToString();
        }

        // functions to work with a HUFFMAN coding
        private string Decode_huffman(string input)
        {
            // Implement Huffman algorithm here
            return "Huffman decoded output";
        }
        private string ApplyHuffman(string input)
        {
            // Implement Huffman algorithm here
            return "Huffman output";
        }

        // functions to work with a CABAC coding
        private string Decode_cabac(string input)
        {
            // Implement Huffman algorithm here
            return "CABAC decoded output";
        }
        private string ApplyCabac(string input)
        {
            // Implement CABAC algorithm here
            return "CABAC output";
        }
    }
}