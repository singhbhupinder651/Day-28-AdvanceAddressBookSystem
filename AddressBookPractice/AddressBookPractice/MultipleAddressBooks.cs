using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Newtonsoft.Json;

namespace AddressBookPractice
{
    public class MultipleAddressBooks
    {

        private Dictionary<string, List<Contact>> addressBooksMap;
        private Dictionary<string, List<Contact>> cityAndPersonMap;
        private Dictionary<string, List<Contact>> stateAndPersonMap;

        public MultipleAddressBooks()
        {
            addressBooksMap = new Dictionary<string, List<Contact>>();
            cityAndPersonMap = new Dictionary<string, List<Contact>>();
            stateAndPersonMap= new Dictionary<string, List<Contact>>();
        }

        public void addAddressBook()
        {
            Console.WriteLine("Enter a name for new address book: ");
            string newAddressBookName = Console.ReadLine();

            if (newAddressBookName != null)
            {
                this.addressBooksMap.Add(newAddressBookName, new List<Contact>());
            }
        }

        public void addContact()
        {
            Console.WriteLine("Which address book do you want to add your contact to?");
            string targetAddressBook = Console.ReadLine();

            if (addressBooksMap.ContainsKey(targetAddressBook) && targetAddressBook != null)
            {
                Console.WriteLine("Enter first name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter second name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter address: ");
                string address = Console.ReadLine();
                Console.WriteLine("Enter city: ");
                string city = Console.ReadLine();
                Console.WriteLine("Enter state: ");
                string state = Console.ReadLine();
                Console.WriteLine("Enter zip: ");
                string zip = Console.ReadLine();
                Console.WriteLine("Enter phoneNumber: ");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter email: ");
                string email = Console.ReadLine();

                Contact contact = new Contact();
                contact.FirstName = firstName;
                contact.LastName = lastName;
                contact.Address = address;
                contact.City = city;
                contact.State = state;
                contact.Zip = zip;
                contact.PhoneNumber = phoneNumber;
                contact.Email = email;

                bool isPresent = false;
                List<Contact> checkList = addressBooksMap[targetAddressBook];
                bool result = checkList.Exists( e => e.Equals(contact) );
                if (!result)
                {
                    addressBooksMap[targetAddressBook].Add(contact);
                    Console.WriteLine("Contact added!");
                }
                else
                {
                    Console.WriteLine("Contact already exists in \"{0}\" address book, so not added!", targetAddressBook);
                }
            }
            else
            {
                Console.WriteLine("Address book doesn't exist");
            }

        }

        public void editContact()
        {
            Console.WriteLine("Enter the name of address book in which contact is saved:");
            string targetAddressBook = Console.ReadLine();

            if(addressBooksMap.ContainsKey(targetAddressBook) && targetAddressBook != null)
            {
                Console.WriteLine("Enter first name: ");
                string fName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                string lName = Console.ReadLine();

                for (int i = 0; i < addressBooksMap[targetAddressBook].Count; i++)
                {
                    Contact contact = addressBooksMap[targetAddressBook][i];
                    if (contact.FirstName == fName && contact.LastName == lName)
                    {
                        Console.WriteLine("Select one of the edit options below:");
                        Console.WriteLine("#1 - first name");
                        Console.WriteLine("#2 - last name");
                        Console.WriteLine("#3 - address");
                        Console.WriteLine("#4 - city");
                        Console.WriteLine("#5 - state");
                        Console.WriteLine("#6 - zip");
                        Console.WriteLine("#7 - phone number");
                        Console.WriteLine("#8 - email");
                        Console.WriteLine("Enter your choice: ");
                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                Console.WriteLine("Enter new first name: ");
                                addressBooksMap[targetAddressBook][i].FirstName = Console.ReadLine();
                                break;
                            case "2":
                                Console.WriteLine("Enter new last name: ");
                                contact.LastName = Console.ReadLine();
                                break;
                            case "3":
                                Console.WriteLine("Enter new address: ");
                                contact.Address = Console.ReadLine();
                                break;
                            case "4":
                                Console.WriteLine("Enter new city: ");
                                contact.City = Console.ReadLine();
                                break;
                            case "5":
                                Console.WriteLine("Enter new state: ");
                                contact.State = Console.ReadLine();
                                break;
                            case "6":
                                Console.WriteLine("Enter new zip: ");
                                contact.Zip = Console.ReadLine();
                                break;
                            case "7":
                                Console.WriteLine("Enter new phone number: ");
                                contact.PhoneNumber = Console.ReadLine();
                                break;
                            case "8":
                                Console.WriteLine("Enter new email: ");
                                contact.Email = Console.ReadLine();
                                break;
                            default:
                                Console.WriteLine("Invalid option");
                                break;
                        }

                    }
                }

            }


        }

