using System;
using System.Collections.Generic;
using Manager.Domain.Validators;

namespace Manager.Domain.Entities
{
    public class User : Base
    {


        // Private Set, entidade fechada, somente podendo ser mudando por contrutor da propria classe
        //Propriedades
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }


        //EF
        protected User() { }


        // Comportamentos
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();
        }
        //A entidade se alto valida
        public void ChangeName(string name)
        {
            Name = name;
            Validate();

        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();

        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);
                throw new Exception("Alguns campo estão invalidos, por favor corrija-os" + _errors[0]);
            }
            return true;
        }
    }
}