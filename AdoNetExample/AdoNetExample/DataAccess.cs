using AdoNetExample.Models.UserModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace AdoNetExample
{
    public class DataAccess : IDataAccess
    {
        SQLiteConnection connection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");

        //Tablo oluşturma.
        //connection.Open();
        //SQLiteCommand command = new SQLiteCommand(@"CREATE TABLE User (Id INTEGER PRIMARY KEY AUTOINCREMENT , Name varchar(30) , Surname varchar(30))", connection);

        //command.ExecuteNonQuery();
        //connection.Close();

        //Tabloya yeni column ekleme


        public void add(StudentModel studentModel)
        {
            SQLiteCommand command = new SQLiteCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "INSERT INTO User(Name,Surname,UserType) VALUES ('" + studentModel.Name + "','" + studentModel.Surname + "','" + studentModel.UserTypeEnum + "')";
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void addColumn()
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = connection;
            command.CommandText = "ALTER TABLE User ADD COLUMN UserType INTEGER";
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void delete(int selectedId)
        {
            SQLiteCommand command = new SQLiteCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "DELETE FROM User WHERE Id=" + selectedId + "";
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void getAll()
        {
            int counter = 0;
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM User", connection);
            connection.Open();
            SQLiteDataReader dataReader;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                counter++;
                Console.WriteLine(dataReader[0] + "," + dataReader[1] + "," + dataReader[2] + "," + dataReader[3]);
            }
            connection.Close();
        }

        public void getById(int selectedId)
        {
            int counter = 0;
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM User WHERE Id=" + selectedId + "", connection);
            connection.Open();
            SQLiteDataReader dataReader;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                counter++;
                Console.WriteLine(dataReader[0] + "," + dataReader[1] + "," + dataReader[2]);
            }
            connection.Close();
        }

        public void getByUserType(int selectedType)
        {
            int counter = 0;
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM User WHERE UserType=" + selectedType + "", connection);
            connection.Open();
            SQLiteDataReader dataReader;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                counter++;
                Console.WriteLine(dataReader[0] + "," + dataReader[1] + "," + dataReader[2]);
            }
            connection.Close();
        }

        public void update(int selectedId, StudentModel studentModel)
        {
            SQLiteCommand command = new SQLiteCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "UPDATE User SET Name='" + studentModel.Name + "',Surname='" + studentModel.Surname + "',UserType='" + (int)studentModel.UserTypeEnum + "' WHERE Id=" + selectedId + "";
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
