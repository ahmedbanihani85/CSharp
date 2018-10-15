using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel;

namespace ExcelStatistics
{
    public partial class Form1 : Form
    {
        private DataSet result;
        private double IdelBackLightOffAverage;
        private double IdelBackLightOnAverage;

        private List<double> Watts;
        private double maxwatt;
        private double minwatt;
        private double averagewatt;
        private double wattcount;
               
        private List<double> Watts_BackLightOff;
        private double BackLightOff_maxwatt;
        private double BackLightOff_minwatt;
        private double BackLightOff_averagewatt;
        private double BackLightOff_wattcount;

        private List<double> Watts_BackLightOn;
        private double BackLightOn_maxwatt;
        private double BackLightOn_minwatt;
        private double BackLightOn_averagewatt;
        private double BackLightOn_wattcount;

        private  DataTable dt;
        private string FileName;
        private StringBuilder SB;
        private StreamWriter Writer;



        public Form1()
        {
            InitializeComponent();
            this.Watts = new System.Collections.Generic.List<double>();
            this.Watts_BackLightOff = new System.Collections.Generic.List<double>();
            this.Watts_BackLightOn = new System.Collections.Generic.List<double>();
            SB = new StringBuilder();
            this.IdelBackLightOffAverage = 0.00005630630631;
            this.textBoxIdelBackLightOffAvg.Text = IdelBackLightOffAverage.ToString();
            this.IdelBackLightOnAverage = 0.92595355863648;
            this.textBoxIdelBackLightOnAvg.Text = this.IdelBackLightOnAverage.ToString();


        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.buttonExportFilesReport.Visible = false;
            this.comboBoxFilesList.Items.Clear();
            using (OpenFileDialog ofd = new OpenFileDialog() {Filter= "Excel Workbook|*.xlsx", ValidateNames= true })
            {
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    foreach (string filename in ofd.FileNames)
                    {
                        this.comboBoxFilesList.Items.Add(filename);

                    }

                    if (this.comboBoxFilesList.Items.Count > 1)
                        this.buttonExportFilesReport.Visible = true;

                }

            }
        }


