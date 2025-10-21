

using System;

class User
{
    // Private sahələr
    private static int _count = 0;
    private int _id;
    private string _fullname;
    private string _email;
    private string _password;
    private int _age;

    // Id property (yalnız oxuna bilər)
    public int Id
    {
        get { return _id; }
        private set { _id = value; }
    }

    public string Fullname
    {
        get { return _fullname; }
        set { _fullname = value; }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    public string Password
    {
        get { return _password; }
        set
        {
            if (PasswordChecker(value))
                _password = value;
            else
                throw new Exception("Şifrə tələblərə cavab vermir!");
        }
    }

    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }

    // Constructor – Email və Password mütləq verilməlidir
    public User(string email, string password)
    {
        _count++;
        Id = _count; // Avtomatik artan Id
        Email = email;

        if (PasswordChecker(password))
            Password = password;
        else
            throw new Exception("Şifrə tələblərə cavab vermir!");
    }

    // Şifrə yoxlama metodu
    public bool PasswordChecker(string password)
    {
        if (password.Length < 8)
            return false;

        bool hasUpper = false;
        bool hasLower = false;
        bool hasDigit = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c)) hasUpper = true;
            if (char.IsLower(c)) hasLower = true;
            if (char.IsDigit(c)) hasDigit = true;
        }

        return hasUpper && hasLower && hasDigit;
    }

    // İstifadəçi məlumatlarını qaytarır
    public string GetInfo()
    {
        return $"Id: {Id}, Fullname: {Fullname}, Email: {Email}";
    }
}