        public void deleteContact()
        {
            Console.WriteLine("Enter the name of address book in which contact is saved:");
            string targetAddressBook = Console.ReadLine();

            if (addressBooksMap.ContainsKey(targetAddressBook) && targetAddressBook != null)
            {
                Console.WriteLine("Enter first name: ");
                string fName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                string lName = Console.ReadLine();

                for (int i = 0; i < addressBooksMap[targetAddressBook].Count; i++)
                {
                    //Contact contact = addressBooksMap[targetAddressBook][i];
                    if (addressBooksMap[targetAddressBook][i].FirstName == fName && addressBooksMap[targetAddressBook][i].LastName == lName)
                    {
                        addressBooksMap[targetAddressBook].Remove(addressBooksMap[targetAddressBook][i]);
                    }
                }

            }

        }

        public void Display()
        {
            foreach (KeyValuePair<string, List<Contact>> item in addressBooksMap)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("Name of address book: " + item.Key);
                Console.WriteLine("===============================");
                List<Contact> list = item.Value;
                foreach (Contact contact in list.ToList())
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("First name: " + contact.FirstName);
                    Console.WriteLine("Last name: " + contact.LastName);
                    Console.WriteLine("Address: " + contact.Address);
                    Console.WriteLine("City: " + contact.City);
                    Console.WriteLine("State: " + contact.State);
                    Console.WriteLine("Zip: " + contact.Zip);
                    Console.WriteLine("Phone number: " + contact.PhoneNumber);
                    Console.WriteLine("Email: " + contact.Email);
                    Console.WriteLine("-----------------------------");
                }

            }
        }

        public void SearchByCityOrState()
        {
            Console.WriteLine("Search persons by city or state:\n#1 City\n#2 State");
            Console.WriteLine("Enter a choice:");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    Console.WriteLine("Enter the name of city: ");
                    string searchInCity = Console.ReadLine();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Persons in the city of {0} are: ", searchInCity);
                    Console.WriteLine("-----------------------------");
                    foreach (List<Contact> item in addressBooksMap.Values)
                    {
                        foreach(Contact element in item.FindAll(e => e.City == searchInCity))
                        {
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("First name: " + element.FirstName);
                            Console.WriteLine("Last name: " + element.LastName);
                            Console.WriteLine("Address: " + element.Address);
                            Console.WriteLine("City: " + element.City);
                            Console.WriteLine("State: " + element.State);
                            Console.WriteLine("Zip: " + element.Zip);
                            Console.WriteLine("Phone number: " + element.PhoneNumber);
                            Console.WriteLine("Email: " + element.Email);
                            Console.WriteLine("-----------------------------");
                        }
                    }
                    SearchByCityOrState();
                    break;
                case 2:
                    Console.WriteLine("Enter the name of state: ");
                    string searchInState = Console.ReadLine();
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Persons in the state of {0} are: ", searchInState);
                    Console.WriteLine("-----------------------------");
                    foreach (List<Contact> item in addressBooksMap.Values)
                    {
                        foreach (Contact element in item.FindAll(e => e.State == searchInState))
                        {
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("First name: " + element.FirstName);
                            Console.WriteLine("Last name: " + element.LastName);
                            Console.WriteLine("Address: " + element.Address);
                            Console.WriteLine("City: " + element.City);
                            Console.WriteLine("State: " + element.State);
                            Console.WriteLine("Zip: " + element.Zip);
                            Console.WriteLine("Phone number: " + element.PhoneNumber);
                            Console.WriteLine("Email: " + element.Email);
                            Console.WriteLine("-----------------------------");
                        }
                    }
                    SearchByCityOrState();
                    break;
                default:
                    SearchByCityOrState();
                    break;
            }

        }


        public void MaintainCityAndPersonMap()
        {
            foreach (List<Contact> item in addressBooksMap.Values)
            {
                foreach(Contact element in item.FindAll(e => e.City != null))
                {

                    if (cityAndPersonMap.ContainsKey(element.City))
                    {
                        cityAndPersonMap[element.City].Add(element);
                    }
                    else
                    {
                        cityAndPersonMap.Add(element.City, new List<Contact>());
                        cityAndPersonMap[element.City].Add(element);
                    }

                }
            }
        }

        public void MaintainStateAndPersonMap()
        {
            foreach (List<Contact> item in addressBooksMap.Values)
            {
                foreach (Contact element in item.FindAll(e => e.State != null))
                {

                    if (stateAndPersonMap.ContainsKey(element.State))
                    {
                        stateAndPersonMap[element.State].Add(element);
                    }
                    else
                    {
                        stateAndPersonMap.Add(element.State, new List<Contact>());
                        stateAndPersonMap[element.State].Add(element);
                    }

                }
            }
        }

        public void DisplayByCity()
        {
            foreach (KeyValuePair<string, List<Contact>> item in cityAndPersonMap)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("Persons in City: " + item.Key);
                Console.WriteLine("===============================");
                List<Contact> list = item.Value;
                foreach (Contact contact in list.ToList())
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("First name: " + contact.FirstName);
                    Console.WriteLine("Last name: " + contact.LastName);
                    Console.WriteLine("Address: " + contact.Address);
                    Console.WriteLine("City: " + contact.City);
                    Console.WriteLine("State: " + contact.State);
                    Console.WriteLine("Zip: " + contact.Zip);
                    Console.WriteLine("Phone number: " + contact.PhoneNumber);
                    Console.WriteLine("Email: " + contact.Email);
                    Console.WriteLine("-----------------------------");
                }

            }
        }


        public void DisplayByState()
        {
            foreach (KeyValuePair<string, List<Contact>> item in stateAndPersonMap)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("Persons in State: " + item.Key);
                Console.WriteLine("===============================");
                List<Contact> list = item.Value;
                foreach (Contact contact in list.ToList())
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("First name: " + contact.FirstName);
                    Console.WriteLine("Last name: " + contact.LastName);
                    Console.WriteLine("Address: " + contact.Address);
                    Console.WriteLine("City: " + contact.City);
                    Console.WriteLine("State: " + contact.State);
                    Console.WriteLine("Zip: " + contact.Zip);
                    Console.WriteLine("Phone number: " + contact.PhoneNumber);
                    Console.WriteLine("Email: " + contact.Email);
                    Console.WriteLine("-----------------------------");
                }

            }
        }


        public void CountByCity()
        {
            if(cityAndPersonMap.Count != null)
            {
                foreach(KeyValuePair<string, List<Contact>> item in cityAndPersonMap)
                {
                    string population = item.Value.Count.ToString();
                    Console.WriteLine("Number of people in the city of \"{0}\": {1}", item.Key, population);
                }
            }
            else
            {
                Console.WriteLine("City to persons map is empty.");
            }
        }

        public void CountByState()
        {
            if(stateAndPersonMap.Count != null)
            {
                foreach(KeyValuePair<string, List<Contact>> item in stateAndPersonMap)
                {
                    Console.WriteLine("Number of people in the state of \"{0}\": {1}", item.Key, item.Value.Count);
                }
            }
            else
            {
                Console.WriteLine("State to persons map is empty.");
            }
        }

        
        public void SortContactsInAddressBookByComparingFullName()
        {
            CompareContactsByName obj = new CompareContactsByName();
            foreach (KeyValuePair<string, List<Contact>> item in addressBooksMap)
            {
                item.Value.Sort(obj);
                Console.WriteLine("------------------------------");
                Console.WriteLine("Address Book:\t{0}", item.Key);
                Console.WriteLine("------------------------------");
                foreach (Contact element in item.Value.FindAll(e => e.FirstName != null && e.LastName != null))
                {
                    Console.WriteLine(element.ToString());
                    Console.WriteLine("------------------------------");
                }
            }

        }

        public void SortContactInAddressBooksByComparingCity()
        {
            CompareContactsByCity obj = new CompareContactsByCity();

            foreach (KeyValuePair<string, List<Contact>> item in addressBooksMap)
            {
                item.Value.Sort(obj);
                Console.WriteLine("------------------------------");
                Console.WriteLine("Address Book:\t{0}", item.Key);
                Console.WriteLine("------------------------------");
                foreach (Contact element in item.Value.FindAll(e => e.City != null))
                {
                    Console.WriteLine(element.ToString());
                    Console.WriteLine("------------------------------");
                }
            }

        }


        public void SortContactsInAddressBooksByComparingState()
        {
            CompareContactsByState obj = new CompareContactsByState();

            foreach (KeyValuePair<string, List<Contact>> item in addressBooksMap)
            {
                item.Value.Sort(obj);
                Console.WriteLine("------------------------------");
                Console.WriteLine("Address Book:\t{0}", item.Key);
                Console.WriteLine("------------------------------");
                foreach (Contact element in item.Value.FindAll(e => e.State != null))
                {
                    Console.WriteLine(element.ToString());
                    Console.WriteLine("------------------------------");
                }
            }

        }


        public void SortContactsInAddressBooksByComparingZip()
        {
            CompareContactsByZip obj = new CompareContactsByZip();

            foreach (KeyValuePair<string, List<Contact>> item in addressBooksMap)
            {
                item.Value.Sort(obj);
                Console.WriteLine("------------------------------");
                Console.WriteLine("Address Book:\t{0}", item.Key);
                Console.WriteLine("------------------------------");
                foreach (Contact element in item.Value.FindAll(e => e.Zip != null))
                {
                    Console.WriteLine(element.ToString());
                    Console.WriteLine("------------------------------");
                }
            }

        }



        public void WriteToTextFile()
        {
            string path = @"C:\Users\ishaa\source\repos\ConceptPractice\AssignmentPractice\AddressBookPractice\AddressBookPractice\AddressBookFileIO.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (KeyValuePair<string, List<Contact>> item in addressBooksMap)
                {
                    sw.WriteLine("------------------------------");
                    sw.WriteLine("Address Book:\t{0}", item.Key);
                    sw.WriteLine("------------------------------");
                    foreach (Contact element in item.Value)
                    {
                        sw.WriteLine(element.ToString());
                        sw.WriteLine("------------------------------");
                    }
                }
            }
        }


        public static void ReadFromTextFile()
        {
            string path = @"C:\Users\ishaa\source\repos\ConceptPractice\AssignmentPractice\AddressBookPractice\AddressBookPractice\AddressBookFileIO.txt";
            
            using (StreamReader sr = new StreamReader(path))
            {
                string s = string.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

        }


        public void WriteToCSVFile()
        {
            string path = @"C:\Users\ishaa\source\repos\ConceptPractice\AssignmentPractice\AddressBookPractice\AddressBookPractice\Utility\AddressBookWriteFile.csv";
            using(StreamWriter sw = new StreamWriter(path))
            using(CsvWriter csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
                foreach(List<Contact> item in addressBooksMap.Values)
                {
                    csv.WriteRecords(item);
                }
            }

        }


        public static void ReadFromCsvFile()
        {
            string path = @"C:\Users\ishaa\source\repos\ConceptPractice\AssignmentPractice\AddressBookPractice\AddressBookPractice\Utility\AddressBookWriteFile.csv";

            using (StreamReader sr = new StreamReader(path))
            using (CsvReader reader = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                var records = reader.GetRecords<Contact>().ToList();

                Console.WriteLine("Reading records from address book csv file...");
                foreach(Contact item in records)
                {
                    Console.Write(item.FirstName);
                    Console.Write("\t" + item.LastName);
                    Console.Write("\t" + item.Address);
                    Console.Write("\t" + item.City);
                    Console.Write("\t" + item.State);
                    Console.Write("\t" + item.Zip);
                    Console.Write("\t" + item.PhoneNumber);
                    Console.Write("\t" + item.Email);
                    Console.WriteLine();
                }
            }

        }


        //alternate way to read from csv file

        //public static void ReadFromCsvFile()
        //{
        //    string path = @"C:\Users\ishaa\source\repos\ConceptPractice\AssignmentPractice\AddressBookPractice\AddressBookPractice\Utility\AddressBookWriteFile.csv";
        //    string[] data = File.ReadAllLines(path);
        //    string[] header = { "First Name", "LastName", "Address", "City", "State", "Zip Code", "Phone Number", "Email" };

        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        string[] person = data[i].Split(",");
        //        for (int j = 0; j < person.Length; j++)
        //        {
        //            Console.WriteLine(header[j] + " : " + person[j]);
        //        }
        //    }

        //}


        public void WriteToJsonFile()
        {
            string path = @"C:\Users\ishaa\source\repos\ConceptPractice\AssignmentPractice\AddressBookPractice\AddressBookPractice\AddressBookJsonFile.json";
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                List<Contact> storeAllContacts = new List<Contact>();
                foreach(List<Contact> item in addressBooksMap.Values)
                {
                    foreach(Contact element in item)
                    {
                        storeAllContacts.Add(element);
                    }
                }
                serializer.Serialize(writer, storeAllContacts);
                
                // for ease :- convert target object to json string and then write that json string to json file
                //serializer, sw, writer are not required in this case. just need the object
                
                //var json = JsonConvert.SerializeObject(storeAllContacts);
                //File.WriteAllText(path, json);
            }
        }

        public static void ReadFromJsonFile()
        {
            string path = @"C:\Users\ishaa\source\repos\ConceptPractice\AssignmentPractice\AddressBookPractice\AddressBookPractice\AddressBookJsonFile.json";

            
            using(StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                var jsonfile = JsonConvert.DeserializeObject<List<Contact>>(json);

                foreach(Contact item in jsonfile)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine("--------------------------");
                }
            }


        }

    }
}