        private void ReadFile(string FileName)
        {
            FileStream fs = File.Open(FileName, FileMode.Open, FileAccess.Read);
            // IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(fs);
            IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(fs);
            reader.IsFirstRowAsColumnNames = true;
            result = reader.AsDataSet();
            this.comboBox1.Items.Clear();
            this.Watts.Clear();
            foreach (DataTable dt in result.Tables)
            {
                comboBox1.Items.Add(dt.TableName);
            }
            this.FileName = FileName;
            reader.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = result.Tables[comboBox1.SelectedIndex];
            LoadWattsList(result.Tables[comboBox1.SelectedIndex].TableName);
        }
        private void comboBoxFilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadFile(this.comboBoxFilesList.Items[this.comboBoxFilesList.SelectedIndex].ToString());
        }

        private void LoadWattsList(string TableName)
        {
            
            dt = this.result.Tables[TableName];
            if (dt.Columns.IndexOf("Watts")>=0)
            { 
                string datavalue;
                for (int i=0;i<dt.Rows.Count;i++)
                {
                    datavalue = dt.Rows[i]["Watts"].ToString();

                    if(datavalue.Length>0)
                    { 
             
                        Watts.Add(Double.Parse(datavalue));
                    }
                }
                if (this.Watts.Count > 0)
                {
                    this.maxwatt = Watts.Max();
                    this.minwatt = Watts.Min();
                    this.averagewatt = Watts.Average();
                    this.wattcount = this.Watts.Count;
                    this.FileName = dt.TableName;
                    ShowValues();
                }
            }

        }

        private void ShowValues()
        {
            this.textBoxFileName.Text = this.FileName;
            this.textBoxMaxWatt.Text = maxwatt.ToString();
            this.textBoxMinWatt.Text = minwatt.ToString();
            this.textBoxAverageWatt.Text = averagewatt.ToString();
            this.textBoxCount.Text = this.wattcount.ToString();
            this.textBoxExpoFileName.Text = this.FileName + "_Statistics.csv";

        }

         

        private void button2_Click(object sender, EventArgs e)
        {
            /*StreamWriter Exp = new StreamWriter(this.textBoxExpoFileName.Text, true);
            StringBuilder DatatoExport = new StringBuilder();
            DatatoExport.Append(this.FileName + "\n");
            DatatoExport.AppendLine("MAX WATT, MIN WATT, AVERAGE WATT, # of Readings");
            DatatoExport.AppendLine(this.maxwatt+","+this.minwatt+","+this.averagewatt+","+this.wattcount);
            DatatoExport.AppendLine(",,,");
            Exp.Write(DatatoExport);
            Exp.Close();
            DatatoExport.Clear();*/
            if (this.comboBoxFilesList.Items.Count > 0)
            {
                ReadFile(this.comboBoxFilesList.Items[this.comboBoxFilesList.SelectedIndex].ToString());
                LoadWattsList(result.Tables[0].TableName);
                DoStatistics();
                AppendToSBToExport();
                AppendToSBToExportSingleFile();
                Writer = new StreamWriter(this.textBoxExpoFileName.Text, true);
                Writer.Write(SB);
                Writer.Close();
                SB.Clear();
                MessageBox.Show(this.textBoxExpoFileName.Text + " File Export is done.");
            }
        }

        private void ExportEachFileInSingleReport()
        {
            if(this.comboBoxFilesList.Items.Count>0)
            { 
                for(int i=0;i<this.comboBoxFilesList.Items.Count;i++)
                { 
                    ReadFile(this.comboBoxFilesList.Items[i].ToString());
                    LoadWattsList(result.Tables[0].TableName);
                    DoStatistics();
                    AppendToSBToExport();
                    AppendToSBToExportSingleFile();
                    Writer = new StreamWriter(this.textBoxExpoFileName.Text, true);
                    Writer.Write(SB);
                    Writer.Close();
                    SB.Clear();
                }
            }
        } 
        private void InitializeLists()
        {
            if (this.Watts_BackLightOff == null)
            {
                this.Watts_BackLightOff = new System.Collections.Generic.List<double>();
            }
            else
            {
                this.Watts_BackLightOff.Clear();
            }

            if (this.Watts_BackLightOn == null)
            {
                this.Watts_BackLightOn = new System.Collections.Generic.List<double>();
            }
            else
            {
                this.Watts_BackLightOn.Clear();
            }
        }
        private void Calculate_BackLightOnOff()
        {
            double currentelement;
            for (int i = 0; i < this.Watts.Count; i++)
            {
                currentelement= double.Parse(Watts[i].ToString());
                Watts_BackLightOn.Add(currentelement-IdelBackLightOnAverage);
                Watts_BackLightOff.Add(currentelement - IdelBackLightOffAverage);
            }

        }

        private void FindBackLightOnOffStatistics()
        {
            this.BackLightOff_wattcount = this.Watts_BackLightOff.Count;
            this.BackLightOff_maxwatt = this.Watts_BackLightOff.Max();
            this.BackLightOff_minwatt = this.Watts_BackLightOff.Min();
            this.BackLightOff_averagewatt = this.Watts_BackLightOff.Average();
            this.BackLightOn_wattcount = this.Watts_BackLightOn.Count;
            this.BackLightOn_maxwatt = this.Watts_BackLightOn.Max();
            this.BackLightOn_minwatt = this.Watts_BackLightOn.Min();
            this.BackLightOn_averagewatt = this.Watts_BackLightOn.Average();
        }
        private void DoStatistics()
        {
            InitializeLists();
            Calculate_BackLightOnOff();
            FindBackLightOnOffStatistics();
           

        }

        private void AppendToSBToExport()
        {
            SB.AppendLine(this.FileName);
            SB.AppendLine(",Total,,,");
            SB.AppendLine(",,MAX WATT, MIN WATT, AVERAGE WATT, # of Readings");
            SB.AppendLine(",,"+this.maxwatt + "," + this.minwatt + "," + this.averagewatt + "," + this.wattcount);
            SB.AppendLine(",,,,,,");
            SB.AppendLine(",Backlight On,,,");
            SB.AppendLine(",,MAX WATT , MIN WATT, AVERAGE WATT, # of Readings");
            SB.AppendLine(",," + this.BackLightOn_maxwatt + "," + this.BackLightOn_minwatt + "," + this.BackLightOn_averagewatt + "," + this.BackLightOn_wattcount);
            SB.AppendLine(",,,,,");
            SB.AppendLine(",Backlight Off,,,");
            SB.AppendLine(",,MAX WATT , MIN WATT, AVERAGE WATT, # of Readings");
            SB.AppendLine(",," + this.BackLightOff_maxwatt + "," + this.BackLightOff_minwatt + "," + this.BackLightOff_averagewatt + "," + this.BackLightOff_wattcount);
            SB.AppendLine(",,,,,");
            SB.AppendLine(",,,,,");
            SB.AppendLine(",,,,,");
            SB.AppendLine(",,,,,");
            SB.AppendLine(",,,,,");

        }

        private void AppendToSBToExportSingleFile()
        {
            SB.AppendLine("IdelBackLightOffAvg," + this.textBoxIdelBackLightOffAvg.Text+ ",,,,");
            SB.AppendLine("IdelBackLightOffAvg," + this.textBoxIdelBackLightOnAvg.Text + ",,,,");
            SB.AppendLine(",,,,,");
            SB.AppendLine(",,,,,");
            SB.AppendLine("Watts,Watts_Backlight On,Watts_Backlight Off,,,");
            for (int i=0;i<this.wattcount;i++)
            {
                SB.AppendLine(this.Watts[i].ToString()+","+this.Watts_BackLightOn[i].ToString()+","+this.Watts_BackLightOff[i].ToString()+",,,");

            }
        }

        private void ReadAllSelectedFiles()
        {
            for(int i= 0;i < this.comboBoxFilesList.Items.Count;i++)
            {
                ReadFile(this.comboBoxFilesList.Items[i].ToString());
                LoadWattsList(result.Tables[0].TableName);
                DoStatistics();
                AppendToSBToExport();
            }

                
                
        }

        private void textBoxIdelBackLightOffAvg_TextChanged(object sender, EventArgs e)
        {
            IdelBackLightOffAverage = double.Parse(this.textBoxIdelBackLightOffAvg.Text);
        }

        private void textBoxIdelBackLightOnAvg_TextChanged(object sender, EventArgs e)
        {
            this.IdelBackLightOnAverage = double.Parse(this.textBoxIdelBackLightOnAvg.Text);
        }

        private void buttonExportFilesReport_Click(object sender, EventArgs e)
        {
            if(this.comboBoxFilesList.Items.Count>0)
            { 
            ReadAllSelectedFiles();
            Writer = new StreamWriter("Summary_Statistics.csv", true);
            Writer.Write(SB);
            Writer.Close();
            SB.Clear();
            MessageBox.Show("Export is done.");
            }
        }

        private void buttonExportSeperateReport_Click(object sender, EventArgs e)
        {
            ExportEachFileInSingleReport();
        }
    }
}
