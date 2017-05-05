using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


/***************************************************************************************
 *  Class : TestFormHighPerformanceListView
 *  Type  : WinForm form
 *  Author: Curt Cearley
 *  Email : harpyeaglecp@aol.com
 *  
 *  This software is released under the Code Project Open License (CPOL)
 *  See official license description at: http://www.codeproject.com/info/cpol10.aspx
 *  
 *  This software is provided AS-IS without any warranty of any kind.
 *  
 *  Modification History:
 *  06/15/2009  curtcearley     Creation of class for www.codeproject.com example.
 * 
 ***************************************************************************************/


namespace TestApplication
{
    /// <summary>
    /// Application form to demonstrate the HighPerformanceListView
    /// component displaying a large amount of data.
    /// </summary>
    public partial class TestFormHighPerformanceListView : Form
    {
        private ListViewWordsProvider listViewWords;
        private WordFinder WordFind;
        public TestFormHighPerformanceListView()
        {
            InitializeComponent();

            // Create a provider to supply data items, columns, etc to 
            // the HighPerformanceListView
            listViewWords = new ListViewWordsProvider();

            // Associate the new provider with the list view control:
            highPerformanceListView.ListViewProvider = listViewWords;

            WordFind = new WordFinder();
        }

        private void searchButton1_Click(object sender, EventArgs e)
        {


            listViewWords.DataList = null;
            wordsfound.Text = "Please Wait, Searching...";
            Application.DoEvents();
            listViewWords.DataList = WordFind.FindWords(tilesBox.Text);
            wordsfound.Text = "Words Found: " + listViewWords.DataList.Count;
        }

        private void searchButton2_Click(object sender, EventArgs e)
        {
            listViewWords.DataList = null;
            wordsfound.Text = "Please wait, Searching...";
            Application.DoEvents();
            listViewWords.DataList = WordFind.PatternMatch(tilesBox.Text, patternBox.Text);
            wordsfound.Text = "Words Found: " + listViewWords.DataList.Count;
        }
    }
}
