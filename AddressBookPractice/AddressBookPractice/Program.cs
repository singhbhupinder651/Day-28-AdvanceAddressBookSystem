namespace AddressBookPractice
{
    class Program
    {
        public static void Main(string[] args)
        {



            //UC-15
            MultipleAddressBooks multipleAddressBooks = new MultipleAddressBooks();

            //adding address books and contacts
            multipleAddressBooks.addAddressBook();
            multipleAddressBooks.addContact();
            multipleAddressBooks.addAddressBook();
            multipleAddressBooks.addContact();

            //writing to json file
            multipleAddressBooks.WriteToJsonFile();

            //reading from json file
            MultipleAddressBooks.ReadFromJsonFile();

        }
    }
}