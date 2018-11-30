using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ex32
{
    class Program
    {
        private static string connectionString = "Server=EALSQL1.eal.local; Database= Ex31Klinik; User Id= C_STUDENT18; Password= C_OPENDB18";
        static void Main(string[] args)
        {
            Program prog = new Ex32.Program();
            Console.WriteLine("tryk 1 for at indsætte adresse");
            Console.WriteLine("tryk 2 for at visa aftala fa patiant");
            string menuValg = Console.ReadLine();
            if (menuValg == "1")
            {
                prog.IndsætAdresse();
            }
            else if (menuValg == "2")
            {
                prog.VisAftalerForPatient();
            }
            else
            {
                Console.WriteLine("fejl i input, Prøv igen");
            }
        }
        private void IndsætAdresse()
        {
            Console.WriteLine("Input gade");
            string gade = Console.ReadLine();
            Console.WriteLine("Input husnummer");
            string husNummer = Console.ReadLine();
            Console.WriteLine("Input postnummer");
            string postNummer = Console.ReadLine();


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("IndsætAdresse", con);
                    cmd1.CommandType = CommandType.StoredProcedure;


                    cmd1.Parameters.Add(new SqlParameter("@Gade", gade));
                    cmd1.Parameters.Add(new SqlParameter("@HusNr", husNummer));
                    cmd1.Parameters.Add(new SqlParameter("@PostNr", postNummer));


                    cmd1.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ups" + e.Message);
                }
            }
        }
        private void VisAftalerForPatient()
        {
            Console.WriteLine("Indsæt patient ID");
            int patientId = int.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("VisAftalerForPatient", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@PatientId", patientId));

                    SqlDataReader reader = cmd2.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string id = reader["Id"].ToString();
                            string læge = reader["Læge"].ToString();
                            string klinikAdresse = reader["KlinikAdresse"].ToString();
                            string patient = reader["Patient"].ToString();
                            string pårørende = reader["Pårørende"].ToString();
                            string dato = reader["Dato"].ToString();
                            string tidspunkt = reader["Tidspunkt"].ToString();

                            Console.WriteLine(id + " " + læge + " " + klinikAdresse + " " + patient + " " + pårørende + " " + dato + " " + tidspunkt + " ");
                            //cmd1.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ups" + e.Message);
                }
            }

        }
    }
}

//string id = reader["Id"].ToString();
//string læge = reader["Læge"].ToString();
//string klinikAdresse = reader["KlinikAdresse"].ToString();
//string patient = reader["Patient"].ToString();
//string pårørende = reader["Pårørenede"].ToString();
//string dato = reader["Dato"].ToString();
//string tidspunkt = reader["Tidspunkt"].ToString();

//                    if (reader.HasRows)
//                    {


//                        while (reader.Read())
//                        {
//                            string petName = reader["petName"].ToString();
//                            string petType = reader["petType"].ToString();
//                            string petBreed = reader["petBreed"].ToString();
//                            string petDOB = reader["petDOB"].ToString();
//                            string petWeight = reader["petWeight"].ToString();
//                            string ownerID = reader["ownerID"].ToString();

//                            Console.WriteLine(petName + " " + petType + " " + petBreed + " " + petDOB + " " + petWeight + " " + ownerID);

//                        }
//                    }

//        static void Main(string[] args)
//        {
//            Program prog = new Ex28.Program();
//            Console.WriteLine("tryk 1 for InsertPet");
//            Console.WriteLine("tryk 2 for vis alle dyr");
//            string menuValg = Console.ReadLine();
//            if (menuValg == "1")
//            {
//                prog.Run();
//            }
//            else if (menuValg == "2")
//            {
//                prog.ShowPets();
//            }
//            else
//            {
//                Console.WriteLine("fejl i input, Prøv igen");
//            }

//        }


//        private void Run()
//        {
//            Console.WriteLine("Input name");
//            string petName = Console.ReadLine();
//            Console.WriteLine("Input Type");
//            string petType = Console.ReadLine();
//            Console.WriteLine("Input Breed");
//            string petBreed = Console.ReadLine();
//            Console.WriteLine("input DOB dd/mm/yy");
//            string petDOB = Console.ReadLine();
//            Console.WriteLine("input Weight");
//            string petWeight = Console.ReadLine();
//            Console.WriteLine("Input ownerID 1-4");
//            string ownerID = Console.ReadLine();

//            using (SqlConnection con = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    con.Open();
//                    SqlCommand cmd1 = new SqlCommand("InsertPet", con);
//                    cmd1.CommandType = CommandType.StoredProcedure;


//                    cmd1.Parameters.Add(new SqlParameter("@PetName", petName));
//                    cmd1.Parameters.Add(new SqlParameter("@PetType", petType));
//                    cmd1.Parameters.Add(new SqlParameter("@PetBreed", petBreed));
//                    cmd1.Parameters.Add(new SqlParameter("@PetDOB", petDOB));
//                    cmd1.Parameters.Add(new SqlParameter("@PetWeight", petWeight));
//                    cmd1.Parameters.Add(new SqlParameter("@OwnerID", ownerID));

//                    cmd1.ExecuteNonQuery();
//                }
//                catch (SqlException e)
//                {
//                    Console.WriteLine("ups" + e.Message);
//                }
//            }
//        }
//        private void ShowPets()
//        {
//            using (SqlConnection con = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    con.Open();
//                    SqlCommand cmd2 = new SqlCommand("GetPets", con);
//                    cmd2.CommandType = CommandType.StoredProcedure;


//                    SqlDataReader reader = cmd2.ExecuteReader();

//                    if (reader.HasRows)
//                    {


//                        while (reader.Read())
//                        {
//                            string petName = reader["petName"].ToString();
//                            string petType = reader["petType"].ToString();
//                            string petBreed = reader["petBreed"].ToString();
//                            string petDOB = reader["petDOB"].ToString();
//                            string petWeight = reader["petWeight"].ToString();
//                            string ownerID = reader["ownerID"].ToString();

//                            Console.WriteLine(petName + " " + petType + " " + petBreed + " " + petDOB + " " + petWeight + " " + ownerID);

//                        }
//                    }
//                }
//                catch (SqlException e)
//                {
//                    Console.WriteLine("ups" + e.Message);
//                }
//            }


//        }
//    }
//}