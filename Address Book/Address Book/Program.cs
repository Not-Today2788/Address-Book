using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Address_Book
{


    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<Contact>> address_books = new SortedDictionary<string, List<Contact>>();
            Console.WriteLine("Enter the owner of the Address Book : ");
            AddressBookMain myobject = new AddressBookMain(address_books);
            Console.Clear();
            int option;
            string email;
            myobject.DisplayMessage();
            Thread.Sleep(2000);
            do
            {
                Console.Clear();
                Console.WriteLine("Enter an option from the menu : \n\n1. Add Contact\n2. Display Contacts\n3. Edit Contact\n4. Delete Contact\n5. Add a new address book\n6. Display address books\n7. Switch to another book\n8. Exit\n");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        myobject.AddContact();
                        Console.Clear();
                        Console.WriteLine("Contact Added Successfully ...");
                        Thread.Sleep(2000);
                        break;
                    case 2:
                        Console.Clear();
                        myobject.display();
                        Console.WriteLine("\nPress any key to go back ...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        myobject.display();
                        Console.WriteLine("\nEnter the email of the contact to edit : ");
                        email = Console.ReadLine();
                        myobject.Edit(email);
                        Console.WriteLine("Contact Edited ...");
                        Thread.Sleep(2000);
                        break;
                    case 4:
                        Console.Clear();
                        myobject.display();
                        Console.WriteLine("\nEnter the email of the contact to be deleted : ");
                        email = Console.ReadLine();
                        myobject.delete(email);
                        Thread.Sleep(2000);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Enter the new address book : ");
                        myobject = new AddressBookMain(address_books);
                        Console.WriteLine("New address book has been created ...");
                        Thread.Sleep(3000);
                        break;
                    case 6:
                        Console.Clear();
                        foreach (KeyValuePair<string, List<Contact>> kvp in address_books)
                        {
                            Console.WriteLine($"{kvp.Key} : {kvp.Value.Count} Contacts");
                        }
                        Console.WriteLine("\n Press Any Key to go back ...");
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        foreach (KeyValuePair<string, List<Contact>> kvp in address_books)
                        {
                            Console.WriteLine($"{kvp.Key} : {kvp.Value.Count} Contacts");
                        }
                        Console.WriteLine("\nEnter the Address book to switch with ...");
                        email = Console.ReadLine();
                        if (address_books.ContainsKey(email))
                        {
                            myobject.switching(email, address_books);
                            Console.WriteLine($"Switched to {email}");
                        }
                        else
                        {
                            Console.WriteLine("The Specified Address book does not exist ...");
                        }
                        Thread.Sleep(3000);
                        break;
                    case 8:
                        Console.WriteLine("Exited ...");
                        break;
                }
            } while (option != 8);

        }
    }
}