using System;
using System.Collections.Generic;
using System.Linq;

class Contact
{
    private string firstName;
    private string lastName;
    private string address;
    private string city;
    private string state;
    private string zip;
    private string phoneNumber;
    private string email;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public string City
    {
        get { return city; }
        set { city = value; }
    }

    public string State
    {
        get { return state; }
        set { state = value; }
    }

    public string Zip
    {
        get { return zip; }
        set { zip = value; }
    }

    public string PhoneNumber
    {
        get { return phoneNumber; }
        set { phoneNumber = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }
}

class AddressBook
{
    private List<Contact> contacts;

    public AddressBook()
    {
        contacts = new List<Contact>();
    }

    public List<Contact> Contacts
    {
        get { return contacts; }
    }

    public bool DoesEmailExist(string email)
    {
        return contacts.Any(contact => string.Equals(contact.Email, email, StringComparison.OrdinalIgnoreCase));
    }

    internal void AddContact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
    {
        if (DoesEmailExist(email))
        {
            Console.WriteLine("A contact with the same email already exists. Contact not added.");
            return;
        }

        Contact newContact = new Contact();
        newContact.FirstName = firstName;
        newContact.LastName = lastName;
        newContact.Address = address;
        newContact.City = city;
        newContact.State = state;
        newContact.Zip = zip;
        newContact.PhoneNumber = phoneNumber;
        newContact.Email = email;

        contacts.Add(newContact);
        Console.WriteLine("Contact added successfully!");
    }

    internal void DisplayContacts()
    {
        for (int i = 0; i < contacts.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {GetContactInfo(contacts[i])}\n");
        }
    }

    internal void EditContact(string email, string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string newEmail)
    {
        if (DoesEmailExist(email))
        {
            int index = contacts.FindIndex(contact => string.Equals(contact.Email, email, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(newEmail) && !IsEmailUnique(newEmail))
            {
                Console.WriteLine("A contact with the same new email already exists. Contact not updated.");
                return;
            }

            contacts[index].FirstName = firstName;
            contacts[index].LastName = lastName;
            contacts[index].Address = address;
            contacts[index].City = city;
            contacts[index].State = state;
            contacts[index].Zip = zip;
            contacts[index].PhoneNumber = phoneNumber;
            contacts[index].Email = string.IsNullOrEmpty(newEmail) ? email : newEmail;

            Console.WriteLine("Contact updated successfully!");
        }
        else
        {
            Console.WriteLine("No contact found with the provided email. Contact not updated.");
        }
    }

    internal void DeleteContact(string email)
    {
        int index = contacts.FindIndex(contact => string.Equals(contact.Email, email, StringComparison.OrdinalIgnoreCase));

        if (index != -1)
        {
            contacts.RemoveAt(index);
            Console.WriteLine("Contact deleted successfully!");
        }
        else
        {
            Console.WriteLine("No contact found with the provided email. Contact not deleted.");
        }
    }

    private string GetContactInfo(Contact contact)
    {
        return $"Name: {contact.FirstName} {contact.LastName}\n" +
               $"Address: {contact.Address}, {contact.City}, {contact.State} - {contact.Zip}\n" +
               $"Phone Number: {contact.PhoneNumber}\n" +
               $"Email: {contact.Email}\n";
    }

    private bool IsEmailUnique(string email)
    {
        return contacts.All(contact => !contact.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }
}

class Program
{
    static void Main()
    {
        AddressBook addressBook = new AddressBook();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add New Contact");
            Console.WriteLine("2. Edit Existing Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Display All Contacts");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    // Add a new contact
                    addressBook.AddContact(
                        GetUserInput("Enter First Name"),
                        GetUserInput("Enter Last Name"),
                        GetUserInput("Enter Address"),
                        GetUserInput("Enter City"),
                        GetUserInput("Enter State"),
                        GetUserInput("Enter Zip Code"),
                        GetUserInput("Enter Phone Number"),
                        GetUserInput("Enter Email")
                    );
                    break;

                case "2":
                    // Edit a contact
                    string editEmail = GetUserInput("Enter Email of the contact to edit");
                    if (addressBook.DoesEmailExist(editEmail))
                    {
                        addressBook.EditContact(
                            editEmail,
                            GetUserInput("Enter New First Name"),
                            GetUserInput("Enter New Last Name"),
                            GetUserInput("Enter New Address"),
                            GetUserInput("Enter New City"),
                            GetUserInput("Enter New State"),
                            GetUserInput("Enter New Zip Code"),
                            GetUserInput("Enter New Phone Number"),
                            GetUserInput("Enter New Email")
                        );
                    }
                    else
                    {
                        Console.WriteLine("No contact found with the provided email. Contact not edited.");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }
                    break;

                case "3":
                    // Delete a contact
                    string deleteEmail = GetUserInput("Enter Email of the contact to delete");
                    addressBook.DeleteContact(deleteEmail);
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;

                case "4":
                    // Display all contacts
                    Console.WriteLine("\nAll Contacts:");
                    addressBook.DisplayContacts();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;

                case "5":
                    // Exit the program
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option (1-5).");
                    break;
            }

            Console.Clear(); // Clear console for better readability
        }
    }

    static string GetUserInput(string prompt)
    {
        Console.Write($"{prompt}: ");
        return Console.ReadLine();
    }
}
