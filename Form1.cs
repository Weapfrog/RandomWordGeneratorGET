using RandomWordGeneratorGET.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomWordGeneratorGET
{
    public partial class Form1 : Form
    {
        UnitOfWork _uow = new UnitOfWork();
        public Form1()
        {
            InitializeComponent();
            Setup();
        }
        public void Setup()
        {
            listView1.Columns.Add("Code");
            listView1.View = View.Details;
            listView1.GridLines = true;
            Control.CheckForIllegalCrossThreadCalls = false;
            backgroundWorkerWord.WorkerReportsProgress = true;
            backgroundWorkerWord.WorkerSupportsCancellation = true;
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public int GetAllWordsCount()
        {
            var response = _uow.GetAllWords();
            var count = response.Count;
            return count;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var response = _uow.GetWords();
            listView1.Items.Add(response[0].WordName);
            if (backgroundWorkerWord.IsBusy != true)
            {
                backgroundWorkerWord.RunWorkerAsync();
            }
        }
        public void AddListViewCode()
        {
            int index = listView1.Items.Count - 1;
            var response = _uow.GetWords();
            string code = response[0].WordName;
            if (listView1.Items[index].Text != code)
            {
                listView1.Items.Add(code);
                index++;
            }
        }

        private void backgroundWorkerWord_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (true)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    AddListViewCode();
                    Thread.Sleep(3000);
                }
            }
        }
    }
}
