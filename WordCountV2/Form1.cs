using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCountV2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
        }

        //create string and fill it with whatever text is in the clipboard
        public string wordsToCount;
        public char firstLetter, lastLetter;
        //create containers for number of words, letters, spaces, and letters+spaces
        public int numberOfWords, numberOfLetters, numberOfSpaces, numberOfCharacters;

        //this test sentence includes 11 words, 66 characters, and 10 spaces
        //this test sentence includes 12 words, 70 characters, and 11 spaces now
        //another test sentence with different letters
        

        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //function is called every time button1 is clicked
        private void button1_Click_1(object sender, EventArgs e)
        {
            GetCount();

            //set the text in each text box to correspond to its calculated value
            this.textBox1.Text = "Word Count: " + numberOfWords;
            this.textBox2.Text = "Char Count(no spaces): " + numberOfLetters;
            this.textBox3.Text = "Char Count(inc. spaces): " + wordsToCount.Length;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        //function is called as soon as the application loads
        private void Form1_Load(object sender, EventArgs e)
        {
            
            GetCount();

            this.textBox1.Text = "Word Count: " + numberOfWords;
            this.textBox2.Text = "Char Count(no spaces): " + numberOfLetters;
            this.textBox3.Text = "Char Count(inc. spaces): " + wordsToCount.Length;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            TrackLetters();
            wordsToCount = Clipboard.GetText();

            if (wordsToCount[0] != firstLetter || wordsToCount[wordsToCount.Length - 1] != lastLetter)
            {
                GetCount();
                this.textBox1.Text = "Word Count: " + numberOfWords;
                this.textBox2.Text = "Char Count(no spaces): " + numberOfLetters;
                this.textBox3.Text = "Char Count(inc. spaces): " + wordsToCount.Length;

            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        //function to calculate word and letter counts
        private void GetCount()
        {
            //gather whatever text is on the clipboard
            wordsToCount = Clipboard.GetText();
            
            //count all characters, including spaces in wordsToCount and returns the result as an int
            numberOfCharacters = wordsToCount.Length;
            //assume at least one word, since the first character won't be a space
            numberOfWords = 1;
            //start space count at zero
            numberOfSpaces = 0;

            

            //run through each character in wordsToCount
            for (int i = 1; i < wordsToCount.Length; i++)
            {
                if (char.IsWhiteSpace(wordsToCount[i]))//check if the character at position i is a space
                {
                    numberOfSpaces++;//increment space count by one

                   
                }

                if (!char.IsWhiteSpace(wordsToCount[i]))//check if the character at position i is a letter or number
                {
                    if (char.IsWhiteSpace(wordsToCount[i - 1]))//checks if the previous character is a space
                    {
                        numberOfWords++;//increment word count by one
                    }
                }

            }



            //subtract spaces from all characters to get the number of letters
            numberOfLetters = numberOfCharacters - numberOfSpaces;
            TrackLetters();
        }

        private void TrackLetters()
        {
            firstLetter = wordsToCount[0];
            lastLetter = wordsToCount[wordsToCount.Length - 1];

            Console.WriteLine(firstLetter);
            Console.WriteLine(lastLetter);
        }
    }
}
