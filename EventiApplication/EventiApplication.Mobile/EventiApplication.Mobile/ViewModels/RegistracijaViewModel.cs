﻿using EventiApplication.Mobile.Views;
using EventiApplication.Mobile.Helper;
using EventiApplication.Model;
using EventiApplication.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EventiApplication.Mobile.ViewModels
{
    public class RegistracijaViewModel : BaseViewModel
    {
        private readonly APIService _registracijaService = new APIService("Registracija");
        public RegistracijaViewModel()
        {
            RegistracijaCommand = new Command(async () => await Registracija());
        }

        public ICommand RegistracijaCommand { get; set; }

        public async Task Registracija()
        {
            if (!Validate())
            {
                return;
            }
           

            KorisnikInsertRequest request = new KorisnikInsertRequest
            {
                Adresa = this.Adresa,
                Email = this.Email,
                GradId = this.Grad.Id,
                Ime = this.Ime,
                Password = this.Password,
                PasswordConfirmation = this.Password,
                PostanskiBroj = this.PostanskiBroj,
                Prezime = this.Prezime,
                Telefon = this.Telefon,
                Username = this.Username
            };

            Korisnik result =await _registracijaService.Insert<Korisnik>(request);
            if(result != default(Korisnik) && result!=null)
            {
                
               await Application.Current.MainPage.DisplayAlert("Info", Messages.UspjesnaRegistracija, "OK");
                Application.Current.MainPage = new LoginPage();
                
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Info", Messages.NeuspjesnaRegistracija, "OK");
            }
        }

        private string _ime = string.Empty;
        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }

        private string _prezime = string.Empty;
        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }

        private string _telefon = string.Empty;
        public string Telefon
        {
            get { return _telefon; }
            set { SetProperty(ref _telefon, value); }
        }
        private string _adresa = string.Empty;
        public string Adresa
        {
            get { return _adresa; }
            set { SetProperty(ref _adresa, value); }
        }

        private string _postanskiBroj = string.Empty;
        public string PostanskiBroj
        {
            get { return _postanskiBroj; }
            set { SetProperty(ref _postanskiBroj, value); }
        }


        private string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        private string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private string _passConfirmation = string.Empty;
        public string PassConfirmation
        {
            get { return _passConfirmation; }
            set { SetProperty(ref _passConfirmation, value); }
        }

  

        private Grad _grad = null;  

        public Grad Grad
        {
            get { return _grad; }
            set { SetProperty(ref _grad, value); }
        }

        private string _lblImeErr = string.Empty;
        public string LblImeErr
        {
            get { return _lblImeErr; }
            set { SetProperty(ref _lblImeErr, value); }
        }

        private string _lblPrezimeErr = string.Empty;
        public string LblPrezimeErr
        {
            get { return _lblPrezimeErr; }
            set { SetProperty(ref _lblPrezimeErr, value); }
        }

        private string _lblTelefonErr = string.Empty;
        public string LblTelefonErr
        {
            get { return _lblTelefonErr; }
            set { SetProperty(ref _lblTelefonErr, value); }
        }

        private string _lblAdresaErr = string.Empty;
        public string LblAdresaErr
        {
            get { return _lblAdresaErr; }
            set { SetProperty(ref _lblAdresaErr, value); }
        }

        private string _lblPostBrojErr = string.Empty;
        public string LblPostBrojErr
        {
            get { return _lblPostBrojErr; }
            set { SetProperty(ref _lblPostBrojErr, value); }
        }

    

        private string _lblEmailErr = string.Empty;
        public string LblEmailErr
        {
            get { return _lblEmailErr; }
            set { SetProperty(ref _lblEmailErr, value); }
        }

        private string _lblUsernameErr = string.Empty;
        public string LblUsernameErr
        {
            get { return _lblUsernameErr; }
            set { SetProperty(ref _lblUsernameErr, value); }
        }

        private string _lblPasswordErr = string.Empty;
        public string LblPasswordErr
        {
            get { return _lblPasswordErr; }
            set { SetProperty(ref _lblPasswordErr, value); }
        }


        private string _lblPassConfirmationErr = string.Empty;
        public string LblPassConfirmationErr
        {
            get { return _lblPassConfirmationErr; }
            set { SetProperty(ref _lblPassConfirmationErr, value); }
        }

        private string _lblGradErr = string.Empty;
        public string LblGradErr
        {
            get { return _lblGradErr; }
            set { SetProperty(ref _lblGradErr, value); }
        }

        
       
        private bool Validate()
        {

            if ( ImeValidation() && PrezimeValidation() && TelefonValidation() && AdresaValidation()
                && PostanskiBrojValidation()  && EmailValidation()
                && UsernameValidation() && PasswordValidation() 
                && PasswordConfirmationValidation() && GradValidation())
                return true;
            return false;
        }

        private bool ImeValidation()
        {
            bool IsValidno = true;
            if (string.IsNullOrWhiteSpace(Ime) || string.IsNullOrEmpty(Ime))
            {
                LblImeErr = Messages.ValErrObaveznoPolje;
                IsValidno = false;
            }
            else if (Ime.Length < 2)
            {
                LblImeErr = Messages.ValErrMin2Karaktera;
                IsValidno = false;
            }

            if (IsValidno == true)
            {
                LblImeErr = null;

            }
            return IsValidno;
        }
        private bool PrezimeValidation()
        {
            bool IsValidno = true;
            if (string.IsNullOrWhiteSpace(Prezime) || string.IsNullOrEmpty(Prezime))
            {
                LblPrezimeErr = Messages.ValErrObaveznoPolje;
                IsValidno = false;
            }
            else if (Prezime.Length < 2)
            {
                LblPrezimeErr = Messages.ValErrMin2Karaktera;
                IsValidno = false;
            }

            if (IsValidno == true)
            {
                LblPrezimeErr = null;

            }
            return IsValidno;
        }

        private bool TelefonValidation()
        {
            bool IsValidno = true;
            Regex regex = new Regex(@"[0-9]{9}");
            Regex hasLetter = new Regex(@"[a-zA-Z]+");
            Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (string.IsNullOrWhiteSpace(Telefon))
            {
                LblTelefonErr = Messages.ValErrObaveznoPolje;
                IsValidno = false;
            }
            else if (hasLetter.IsMatch(Telefon))
            {
                LblTelefonErr = Messages.ValErrFormatTelefona;
                IsValidno = false;
            }
            else if (hasSymbols.IsMatch(Telefon))
            {
                LblTelefonErr = Messages.ValErrFormatTelefona;
                IsValidno = false;
            }
            else if (!regex.IsMatch(Telefon))
            {
                LblTelefonErr = Messages.ValErrFormatTelefona;
                IsValidno = false;
            }
            else if (Telefon.Length > 9)
            {
                LblTelefonErr = Messages.ValErrFormatTelefona;
                IsValidno = false;
            }
            else
            {
                LblTelefonErr = null;
            }
            return IsValidno;
        }

        private bool AdresaValidation()
        {
            bool IsValidno = true;
            if (string.IsNullOrWhiteSpace(Adresa))
            {
                LblAdresaErr = Messages.ValErrObaveznoPolje;
                IsValidno = false;
            }
            else
            {
                LblAdresaErr = null;
            }

            return IsValidno;
        }
        private bool PostanskiBrojValidation()
        {
            bool IsValidno = true;
            Regex regex = new Regex(@"[0-9]{1,15}");
            Regex hasLetter = new Regex(@"[a-zA-Z]+");
            Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            if (string.IsNullOrWhiteSpace(PostanskiBroj))
            {
                LblPostBrojErr = Messages.ValErrObaveznoPolje;
                IsValidno = false;
            }
            else if (hasLetter.IsMatch(PostanskiBroj))
            {
                LblPostBrojErr = Messages.ValErrFormatPostanskogBroja;
                IsValidno = false;
            }
            else if (hasSymbols.IsMatch(PostanskiBroj))
            {
                LblPostBrojErr = Messages.ValErrFormatPostanskogBroja;
                IsValidno = false;
            }
            else if (!regex.IsMatch(PostanskiBroj))
            {
                LblPostBrojErr = Messages.ValErrFormatPostanskogBroja;
                IsValidno = false;
            }
            else if (PostanskiBroj.Length > 15)
            {
                LblPostBrojErr = Messages.ValErrFormatPostanskogBroja;
                IsValidno = false;
            }
            else
            {
                LblPostBrojErr = null;
            }

            return IsValidno;
        }

    
        private bool EmailValidation()
        {
            bool IsValidno = true;
            if (string.IsNullOrWhiteSpace(Email))
            {
                LblEmailErr = Messages.ValErrObaveznoPolje;
                IsValidno = false;
            }
            else if (!Helper.Helper.ProvjeriMailFormat(Email)) // mail nije ispravnog formata
            {
                LblEmailErr = Messages.ValErrEmailFormat;
                IsValidno = false;
            }
            else
            {
                LblEmailErr = null;
            }

            return IsValidno;
        }
        private bool UsernameValidation()
        {
            bool IsValidno = true;
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrEmpty(Username))
            {
                LblUsernameErr = Messages.ValErrObaveznoPolje;
                IsValidno = false;
            }
            else if (Username.Length < 2)
            {
                LblUsernameErr = Messages.ValErrMin2Karaktera;
                IsValidno = false;
            }

            if (IsValidno == true)
            {
                LblUsernameErr = null;

            }
            return IsValidno;
        }

         private bool PasswordValidation()
         {
            bool IsValidno = true;
            Regex hasNumber = new Regex(@"[0-9]+");
            Regex hasLowerCase = new Regex(@"[a-z]+");
            Regex hasUpperCase = new Regex(@"[A-Z]+");
           
          
            if (string.IsNullOrWhiteSpace(Password) || string.IsNullOrEmpty(Password))
            {
                LblPasswordErr = Messages.ValErrObaveznoPolje;
                   IsValidno = false;
            }
            else if (Password.Length < 8 || Password.Length > 50)
            {
                LblPasswordErr = Messages.ValErrPasswordDuzina;
                IsValidno = false;
            }
            else if (!hasNumber.IsMatch(Password))
            {
                LblPasswordErr = Messages.ValErrPasswordFormat;
                IsValidno = false;
            }
            else if (!hasLowerCase.IsMatch(Password))
            {
                LblPasswordErr = Messages.ValErrPasswordFormat;
                IsValidno = false;
            }
            else if (!hasUpperCase.IsMatch(Password))
            {
                LblPasswordErr = Messages.ValErrPasswordFormat;
                IsValidno = false;
            }
            if (IsValidno == true)
            {
                   LblPasswordErr = null;
            }
               return IsValidno;
         }

        private bool PasswordConfirmationValidation()
        {
            bool IsValidno = true;
            if (string.IsNullOrWhiteSpace(PassConfirmation) || string.IsNullOrEmpty(PassConfirmation))
            {
                LblPassConfirmationErr = Messages.ValErrObaveznoPolje;
                IsValidno = false;
            }
            else if (PassConfirmation != Password)
            {
                LblPassConfirmationErr = Messages.ValErrPasswordConfirmation;
                IsValidno = false;
            }

            if (IsValidno == true)
            {
                LblPassConfirmationErr = null;
            }
            return IsValidno;
        }

        private bool GradValidation()
        {
            bool IsValidno = true;
            if (Grad == null)
            {
                LblGradErr = Messages.ValErrStavka;
                IsValidno = false;
            }
            else
            {
                LblGradErr = null;
            }
            return IsValidno;
        }

    }
}
