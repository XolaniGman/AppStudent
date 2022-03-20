using AppStudents.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
using System.Xml.Linq;


using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Automation;
using Infragistics.Documents.Excel;
using Infragistics.Windows.DataPresenter.ExcelExporter;
using NuGet.Protocol.Plugins;
using Syncfusion.XlsIO;

namespace AppStudents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataPresenterExcelExporter exporter = new DataPresenterExcelExporter();

        DataSet ds = new DataSet();

        //public List<Person> people = new List<Person>();
        public List<Gender> Genders = new List<Gender>();
        //public List<Province> Provinces = new List<Province>();
        //public List<Nationality> Nationalitys = new List<Nationality>();
        //public List<Ethic> Ethics = new List<Ethic>();
        //public List<City> Citys = new List<City>();
        //public List<Department> Departments = new List<Department>();


        string connetionString = "";

        string ConnectionXML = "";

        string Connection = "";
        string DataBase = "";
        string databaseLogin = "";


        List<Detail> peaple = new List<Detail>();

        List<Gender> genders = new List<Gender>();
        List<Province> provinces = new List<Province>();
        List<Nationality> nationalities = new List<Nationality>();
        List<EthickGroup> ethickGroups = new List<EthickGroup>();
        List<Title> Titles = new List<Title>();
        List<City> city = new List<City>();

        ComboboxTitleItem item = new ComboboxTitleItem();
        //private Microsoft.Office.Interop.Excel.Workbook WB;

        //public Microsoft.Office.Interop.Excel.Worksheet WS;
        //public Microsoft.Office.Interop.Excel.Application APP;
        //public Microsoft.Office.Interop.Excel.Range DRV;


        //public Microsoft.Office.Interop.Excel.Application excel;
        //public Microsoft.Office.Interop.Excel.Workbook workBook;
        //public Microsoft.Office.Interop.Excel.Worksheet workSheet;
        //public Microsoft.Office.Interop.Excel.Range cellRange;





        public MainWindow()
        {


            InitializeComponent();
            
            //CreateData();
            //BindComboBox();
            //UpdateBinding();
            // getConnection();
            //WriteExcel();
            populateTitleDropDown();
            populateGenderDropDown();
            populateCityDropDown();
            populateProvinceDropDown();
            populateNationalityDropDown();
            populateEthicGroupDropDown();


            //populateDetaillist();
            FillDataGrid();
            //CreateHeader();
            //InsertData();
            // Close();

            //DataAcces dataAccess = new DataAcces();

            //Microsoft.Office.Interop.Excel.Application excel;
            //Microsoft.Office.Interop.Excel.Workbook workBook;
            //Microsoft.Office.Interop.Excel.Worksheet workSheet;
            //Microsoft.Office.Interop.Excel.Range cellRange;


        }




        //public class MyExcel
        //{
        //    public Microsoft.Office.Interop.Excel.Application APP = null;
        //    public Microsoft.Office.Interop.Excel.Workbook WB = null;
        //    public Microsoft.Office.Interop.Excel.Worksheet WS = null;
        //    public Microsoft.Office.Interop.Excel.Range Range = null;
        //}
        public void MyExcel()
        {
            //////////T/////////////////// THIS IS 1ST METHOD //////////////////////////////////////////


            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2016;

            //Create a new workbook
            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet sheet = workbook.Worksheets[0];

            if (sheet.ListObjects.Count == 0)
            {
                //Estabilishing the connection in the worksheet
                string dBPath = System.IO.Path.GetFullPath(@"Server =.\LevelUpMedical; Database = LevelUpDrug; Trusted_Connection = True;");
                string ConnectionString = @"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;" + dBPath;
                string query = "SELECT ipkDrug, sType, sNappiCode, sDescription, fPackPrice,fPackSize, fSchedule,fListPrice,fCostPrice,sStrength,sValid OldPrice from Drug   ";
                Syncfusion.XlsIO.IConnection Connection = workbook.Connections.Add("Connection1", "Sample connection with MsAccess", ConnectionString, query, ExcelCommandType.Sql);
                sheet.ListObjects.AddEx(ExcelListObjectSourceType.SrcQuery, Connection, sheet.Range["A1"]);
            }

            //Refresh Excel table to get updated values from database
            //sheet.ListObjects[0].Refresh();

            sheet.UsedRange.AutofitColumns();

            //Save the file in the given path
            Stream excelStream = File.Create(System.IO.Path.GetFullPath(@"Output.xlsx"));
            workbook.SaveAs(excelStream);
            excelStream.Dispose();




            //exporter.ExportAsync(this.DataGrid1, "xamDataPresenter1.xlsx", WorkbookFormat.Excel2007);

            //Microsoft.Office.Interop.Excel.Application excel = null;
            //Microsoft.Office.Interop.Excel.Workbook wb = null;
            //object missing = Type.Missing;
            //Microsoft.Office.Interop.Excel.Worksheet ws = null;
            //Microsoft.Office.Interop.Excel.Range rng = null;

            //// collection of DataGrid Items
            //var DataGrid1 = ExcelTimeReport(txtFrmDte.Text, txtToDte.Text, OrCondition);

            //excel = new Microsoft.Office.Interop.Excel.Application();
            //wb = excel.Workbooks.Add();
            //ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
            //ws.Columns.AutoFit();
            //ws.Columns.EntireColumn.ColumnWidth = 25;

            //// Header row
            //for (int Idx = 0; Idx < DataGrid1.Columns.Count; Idx++)
            //{
            //    ws.Range["A1"].Offset[0, Idx].Value = DataGrid1.Columns[Idx].ColumnName;
            //}

            //// Data Rows
            //for (int Idx = 0; Idx < DataGrid1.Rows.Count; Idx++)
            //{
            //    ws.Range["A2"].Offset[Idx].Resize[1, DataGrid1.Columns.Count].Value = DataGrid1.Rows[Idx].ItemArray;
            //}

            //excel.Visible = true;
            //wb.Activate();



            //string fileName, txtFileName = "Book1";
            //Spire.DataExport.XLS.CellExport cellExport = new Spire.DataExport.XLS.CellExport();
            //Spire.DataExport.XLS.WorkSheet Sheet1 = new Spire.DataExport.XLS.WorkSheet();
            //Sheet1.DataSource = Spire.DataExport.Common.ExportSource.DataTable;
            //Sheet1.DataTable = DataGrid1.ItemsSource as DataTable;
            //Sheet1.StartDataCol = ((System.Byte)(0));
            //cellExport.Sheets.Add(Sheet1);
            //cellExport.ActionAfterExport = Spire.DataExport.Common.ActionType.OpenView;
            //fileName = txtFileName.ToString() + ".xlsx";
            //cellExport.SaveToFile("Book1");

            //DataGrid1.SelectAllCells();
            //DataGrid1.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            //ApplicationCommands.Copy.Execute(null, DataGrid1);
            //String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            //String result = (string)Clipboard.GetData(DataFormats.Text);
            //DataGrid1.UnselectAllCells();
            //System.IO.StreamWriter Sheet1 = new System.IO.StreamWriter(@"C:\Users\user\Book1.xlsx");
            //Sheet1.WriteLine(result.Replace(',', ' '));
            //Sheet1.Close();

            //MessageBox.Show(" Exporting DataGrid data to Excel file created.xls");





            //        using 
            //        {
            //            IApplication application = excelEngine.Excel;
            //    application.DefaultVersion = ExcelVersion.Excel2016;

            //            //Create a new workbook 
            //            IWorkbook workbook = application.Workbooks.Create(1);
            //    IWorksheet sheet = workbook.Worksheets[0];

            //            if (sheet.ListObjects.Count == 0)
            //            {
            //                //Estabilishing the connection in the worksheet 
            //                string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password = myPassword";

            //    string query = "SELECT * FROM Employees";

            //    IConnection connection = workbook.Connections.Add("SQLConnection", "Sample connection with SQL Server", connectionString, query, ExcelCommandType.Sql);

            //    //Create Excel table from external connection. 
            //    sheet.ListObjects.AddEx(ExcelListObjectSourceType.SrcQuery, connection, sheet.Range["A1"]);
            //            }

            ////Refresh Excel table to get updated values from database 
            //sheet.ListObjects[0].Refresh();

            //sheet.UsedRange.AutofitColumns();

            //            //Save the file in the given path 
            //            Stream excelStream = File.Create(Path.GetFullPath(@"Output.xlsx"));

            //workbook.SaveAs(excelStream);
            //            excelStream.Dispose();
            //        }

            //    }

        }










        //        using 
        //        {
        //            IApplication application = excelEngine.Excel;
        //    application.DefaultVersion = ExcelVersion.Excel2016;

        //            //Create a new workbook 
        //            IWorkbook workbook = application.Workbooks.Create(1);
        //    IWorksheet sheet = workbook.Worksheets[0];

        //            if (sheet.ListObjects.Count == 0)
        //            {
        //                //Estabilishing the connection in the worksheet 
        //                string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password = myPassword";

        //    string query = "SELECT * FROM Employees";

        //    IConnection connection = workbook.Connections.Add("SQLConnection", "Sample connection with SQL Server", connectionString, query, ExcelCommandType.Sql);

        //    //Create Excel table from external connection. 
        //    sheet.ListObjects.AddEx(ExcelListObjectSourceType.SrcQuery, connection, sheet.Range["A1"]);
        //            }

        ////Refresh Excel table to get updated values from database 
        //sheet.ListObjects[0].Refresh();

        //sheet.UsedRange.AutofitColumns();

        //            //Save the file in the given path 
        //            Stream excelStream = File.Create(Path.GetFullPath(@"Output.xlsx"));

        //workbook.SaveAs(excelStream);
        //            excelStream.Dispose();
        //        }

        //    }
        private void Excel(object sender, RoutedEventArgs e)
        {

            MyExcel();
          

        }




        private void UpdateBinding()
        {
            //listBox2.DataContext = peaple;

        }




        public class ComboboxTitleItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }




        public void populateTitleDropDown()
        {
            using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

            connection.Open();

            myComboBox6.Items.Clear();

            string Tariff = myComboBox6.Text.Trim();

            string sql = "";

            sql = " SELECT TitleNames ,TitleID from Title  ";


            connetionString = @"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;";


            using (SqlConnection cnn = new SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;"))
            {
                cnn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(" SELECT TitleNames from Title  ", cnn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow dataRow in dt.Rows)
                    {
                        myComboBox6.Items.Add(dataRow["TitleNames"].ToString());
                    }
                }
            }


        }



        public void populateCityDropDown()
        {
            using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

            connection.Open();

            myComboBox4.Items.Clear();

            string Tariff = myComboBox4.Text.Trim();

            string sql = "";

            sql = " SELECT CityNames ,CityID from City  ";


            connetionString = @"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;";



            using (SqlConnection cnn = new SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;"))
            {
                cnn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(" SELECT CityNames from City  ", cnn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow dataRow in dt.Rows)
                    {
                        myComboBox4.Items.Add(dataRow["CityNames"].ToString());
                    }
                }
            }


        }





        public void populateGenderDropDown()
        {
            using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

            connection.Open();

            myComboBox.Items.Clear();

            string Tariff = myComboBox.Text.Trim();

            string sql = "";

            sql = " SELECT GenderNames ,GenderID from Gender  ";


            connetionString = @"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;";



            using (SqlConnection cnn = new SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;"))
            {
                cnn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(" SELECT GenderNames from Gender  ", cnn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow dataRow in dt.Rows)
                    {
                        myComboBox.Items.Add(dataRow["GenderNames"].ToString());
                    }
                }
            }


        }


        public void populateProvinceDropDown()
        {
            using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

            connection.Open();

            myComboBox3.Items.Clear();

            string Tariff = myComboBox3.Text.Trim();

            string sql = "";

            sql = " SELECT ProvinceNames ,ProvinceID from Province  ";


            connetionString = @"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;";



            using (SqlConnection cnn = new SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;"))
            {
                cnn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(" SELECT ProvinceNames from Province  ", cnn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow dataRow in dt.Rows)
                    {
                        myComboBox3.Items.Add(dataRow["ProvinceNames"].ToString());
                    }
                }
            }


        }

        public void populateEthicGroupDropDown()
        {
            using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

            connection.Open();

            myComboBox2.Items.Clear();

            string Tariff = myComboBox2.Text.Trim();

            string sql = "";

            sql = " SELECT EthicGroupNames ,EthicGroupID from EthicGroup  ";


            connetionString = @"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;";



            using (SqlConnection cnn = new SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;"))
            {
                cnn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(" SELECT EthicGroupNames from EthicGroup  ", cnn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow dataRow in dt.Rows)
                    {
                        myComboBox2.Items.Add(dataRow["EthicGroupNames"].ToString());
                    }
                }
            }


        }



        public void populateNationalityDropDown()
        {
            using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

            connection.Open();

            myComboBox1.Items.Clear();

            string Tariff = myComboBox1.Text.Trim();

            string sql = "";

            sql = " SELECT NationalityNames ,NationalityID from Nationality  ";


            connetionString = @"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;";



            using (SqlConnection cnn = new SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;"))
            {
                cnn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(" SELECT NationalityNames from Nationality  ", cnn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow dataRow in dt.Rows)
                    {
                        myComboBox1.Items.Add(dataRow["NationalityNames"].ToString());
                    }
                }
            }


        }



        //public void populateDetaillist()
        //{
        //    using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

        //    connection.Open();

        //    DataGrid1.Items.Clear();

        //    //string Tariff = listBox1.Text.Trim();

        //    string sql = "";

        //    sql = " SELECT  FirstNames, LastNames, IDNos, emailAddress from Detail ";


        //    connetionString = @"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;";



        //    using (SqlConnection cnn = new SqlConnection(@"Server =.\LevelUpMedical; Database = LevelUpDrugs; Trusted_Connection = True;"))
        //    {
        //        cnn.Open();
        //        using (SqlDataAdapter sda = new SqlDataAdapter(" SELECT ipkDrug, sType, sNappiCode, sDescription, fPackPrice,fPackSize, fSchedule,fListPrice,fCostPrice,sStrength,sValid OldPrice from Drug   ", cnn))
        //        {
        //            DataTable dt = new DataTable();
        //            sda.Fill(dt);

        //            foreach (DataRow dataRow in dt.Rows)
        //            {

        //                DataGrid1.Items.Add(dt);

        //                //    DataGrid1.Items.Add(dataRow["FirstNames"].ToString());
        //                //    DataGrid1.Items.Add(dataRow["lastNames"].ToString());
        //                //    DataGrid1.Items.Add(dataRow["IDNos"].ToString());
        //                //    DataGrid1.Items.Add(dataRow["emailAdress"].ToString());
        //            }
        //        }
        //    }


        //}


        private void FillDataGrid()
        {


            using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LevelUpDrugs; Trusted_Connection = True;");

            connection.Open();

            //listBox2.Items.Clear();

            //string Tariff = myComboBox1.Text.Trim();

            string sql = "";

            sql = " SELECT ipkDrug ,sNappiCode ,sDescription from Drug    ";


            connetionString = @"Server =.\LevelUpMedical; Database = LevelUpDrugs; Trusted_Connection = True;";



            string CmdString = string.Empty;
            using (SqlConnection cnn = new SqlConnection(@"Server =.\LevelUpMedical; Database = LevelUpDrugs; Trusted_Connection = True;"))
            {
                cnn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(" SELECT ipkDrug, sType, sNappiCode, sDescription, fPackPrice,fPackSize, fSchedule,fListPrice,fCostPrice,sStrength,sValid OldPrice from Drug   ", cnn))
                {
                    DataTable dt = new DataTable("Drug");
                    sda.Fill(dt);
                    DataGrid1.ItemsSource = dt.DefaultView;
                }
            }


        }

        //public void WriteExcel()
        //{
        //    using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LevelUpDrugs; Trusted_Connection = True;");

        //    connection.Open();

        //    //listBox2.Items.Clear();

        //    //string Tariff = myComboBox1.Text.Trim();

        //    string sql = "";

        //    sql = " SELECT ipkDrug ,sNappiCode ,sDescription from Drug    ";


        //    connetionString = @"Server =.\LevelUpMedical; Database = LevelUpDrugs; Trusted_Connection = True;";



        //    using (SqlConnection cnn = new SqlConnection(@"Server =.\LevelUpMedical; Database = LevelUpDrugs; Trusted_Connection = True;"))
        //    {
        //        cnn.Open();
        //        using (SqlDataAdapter sda = new SqlDataAdapter(" SELECT ipkDrug ,sNappiCode ,sDescription from Drug  ", cnn))
        //        {
        //            DataTable dt = new DataTable();
        //            sda.Fill(dt);

        //            foreach (DataRow dataRow in dt.Rows)
        //            {
        //                listBox2.Items.Add(dataRow["sDescription"].ToString());
        //            }
        //        }
        //    }






        //}










        private void getConnection()
        {
            XDocument xml;

            try
            {
                ConnectionXML = File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + @"\XMLFile1.xml", Encoding.UTF8);

                xml = XDocument.Parse(ConnectionXML);

                var emptyElements = xml.Descendants("configuration");

                foreach (var xe in emptyElements)   // '**MUKESH**   30/10/2020    For Logs       
                {
                    try
                    {
                        var DataT = xe.Element("connectionStrings");
                        if (DataT != null)
                        {
                            Connection = xe.Element("connectionStrings").Value.ToString() + "";
                        }
                        else
                        {
                            Connection = "0";
                        }
                    }
                    catch (Exception)
                    {
                        Connection = "0";
                    }
                    try
                    {
                        var DataB = xe.Element("DataSource");
                        if (DataB != null)
                        {
                            DataBase = xe.Element("DataSource").Value.ToString() + "";
                        }
                        else
                        {
                            DataBase = "0";
                        }
                    }
                    catch (Exception)
                    {
                        DataBase = "0";
                    }
                }

            }
            catch (Exception)
            {
                Connection = "0";
            }

            if (Connection == "0" || Connection.Trim() == "")
            {
                MessageBox.Show("Could Not Determine Connection Settings ");
            }
            else
            {
                databaseLogin = Connection;

                MessageBox.Show(databaseLogin);

            }

        }











        private void submitButton_click(object sender, RoutedEventArgs e)
        {
            //MyExcel();

            //using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

            //var Detail = new Detail();
            //var _DetailList = new List<Detail>();

            //connection.Open();

            //String sql = "INSERT INTO Detail(FirstNames,NationalityNames,IDNos,emailAddress)";

            //using (SqlCommand command = new SqlCommand(sql, connection))
            //{
            //    using (SqlDataReader Sender = command.ExecuteReader())
            //    {
            //        while (Sender.Read())
            //        {


            //            command.Parameters.AddWithValue("@FierstName", FirstNames);
            //            command.Parameters.AddWithValue("@Generations", Generations);
            //            command.Parameters.AddWithValue("@PopulationSize", PopulationSize);
            //            command.Parameters.AddWithValue("@MaxFitness", MaxFitness);

            //            Detail.FirstNames = Sender.GetString(0);
            //            Detail.LastNames = Sender.GetString(0);
            //            Detail.IDNos = Sender.GetString(0);
            //            Detail.emailAddress = Sender.GetString(0);



            //        }
            //        _DetailList.Add(Detail);
            //    }

            //}





        }





        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private class excelEngine
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workBook;
            Microsoft.Office.Interop.Excel.Worksheet workSheet;
            Microsoft.Office.Interop.Excel.Range cellRange;

            public static IApplication Excel { get; internal set; }
        }














        //Province province = new Province();
        //City city = new City();
        //EthickGroup ethickGroup = new EthickGroup();
        //Student student = new Student();
        //MessageBox.Show($"Hellow { firstNametext.Text} " +
        //    $"{ LastNametext.Text}" +
        //    $"{ ID.Text}" +
        //    $"{ EmailAddress.Text}" 


        //);
    }

}


