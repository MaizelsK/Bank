using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public RegisterViewModel()
        {
            BirthDate = DateTime.Today;
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string middleName;
        public string MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        private string surName;
        public string SurName
        {
            get { return surName; }
            set
            {
                surName = value;
                OnPropertyChanged("SurName");
            }
        }

        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private string confirmPassword;
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        #region Validation

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidationProperties)
                {
                    if (GetValidationError(property) != null)
                        return false;
                }

                return true;
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        static readonly string[] ValidationProperties =
        {
            "FirstName", "MiddleName", "SurName",
            "BirthDate", "Email", "Phone",
            "Login", "Password", "ConfirmPassword"
        };

        public string this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }

        private string GetValidationError(string propertyName)
        {
            string error = null;

            switch (propertyName)
            {
                case "FirstName":
                    error = RegistrationValidate.ValidateFirstName(FirstName);
                    break;

                case "MiddleName":
                    error = RegistrationValidate.ValidateMiddleName(MiddleName);
                    break;

                case "SurName":
                    error = RegistrationValidate.ValidateSurName(SurName);
                    break;

                case "BirthDate":
                    error = RegistrationValidate.ValidateBirthDate(BirthDate);
                    break;

                case "Email":
                    error = RegistrationValidate.ValidateEmail(Email);
                    break;

                case "Phone":
                    error = RegistrationValidate.ValidatePhone(Phone);
                    break;

                case "Login":
                    error = RegistrationValidate.ValidateLogin(Login);
                    break;

                case "Password":
                    error = RegistrationValidate.ValidatePassword(Password);
                    break;

                case "ConfirmPassword":
                    error = RegistrationValidate.ValidateConfirmPassword(Password, ConfirmPassword);
                    break;
            }

            return error;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
