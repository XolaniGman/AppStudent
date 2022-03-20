//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Controls;
//using Dapper;
//using NuGet.Protocol.Plugins;

//namespace AppStudents
//{
//    public class DataAcces
//    {

//        public List<Gender> GetDetails()
//        {
//            using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

//            // ($"Data Source=   Your-PC\\LevelUpMedical  ;Initial Catalog = LEVELUPdb ;User ID=sa;Password=Level123;MultipleActiveResultSets=True");
//            // string connString = @"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;";
//            //List<Detail> output = connection.Query<Detail>{
//            //    $"select * from Detail where LastName = '{LastName}'").ToList();
//            //    return output;
//            //}
//            var _Genders = new Gender();
//            var _GendersList = new List<Gender>();

    
            
//            connection.Open();

//            String sql = "SELECT GenderNames from Gender";

//            using (SqlCommand command = new SqlCommand(sql, connection))
//            {
//                using (SqlDataReader reader = command.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {

//                        _Genders.GenderNames = reader.GetString(0);

//                        _GendersList.Add(_Genders);


//                    }
                    
//                }
                
//            }
//            return _GendersList.ToList();
//        }

//        public List<Province> GetProvinces()
//        {
//            using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

//            var Province = new Province();
//            var _ProvinceList = new List<Province>();

//            connection.Open();

//            String sql = "SELECT ProvinceNames from Province";

//            using (SqlCommand command = new SqlCommand(sql, connection))
//            {
//                using (SqlDataReader reader = command.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        Province.ProvinceNames = reader.GetString(0);
//                        _ProvinceList.Add(Province);
//                    }
//                }
//                return _ProvinceList.ToList();
//            }
//        }

//        //    public List<City> GetCity()
//        //    {
//        //        using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

//        //        var City = new City();
//        //        var _CitysList = new List<City>();

//        //        connection.Open();

//        //        String sql = "SELECT CityNames from City";

//        //        using (SqlCommand command = new SqlCommand(sql, connection))
//        //        {
//        //            using (SqlDataReader reader = command.ExecuteReader())
//        //            {
//        //                while (reader.Read())
//        //                {

//        //                    City.CityName = reader.GetString(0);
//        //                    _CitysList.Add(City);
//        //                }

//        //            }



//        //            return _CitysList.ToList();
//        //        }



//        //    }

//        //public List<Title> GetTitle()
//        //{
//        //    using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

//        //    var Title = new Title();
//        //    var _TitleList = new List<Title>();

//        //    connection.Open();

//        //    String sql = "SELECT TitleNames from Title";

//        //    using (SqlCommand command = new SqlCommand(sql, connection))
//        //    {
//        //        using (SqlDataReader reader = command.ExecuteReader())
//        //        {
//        //            while (reader.Read())
//        //            {

//        //                Title.TitleName = reader.GetString(0);
//        //                _TitleList.Add(Title);
//        //            }

//        //        }



//        //        return _TitleList.ToList();
//        //    }



//        //}
       

//        public List<EthicGroup> GetEthicGroup()
//        {
//            using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

//            var EthicGroup = new EthicGroup();
//            var _EthicGroupList = new List<EthicGroup>();

//            connection.Open();

//            String sql = "SELECT EthicGroupNames from EthicGroup";

//            using (SqlCommand command = new SqlCommand(sql, connection))
//            {
//                using (SqlDataReader reader = command.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        EthicGroup.EthicGroupNames = reader.GetString(0);
//                        _EthicGroupList.Add(EthicGroup);
//                    }
//                }
//                return _EthicGroupList.ToList();
//            }
//        }

//        public List<City> GetCity()
//        {
//            using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

//            var City = new City();
//            var _CitysList = new List<City>();

//            connection.Open();
           
//                String sql = "SELECT CityNames from City";

//            using (SqlCommand command = new SqlCommand(sql, connection))
//            {

//                using (SqlDataReader reader = command.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        City.CityName = reader.GetString(0);
//                        _CitysList.Add(City);
//                    }
//                }
//                return _CitysList.ToList();

//            }
//        }



//        public List<Nationality> GetNationality()
//        {
//            using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

//            var Nationality = new Nationality();
//            var _NationalityList = new List<Nationality>();

//            connection.Open();

//            String sql = "SELECT NationalityNames from Nationality";

//            using (SqlCommand command = new SqlCommand(sql, connection))
//            {
//                using (SqlDataReader reader = command.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {

//                        Nationality.NationalityName = reader.GetString(0);
//                        _NationalityList.Add(Nationality);
//                    }

//                }
//                return _NationalityList.ToList();
//            }



//        }

//        public List<Detail> GetDetail()
//        {
//            using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

//            var Detail = new Detail();
//            var _DetailList = new List<Detail>();

//            connection.Open();

//            String sql = "Select * from Detail";

//            using (SqlCommand command = new SqlCommand(sql, connection))
//            {
//                using (SqlDataReader reader = command.ExecuteReader())
//                {
                    
                    
//                    while (reader.Read())
//                    {

//                        Detail.DetailsID = reader.GetInt32(0);
//                        Detail.FirstNames = reader.GetString(1);
//                        Detail.LastNames = reader.GetString(2);
//                        Detail.IDNos = reader.GetString(3); 
//                        Detail.emailAddress = reader.GetString(4);
                           
//                        _DetailList.Add(Detail);

//                    }
                    
//                }
//                return _DetailList.ToList();
//            }

//        }


//        public void InsertStudent( string FirstNames, string LastNames, string emailAddress, string IDNos)
//        {

//            using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

//            var Detail = new Detail();
//            var _DetailList = new List<Detail>();

//            connection.Open();

//            String sql = "INSERT INTO Detail(FirstNames,LastNames,IDNos,emailAddress)";

//            using (SqlCommand command = new SqlCommand(sql, connection))
//            {
              
//                        List<Detail> details = new List<Detail>();
//                        details.Add(new Detail { FirstNames = FirstNames, LastNames = LastNames, IDNos = IDNos, emailAddress = emailAddress });


                   
                
                
//            }
//            //return _DetailList.ToList();
//        }

//        public List<Detail> SearchDetails()
//        {
//            using System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(@"Server =.\LevelUpMedical; Database = LEVELUPdb; Trusted_Connection = True;");

//            var Detail = new Detail();
//            var _DetailList = new List<Detail>();

//            connection.Open();

//            String sql = "SELECT FirstNames from Detail";

//            using (SqlCommand command = new SqlCommand(sql, connection))
//            {
//                using (SqlDataReader reader = command.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        Detail.FirstNames = reader.GetString(0);
//                        _DetailList.Add(Detail);
//                    }
//                }
//                return _DetailList.ToList();
//            }
//        }

//    }
//}



