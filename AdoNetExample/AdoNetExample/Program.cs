using AdoNetExample.Enums;
using AdoNetExample.Models.UserModels;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Xml.Linq;

namespace AdoNetExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Yapmak istediğiniz işlemi seçiniz !");
            Console.WriteLine("1: Ekleme işlemi.");
            Console.WriteLine("2: Tümünü getir.");
            Console.WriteLine("3: Silme İşlemi.");
            Console.WriteLine("4: Güncelleme İşlemi.");
            Console.WriteLine("5: Id ye göre veri getirme");
            Console.WriteLine("6: Kullanıcı tipine göre getirme.");
            int selection;
            selection = Convert.ToInt32(Console.ReadLine());
            DataAccess dataAccess = new DataAccess();
            StudentModel studentModel = new StudentModel();
            if (selection == 1)
            {
                string name;
                string surname;
                int enumType;
                Console.Write("İsim giriniz : ");
                name = Convert.ToString(Console.ReadLine());
                Console.Write("Soyisim Giriniz : ");
                surname = Convert.ToString(Console.ReadLine());
                Console.Write("Kullanıcı tipini giriniz : ");
                enumType = Convert.ToInt32(Console.ReadLine());
                studentModel.Name = name;
                studentModel.Surname = surname;
                var userTypeChange = (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), enumType.ToString());
                studentModel.UserTypeEnum = userTypeChange;
                Console.WriteLine(studentModel.UserTypeEnum);
                dataAccess.add(studentModel);
                Console.WriteLine("Ekleme işlemi başarılı.");
            }
            else if (selection == 2)
            {
                dataAccess.getAll();
            }
            else if (selection == 3)
            {
                int selectedUser;
                Console.Write("Silmek istediğiniz kullanıcının ID' si: ");
                selectedUser = Convert.ToInt32(Console.ReadLine());
                dataAccess.delete(selectedUser);
                Console.WriteLine("Silme işlemi başarılı.");
            }
            else if (selection == 4)
            {
                int selectedUser;
                string newName;
                string newSurname;
                int newUserType;

                Console.Write("Kullanıcı Id si giriniz: ");
                selectedUser = Convert.ToInt32(Console.ReadLine());
                Console.Write("Yeni değeri giriniz: ");
                newName = Convert.ToString(Console.ReadLine());
                Console.Write("Yeni değeri giriniz: ");
                newSurname = Convert.ToString(Console.ReadLine());
                Console.Write("Yeni değeri giriniz: ");
                newUserType = Convert.ToInt32(Console.ReadLine());

                studentModel.Name = newName;
                studentModel.Surname = newSurname;
                var userTypeChange = (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), newUserType.ToString());
                studentModel.UserTypeEnum = userTypeChange;

                dataAccess.update(selectedUser, studentModel);
                Console.WriteLine("Güncelleme işlemi başarılı.");
            }
            else if (selection == 5)
            {
                int selectedUser;
                Console.Write("ID giriniz : ");
                selectedUser = Convert.ToInt32(Console.ReadLine());
                dataAccess.getById(selectedUser);
            }
            else if (selection == 6)
            {
                int selectedUser;
                Console.Write("Kullnıcı tipi giriniz : ");
                selectedUser = Convert.ToInt32(Console.ReadLine());
                dataAccess.getById(selectedUser);
            }
            else if (selection == 7)
            {
                dataAccess.addColumn();
            }
        }
    }
}