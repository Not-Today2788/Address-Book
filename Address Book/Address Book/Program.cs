using System;
using System.Collections.Generic;

class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}

class AddressBook
{
    private List<Contact> contacts;

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
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
            Console.WriteLine($"Address: {contact.Address}, {contact.City}, {contact.State} - {contact.Zip}");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
            Console.WriteLine($"Email: {contact.Email}\n");
        }
    }
}

class Program
{
    static void Main()
    {
        AddressBook addressBook = new AddressBook();

        // Create a new contact
        Contact newContact = new Contact();
        Console.Write("Enter First Name: ");
        newContact.FirstName = Console.ReadLine();
        Console.Write("Enter Last Name: ");
        newContact.LastName = Console.ReadLine();
        Console.Write("Enter Address: ");
        newContact.Address = Console.ReadLine();
        Console.Write("Enter City: ");
        newContact.City = Console.ReadLine();
        Console.Write("Enter State: ");
        newContact.State = Console.ReadLine();
        Console.Write("Enter Zip Code: ");
        newContact.Zip = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        newContact.PhoneNumber = Console.ReadLine();
        Console.Write("Enter Email: ");
        newContact.Email = Console.ReadLine();

        // Add the contact to the address book
        addressBook.AddContact(newContact);

        // Display all contacts in the address book
        Console.WriteLine("\nAll Contacts:");
        addressBook.DisplayContacts();
    }
}
