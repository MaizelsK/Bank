using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ViewModels
{
    public static class RegistrationValidate
    {
        public static string ValidateFirstName(string firstName)
        {
            if (String.IsNullOrWhiteSpace(firstName))
                return "Введите имя";

            if (!firstName.All(char.IsLetter))
                return "Некорректное имя";

            return null;
        }

        public static string ValidateMiddleName(string middleName)
        {
            if (String.IsNullOrWhiteSpace(middleName))
                return "Введите отчество";

            if (!middleName.Any(char.IsLetter))
                return "Некорректное отчество";

            return null;
        }

        public static string ValidateSurName(string surName)
        {
            if (String.IsNullOrWhiteSpace(surName))
                return "Введите фамилию";

            if (!surName.Any(char.IsLetter))
                return "Некорректная фамилия";

            return null;
        }

        public static string ValidateBirthDate(DateTime birthDate)
        {
            if (birthDate == null)
                return "Выберите свою дату рождения";

            if (CalculateAge(birthDate) < 18)
                return "Несовершеннолетний возраст";

            return null;
        }

        public static int CalculateAge(DateTime date)
        {
            int age = DateTime.Today.Year - date.Year;
            if (date > DateTime.Today.AddYears(-age)) age--;

            return age;
        }

        public static string ValidateEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                return "Введите email";
            }

            var validation = new EmailAddressAttribute();

            if (!validation.IsValid(email))
                return "Некорректный email";

            return null;
        }

        public static string ValidatePhone(string phone)
        {
            if (String.IsNullOrWhiteSpace(phone))
                return "Введите номер телефона";

            var phoneValidation = new PhoneAttribute();

            if (!phoneValidation.IsValid(phone))
                return "Некорректный номер телефона";

            return null;
        }

        public static string ValidateLogin(string login)
        {
            if (String.IsNullOrWhiteSpace(login))
            {
                return "Введите имя пользователя";
            }

            return null;
        }

        public static string ValidatePassword(string password)
        {
            if (String.IsNullOrWhiteSpace(password))
                return "Введите пароль";

            if (password.Length < 8)
                return "Минимальная длина - 8 символов";

            return null;
        }

        public static string ValidateConfirmPassword(string password, string confirmPassword)
        {
            if (confirmPassword != password)
                return "Пароли не совпадают";

            return null;
        }
    }
}