public class City
{
    public string CityName { get; set; }
}

public class Title
{

    public int TitleID { get; set; }
    public string TitleName { get; set; }
}

public class EthicGroup
{
    public int EthicGroupID { get; set; }
    public string EthicGroupNames { get; set; }
}

public class Nationality
{
    public int NationalityID { get; set; }
    public string NationalityName { get; set; }
}
public class Province
{
    public int ProvinceID { get; set; }
    public string ProvinceNames { get; set; }
}

public class Gender
{

    public int GenderID { get; set; }
    public string GenderNames { get; set; }


}
// public class Student
//{
//    public int Id { get; set; }
//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//    public string IDNo { get; set; }
//    public string Email { get; set; }
//}

public class Detail
{
    public int DetailsID { get; set; }
    public string FirstNames { get; set; }
    public string LastNames { get; set; }
    public string IDNos { get; set; }
    public string EmailAddress { get; set; }

}


public class Drug
{
    public int ipkDrug { get; set; }
    public string sType { get; set; }
    public string sNappiCode { get; set; }
    public string sDescription { get; set; }
    public double fPackPrice { get; set; }
    public string sStrength { get; set; }
    public double fPackSize { get; set; }
    public double fSchedule { get; set; }
    public double fListPrice { get; set; }
    public double fCostPrice { get; set; }
    public string sValid { get; set; }
    public double OldPrice { get; set; }

}


