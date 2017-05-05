using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HarpyEagle.HighPerformanceControls;


/***************************************************************************************
 *  Class : ListViewWordsProvider
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
    /// This class is an example of a IHighPerformanceListViewProvider
    /// implementation.
    /// 
    /// The provider classes are tightly associated with type type of 
    /// data that is being displayed in the ListView.
    /// 
    /// This class works with a HighPerformanceListView to 
    /// display a list of 'DataItem' records.
    /// </summary>
    public class ListViewWordsProvider : ListViewProviderBase
    {
        // List that holds a reference to the application specific data to be displayed.
        // In real life - this could be other data sources, such as rows in a very large
        // SQL query, etc.
        private List<DataItem> dataList;

        /// <summary>
        /// Gets or sets the application specific data list.        
        /// </summary>
        /// <value>The data list.</value>
        public List<DataItem> DataList
        {
            get
            {
                return dataList;
            }

            set
            {
                // Save reference to new data list
                dataList = value;

                if (listView == null)
                    throw new Exception("ListViewWordsProvider Error - the internal HighPerformanceListView has not been set, cannot display data");


                // Tell the list view to display a new list.
                listView.DisplayDataItemList();
            }
        }


        #region IHighPerformanceListViewProvider Members

        /////////////////////////////////////////////////////////////////////////////////
        // The interface methods are used to interact with the HighPerformanceListView //
        /////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Returns a list of column headers to use for the list view.
        /// </summary>
        /// <value>The column headers.</value>
        public override List<ColumnHeader> ColumnHeaders
        {
            get
            {
                ColumnHeader hdr;
                List<ColumnHeader> result = new List<ColumnHeader>();

                // First Column: Title 
                hdr = new ColumnHeader();
                hdr.Text = "Words";
                hdr.Width = 128;
                result.Add(hdr);

                // Second Column: 
                hdr = new ColumnHeader();
                hdr.Text = "Length";
                hdr.Width = 85;
                result.Add(hdr);

                // Third Column: 
                hdr = new ColumnHeader();
                hdr.Text = "Score";
                hdr.Width = 85;
                result.Add(hdr);

                return result;
            }
        }

        /// <summary>
        /// Sort the data list. Usually in response to clicking a column on the list view.
        /// </summary>
        /// <param name="sortColumnNumber">The column number to sort.</param>
        /// <param name="sortOrder">Order in which to perform the sort (Ascending or Descending).</param>
        public override void SortDataList(int sortColumnNumber, System.Windows.Forms.SortOrder sortOrder)
        {
            if (dataList != null)
            {
                dataList.Sort(delegate(DataItem firstItem, DataItem secondItem)
                {
                    int result = 0;

                    if (sortColumnNumber == 0)
                    {
                        // Sort the data by first name
                        result = firstItem.Word.CompareTo(secondItem.Word);
                    }
                    else if (sortColumnNumber == 1)
                    {
                        // Sort the data by last name
                        result = firstItem.Length.CompareTo(secondItem.Length);
                    }
                    else if (sortColumnNumber == 2)
                    {
                        // Sort the data by last name
                        result = firstItem.Score.CompareTo(secondItem.Score);
                    }

                    if (sortOrder == SortOrder.Descending)
                        result = result * (-1); // Reverse the result for descending order

                    return result;
                });

            }
        }

        /// <summary>
        /// Creates a ListViewItem that represents a single item of data from the data list.
        /// Used by the HighPerformanceListView dynamically create items to display in the view.
        /// </summary>
        /// <param name="dataIndex">Index of the data item to display in ListViewItem.</param>
        /// <returns>ListViewItem representing the data item at the supplied index.</returns>
        public override ListViewItem ConvertDataItemToListViewItem(int dataIndex)
        {
            ListViewItem result;
            if (dataList != null && dataIndex < dataList.Count)
            {
                string score = dataList[dataIndex].Score.ToString();
                string length = dataList[dataIndex].Length.ToString();
                result = new ListViewItem(this.dataList[dataIndex].Word);
                result.SubItems.Add(length);
                result.SubItems.Add(score);
            }
            else
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// Returns the number of data items in the data list.
        /// </summary>
        /// <value>The data count.</value>
        public override int DataCount
        {
            get
            {
                int result;
                if (dataList != null)
                    result = dataList.Count;
                else
                    result = 0;
                return result;
            }
        }

        #endregion
    }
}
