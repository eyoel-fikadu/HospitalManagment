using HospitalBedManagment.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBedManagment.Controller
{
    public class Connection
    {
        public string ConnectionString;
        string serverIp = "localhost";
        string username = "root";
        string password = "123456";
        string databaseName = "hospitalbedmanagment";

        string dbConnectionString;
        public static MySqlConnection con;
        public List<Lookup> AllLookUp;

        public Connection()
        {
            dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
            con = new MySqlConnection(dbConnectionString);
            AllLookUp = GetAllLookups();
        }

        public List<Person> GetAllPerson()
        {
            try
            {
                con.Open();
                List<Person> allPerson = new List<Person>();
                var cmd = new MySqlCommand("select * from Person", con);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Person per = new Person();
                    per.Id = int.Parse(reader["idPerson"].ToString());
                    per.CardNumber = reader["cardNumber"].ToString();
                    per.FirstName = reader["firstName"].ToString();
                    per.CardNumber = reader["lastName"].ToString();
                    per.DateOfBirth = DateTime.Parse(reader["dateOfBirth"].ToString());
                    per.Gender = reader["gender"].ToString();
                    per.Address = reader["adress"].ToString();
                    per.PhoneNumber = reader["phoneNumber"].ToString();
                    per.AltPhoneNumber = reader["altPhoneNumber"].ToString();
                    per.Type = reader["type"].ToString();
                    allPerson.Add(per);
                }
                con.Close();
                return allPerson;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Lookup> GetAllLookups()
        {
            try
            {
                con.Open();
                List<Lookup> all = new List<Lookup>();
                var cmd = new MySqlCommand("select * from lookup", con);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Lookup lkup = new Lookup();
                    lkup.Id = int.Parse(reader["idLookup"].ToString());
                    lkup.Type = reader["type"].ToString();
                    lkup.Data = reader["data"].ToString();
                    lkup.Remark = reader["remark"].ToString();
                    all.Add(lkup);
                }
                con.Close();
                return all;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<CaseTeam> GetAllCastTeams()
        {
            try
            {
                con.Open();
                List<CaseTeam> all = new List<CaseTeam>();
                var cmd = new MySqlCommand("select * from caseTeam", con);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CaseTeam team = new CaseTeam();
                    team.Id = int.Parse(reader["idcaseteam"].ToString());
                    team.CaseTeamName = reader["caseteamName"].ToString();
                    all.Add(team);
                }
                con.Close();
                return all;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<BedInformation> GetAllBed()
        {
            try
            {
                con.Open();
                List<BedInformation> all = new List<BedInformation>();
                var cmd = new MySqlCommand("select * from bedinformation", con);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BedInformation bed = new BedInformation();
                    bed.Id = int.Parse(reader["idbedinformation"].ToString());
                    bed.BedNumber = reader["bedNumber"].ToString();
                    bed.Room = reader["room"].ToString();
                    all.Add(bed);
                }
                con.Close();
                return all;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<BedAssigned> GetAllAssignedBed()
        {
            try
            {
                con.Open();
                List<BedAssigned> all = new List<BedAssigned>();
                var cmd = new MySqlCommand("select * from assignedBeds", con);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BedAssigned bed = new BedAssigned();
                    bed.Id = int.Parse(reader["idassignedbeds"].ToString());
                    bed.PatientId = int.Parse(reader["patientId"].ToString());
                    bed.BedId = int.Parse(reader["idassignedbeds"].ToString());
                    bed.CaseTeam = int.Parse(reader["idassignedbeds"].ToString());
                    bed.StartDate = DateTime.Parse(reader["idassignedbeds"].ToString());
                    bed.EndDate = DateTime.Parse(reader["idassignedbeds"].ToString());
                    bed.isActive = bool.Parse(reader["isActive"].ToString());
                    bed.Remark = reader["room"].ToString();
                    all.Add(bed);
                }
                con.Close();
                return all;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<BedAssigned> GetActiveAssignedBed()
        {
            try
            {
                con.Open();
                List<BedAssigned> all = new List<BedAssigned>();
                var cmd = new MySqlCommand("select * from assignedBeds where isActive = '1'", con);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BedAssigned bed = new BedAssigned();
                    bed.Id = int.Parse(reader["idassignedbeds"].ToString());
                    bed.PatientId = int.Parse(reader["patientId"].ToString());
                    bed.BedId = int.Parse(reader["bedId"].ToString());
                    bed.CaseTeam = int.Parse(reader["caseTeamId"].ToString());
                    bed.StartDate = DateTime.Parse(reader["startDate"].ToString());
                    bed.EndDate = DateTime.Parse(reader["endDate"].ToString());
                    bed.isActive = int.Parse(reader["isActive"].ToString()) != 0;
                    bed.Remark = reader["remark"].ToString();
                    all.Add(bed);
                }
                con.Close();
                return all;
            }
            catch (Exception ex) { throw ex; }
        }

        public int InsertPerson(Person per)
        {
            try
            {
                String query = string.Format("INSERT INTO `person`(`cardNumber`,`firstName`,`lastName`,`dateOfBirth`,`gender`,`adress`,`phoneNumber`,`altPhoneNumber`,`type`,`reamrk`)VALUES" +
                    "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", per.CardNumber, per.FirstName, per.Lastname, per.DateOfBirth.ToString("yyyy/MM/dd"), per.Gender, per.Address, per.PhoneNumber, per.AltPhoneNumber, per.Type, per.Remark);

                con.Open();
                var cmd = new MySqlCommand(query, con);
               
                int val = cmd.ExecuteNonQuery();
                con.Close();
                return val;
            }
            catch (Exception ex) { throw ex; }
        }

        public int InsertBed(BedInformation bed)
        {
            try
            {
                String query = string.Format("INSERT INTO `bedinformation`(`bedNumber`,`roomNumber`,`reamrk`)VALUES" +
                    "('{0}','{1}','{2}')", bed.BedNumber, bed.Room, bed.Remark);

                con.Open();
                var cmd = new MySqlCommand(query, con);

                int val = cmd.ExecuteNonQuery();
                con.Close();
                return val;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
