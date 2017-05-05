using System;
using System.Collections.Generic;
using System.Text;

/***************************************************************************************
 *  Class : DataItem
 *  Type  : Class
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
    /// This class represents an object that holds some data to be displayed.
    /// This class has two properties, "Word", and "Length".
    /// In real life, this could be records from an sql query, etc.
    /// </summary>
    public class DataItem
    {
        // Variables to store data values
        private String word;
        private int length;
        private int score;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataItem"/> class.
        /// </summary>
        /// <param name="fisrtName">A First Name string value.</param>
        /// <param name="secondName">A Last Name string value.</param>
        public DataItem(String word, int length, int score)
        {
            this.word = word;
            this.length = length;
            this.score = score;
        }

        // Properties to access data values:
        public String Word { get { return word;} }
        public int Length { get { return length; } }
        public int Score { get { return score; } }
    }
}
