using System;
using System.Collections.Generic;

class Contact
{
    // Members are private for encapsulation
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Zip { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }

    // Constructor to initialize a contact
    public Contact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        City = city;
        State = state;
        Zip = zip;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    // Method to update contact information
    public void UpdateContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        City = city;
        State = state;
        Zip = zip;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}

class AddressBook
{
    internal List<Contact> contacts; // Changed access level to internal

    public AddressBook()
    {
        contacts = new List<Contact>();
    }

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public void DisplayContacts()
    {
        for (int i = 0; i < contacts.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] Name: {contacts[i].FirstName} {contacts[i].LastName}");
            Console.WriteLine($"    Address: {contacts[i].Address}, {contacts[i].City}, {contacts[i].State} - {contacts[i].Zip}");
            Console.WriteLine($"    Phone Number: {contacts[i].PhoneNumber}");
            Console.WriteLine($"    Email: {contacts[i].Email}\n");
        }
    }

    public Contact SearchContact(int index)
    {
        if (index >= 0 && index < contacts.Count)
        {
            return contacts[index];
        }
        return null;
    }

    public void EditContact(int index, Contact updatedContact)
    {
        if (index >= 0 && index < contacts.Count)
        {
            // Update the existing contact with the new information
            contacts[index].UpdateContact(
                updatedContact.FirstName, updatedContact.LastName, updatedContact.Address,
                updatedContact.City, updatedContact.State, updatedContact.Zip,
                updatedContact.PhoneNumber, updatedContact.Email);

            Console.WriteLine("Contact updated successfully!");
        }
        else
        {
            Console.WriteLine("Invalid index. Contact not found!");
        }
    }
}

class Program
{
    static void Main()
    {
        AddressBook addressBook = new AddressBook();
        bool continueOperations = true;

        while (continueOperations)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add New Contact");
            Console.WriteLine("2. Edit Existing Contact");
            Console.WriteLine("3. Display All Contacts");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice (1-4): ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    // Add a new contact
                    Contact newContact = GetContactDetails();
                    addressBook.AddContact(newContact);
                    Console.WriteLine("Contact added successfully!");
                    break;

                case "2":
                    // Edit a contact
                    int editIndex = GetContactIndex(addressBook);
                    if (editIndex != -1)
                    {
                        Contact updatedContact = GetContactDetails();
                        // Edit the contact in the address book
                        addressBook.EditContact(editIndex, updatedContact);
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }
                    break;

                case "3":
                    // Display all contacts
                    Console.WriteLine("\nAll Contacts:");
                    addressBook.DisplayContacts();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;

                case "4":
                    // Exit the program
                    continueOperations = false;
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option (1-4).");
                    break;
            }

            Console.Clear(); // Clear console for better readability
        }
    }

    static Contact GetContactDetails()
    {
        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter Address: ");
        string address = Console.ReadLine();
        Console.Write("Enter City: ");
        string city = Console.ReadLine();
        Console.Write("Enter State: ");
        string state = Console.ReadLine();
        Console.Write("Enter Zip Code: ");
        string zip = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        return new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
    }

    static int GetContactIndex(AddressBook addressBook)
    {
        Console.Write("Enter the index of the contact you want to edit: ");
        if (int.TryParse(Console.ReadLine(), out int editIndex) && editIndex > 0 && editIndex <= addressBook.contacts.Count)
        {
            return editIndex - 1; // Adjusting for 0-based indexing
        }
        else
        {
            Console.WriteLine("Invalid index. Press Enter to continue...");
            Console.ReadLine();
            return -1;
        }
    }
}
