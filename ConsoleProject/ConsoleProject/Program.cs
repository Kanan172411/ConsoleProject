using ConsoleProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResoruceManager humanResoruceManager = new HumanResoruceManager();
            do
            {
                Console.WriteLine("Etmek istediyiniz emeliyyati secin(1.1 , 1.2 , 1.3 ...)\n ");
                Console.WriteLine("1.1 : Departamentler siyahisini goster");
                Console.WriteLine("1.2 : Yeni departament yarat ");
                Console.WriteLine("1.3 : Movcud olan Departamentde deyisiklik et");
                Console.WriteLine("2.1 : Sistemdeki butun iscilerin nomre, ad soyad, departament adi ve maas deyerlerini goster ");
                Console.WriteLine("2.2 : Her hansi departamentdeki iscilerin nomre, ad soyad, departament adi ve maas deyerlerini goster ");
                Console.WriteLine("2.3 : Yeni isci elave et");
                Console.WriteLine("2.4 : Her hansi isci uzerinde deyisiklik et");
                Console.WriteLine("2.5 : Her hansi departamentden isci sil");
                Console.WriteLine("3   : Sistemden cixis \n");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1.1": 
                        ShowDepartments(ref humanResoruceManager);
                        break;
                    case "1.2": 
                        AddDepartment(ref humanResoruceManager);
                        break;
                    case "1.3": 
                        EditDEpartment(ref humanResoruceManager);
                        break;
                    case "2.1": 
                        ShowAllEmploye(ref humanResoruceManager);
                        break;
                    case "2.2": 
                        GetEmployyeWithDEpartmentName(ref humanResoruceManager);
                        break;
                    case "2.3":
                        AddEmployee(ref humanResoruceManager);
                        break;
                    case "2.4": 
                        Editemployee(ref humanResoruceManager);
                        break;
                    case "2.5": 
                        RemoveEmployee(ref humanResoruceManager);
                        break;
                    case "3":
                        Console.WriteLine("Sistemden cixildi\n");
                        return;
                    default:
                        Console.WriteLine("Secdiyiniz emeliyyat movcud deyil \n");
                        break;
                }
            } while (true);
        }
        static void AddDepartment(ref HumanResoruceManager humanResoruceManager)
        {
            Console.WriteLine("Departament adini daxil edin (Departament)");
            string str = Console.ReadLine();
            int num1;
            int num2;
            string num1str;
            string num2str;
            if (!CheckDepartmentName(str))
            {
                do
                {
                    Console.WriteLine("Departament adini duzgun formatda daxil edin");
                    str = Console.ReadLine();

                } while (!CheckDepartmentName(str));
            }
            if (humanResoruceManager.FindDepartmentWithName(str) != null)
            {
                Console.WriteLine($"{str} adinda departament artiq movcuddur");
                return;
            }
            do
            {
                Console.WriteLine("Departamentin isci limitini teyin edin (minimum 1)");
                num1str = Console.ReadLine();
            } while (!int.TryParse(num1str,out num1) || num1<0 );
            do
            {
                Console.WriteLine("Departamentin maas limitini teyin edin (minimum 250)");
                num2str = Console.ReadLine();
            } while (!int.TryParse(num2str, out num2) || num2 < 250);
            humanResoruceManager.AddDepartment(str, num1, num2);
        } 
        static void ShowDepartments(ref HumanResoruceManager humanResoruceManager)
        {
            if (humanResoruceManager.Departments.Length>0)
            {
                Console.WriteLine("============================================DEPARTAMENTLER=============================================");
                foreach (var item in humanResoruceManager.Departments)
                {
                    Console.WriteLine($"Ad : {item.SetDepartmentName} ||| Isci limiti : {item.SetWorkerLimit} ||| Maas limiti : {item.SetSalaryLimit}");
                }
                Console.WriteLine("=======================================================================================================");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Sistemde departament movcud deyil\n");
            }
        }
        static void EditDEpartment(ref HumanResoruceManager humanResoruceManager)
        {
            Console.WriteLine("Deyismek istediyiniz departamentin adini daxil edin:");
            string departmentname = Console.ReadLine();
            
            if (humanResoruceManager.FindDepartmentWithName(departmentname) == null)
            {
                Console.WriteLine($"{departmentname} adli departament movcud deyil!\n");
                return;
            }

            Console.WriteLine("Departamentin yeni adini daxil edin");
            string newDepartmentName = Console.ReadLine();

            if (humanResoruceManager.FindDepartmentWithName(newDepartmentName) != null)
            {
                Console.WriteLine($"{newDepartmentName} adli departament artiq movcuddur!\n");
                return;
            }
            humanResoruceManager.EditDepartment(departmentname, newDepartmentName);
        }
        static void AddEmployee (ref HumanResoruceManager humanResoruceManager) 
        {
            Console.WriteLine("Iscini daxil etmek istediniz departament adini daxil edin");
            string str2 = Console.ReadLine();
            if (humanResoruceManager.FindDepartmentWithName(str2) == null)
            {
                Console.WriteLine($"{str2} adinda departament movcud deyil");
                return;
            }
            string str;
            string str1;
            string num1str;
            int num1;
            do
            {
                Console.WriteLine("Iscinin ad ve soyadini daxil edin (Kenan Qarazade)");
                str = Console.ReadLine();
            } while (!CheckFullname(str));
            do
            {
                Console.WriteLine("Iscinin vezifesini daxil edin (minimum 3 herf) ");
                str1 = Console.ReadLine();
            } while (str1.Length < 3);
            do
            {
                Console.WriteLine("Iscinin maasini daxil edin (minimum 250)");
                num1str = Console.ReadLine();
            } while (!int.TryParse(num1str, out num1) || num1 < 250) ;
            humanResoruceManager.AddEmploye(str, str1, num1, str2);
        }
        static void ShowAllEmploye(ref HumanResoruceManager humanResoruceManager)
        {
            if (humanResoruceManager.GetAllEmployees().Length == 0)
            {
                Console.WriteLine("Sistemde isci movcud deyil");
            }
            else
            {
                Console.WriteLine("===========================================Isciler============================================");
                foreach (var item in humanResoruceManager.GetAllEmployees())
                {
                   Console.WriteLine($"Ad : {item.SetFullName} ||| Nomre : {item.SetNo} ||| Maas : {item.SetSalary} ||| Departamenti : {item.DepartmentName} ||| Vezifesi : {item.SetPosition}");
                }
                Console.WriteLine("==============================================================================================");
            }
        }
        static void GetEmployyeWithDEpartmentName(ref HumanResoruceManager humanResoruceManager)
        {
            Console.WriteLine("Departament adini daxil edin");
            string str = Console.ReadLine();
            if (humanResoruceManager.FindDepartmentWithName(str) == null)
            {
                Console.WriteLine($"{str} adinda departament movcud deyil");
                return;
            }
            if (humanResoruceManager.GetEmployyeWithDEpartmentName(str) == null)
            {
                Console.WriteLine($"{str} departamentinde isci movcud deyil");
            }
            else
            {
                Console.WriteLine("==========================================Isciler=================================================");
                foreach (var item in humanResoruceManager.GetEmployyeWithDEpartmentName(str))
                {
                    Console.WriteLine($"Ad : {item.SetFullName} ||| Nomre : {item.SetNo} ||| Maas : {item.SetSalary} ||| Departamenti : {item.DepartmentName} ||| Vezifesi : {item.SetPosition}");
                }
                Console.WriteLine("==================================================================================================");
            }
        }
        static void Editemployee(ref HumanResoruceManager humanResoruceManager)
        {
            Console.WriteLine("Uzerinde deyisiklik etmek istediyiniz iscinin hansi departamentden oldugunu daxil edin");
            string str = Console.ReadLine();
            if (humanResoruceManager.FindDepartmentWithName(str) == null)
            {
                Console.WriteLine($"{str} adinda departament movcud deyil");
                return;
            }
            if (humanResoruceManager.FindDepartmentWithName(str).employees.Length == 0)
            {
                Console.WriteLine($"{str} adinda departamentde isci movcud deyil");
                return;
            }
            Console.WriteLine("Uzerinde deyisiklik etmek istediyiniz iscinin nomresini daxil edin");
            string employeenumber = Console.ReadLine();
            for (int i = 0; i < humanResoruceManager.FindDepartmentWithName(str).employees.Length; i++)
            {
                if (humanResoruceManager.FindDepartmentWithName(str).employees[i].SetNo == employeenumber)
                {
                    string newposition;
                    int newsalary;
                    string newsalarystr;
                    Console.WriteLine($"Ad : {humanResoruceManager.FindDepartmentWithName(str).employees[i].SetFullName} ||| Nomre : {humanResoruceManager.FindDepartmentWithName(str).employees[i].SetNo} ||| Maas : {humanResoruceManager.FindDepartmentWithName(str).employees[i].SetSalary} ||| Departamenti : {humanResoruceManager.FindDepartmentWithName(str).employees[i].DepartmentName} ||| Vezifesi : {humanResoruceManager.FindDepartmentWithName(str).employees[i].SetPosition}");
                    do
                    {
                        Console.WriteLine("Iscinin yeni vezifesini teyin edin");
                        newposition = Console.ReadLine();
                    } while (newposition.Length < 3) ;
                    do
                    {
                        Console.WriteLine("Iscinin yeni maasini teyin edin");
                        newsalarystr = Console.ReadLine();
                    } while (!int.TryParse(newsalarystr, out newsalary) || newsalary < 250) ;
                    humanResoruceManager.EditEmployee(employeenumber, newposition, newsalary,str);
                    return;
                }
                else
                {
                    Console.WriteLine($"{employeenumber} nomreli isci sistemde movcud deyil");
                    return;
                }
            }
        }
        static void RemoveEmployee(ref HumanResoruceManager humanResoruceManager)
        {
            Console.WriteLine("Silmek istediyiniz iscinin hansi departamentden oldugunu daxil edin");
            string str = Console.ReadLine();
            if (humanResoruceManager.FindDepartmentWithName(str) == null)
            {
                Console.WriteLine($"{str} adinda departament movcud deyil");
                return;
            }
            if (humanResoruceManager.FindDepartmentWithName(str).employees.Length == 0)
            {
                Console.WriteLine($"{str} adinda departamentde isci movcud deyil");
                return;
            }
            Console.WriteLine("Silmek istediyiniz iscinin nomresini daxil edin");
            string str1 = Console.ReadLine();
            humanResoruceManager.RemoveEmployee(str, str1);
        }
        public static bool CheckDepartmentName(string str)
        {
            str = str.Trim();
            if (str.Length > 2 && char.IsUpper(str[0]))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsLetterOrDigit(str[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public static bool CheckFullname(string str)
        {
            str = str.Trim();
            string[] newstr = str.Split(" ");
            if (newstr.Length == 2)
            {
                bool check1 = false;
                bool check2 = false;
                bool check3 = false;
                for (int i = 0; i < newstr[0].Length; i++)
                {
                    if (char.IsLetter(newstr[0][i]))
                    {
                        check1 = true;
                    }
                }
                for (int i = 0; i < newstr[1].Length; i++)
                {
                    if (char.IsLetter(newstr[1][i]))
                    {
                        check2 = true;
                    }
                }
                if (char.IsUpper(newstr[0][0]) && char.IsUpper(newstr[1][0]) && newstr[0].Length > 2 && newstr[1].Length > 2)
                {
                    check3 = true;
                }
                bool result = check1 && check2 && check3;
                return result;
            } 
            else { return false; }
        }
    }
}
