using SmartParking.DataService;
using SmartParking.Model;
using SmartParking.Validators;
using SmartParking.Validators.Rules;
using SmartParking.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SmartParking.ViewModels
{
    /// <summary>
    /// ViewModel for sign-up page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SignUpPageViewModel : LoginViewModel
    {
        #region Fields
        private ValidatableObject<string> name;
        private ValidatablePair<string> password;
        private ValidatableObject<string> direccion;
        private ValidatableObject<string> telefono;
        private ValidatableObject<string> contactoNombres;
        private ValidatableObject<string> contactoTelefono;
        private ObservableCollection<CentralEmergencia> centralEmergencias;
        private CentralEmergencia centralEmergenciaSelected;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance for the <see cref="SignUpPageViewModel" /> class.
        /// </summary>
        public SignUpPageViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
            GetCentralesEmergencia();
        }
        #endregion

        #region Property
        public ObservableCollection<CentralEmergencia> CentralEmergencias
        {
            get
            {
                return centralEmergencias;
            }
            set
            {
                if (centralEmergencias == value)
                {
                    return;
                }

                SetProperty(ref centralEmergencias, value);
            }
        }

        public CentralEmergencia CentralEmergenciaSelected
        {
            get
            {
                return centralEmergenciaSelected;
            }

            set
            {
                centralEmergenciaSelected = value;
                NotifyPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the name from user in the Sign Up page.
        /// </summary>
        public ValidatableObject<string> Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name == value)
                {
                    return;
                }

                this.SetProperty(ref this.name, value);
            }
        }
        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the password from users in the Sign Up page.
        /// </summary>
        public ValidatablePair<string> Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.SetProperty(ref this.password, value);
            }
        }
        public ValidatableObject<string> Direccion
        {
            get
            {
                return this.direccion;
            }

            set
            {
                if (this.direccion == value)
                {
                    return;
                }

                this.SetProperty(ref this.direccion, value);
            }
        }
        public ValidatableObject<string> Telefono
        {
            get
            {
                return this.telefono;
            }

            set
            {
                if (this.telefono == value)
                {
                    return;
                }

                this.SetProperty(ref this.telefono, value);
            }
        }
        public ValidatableObject<string> ContactoNombres
        {
            get
            {
                return this.contactoNombres;
            }

            set
            {
                if (this.contactoNombres == value)
                {
                    return;
                }

                this.SetProperty(ref this.contactoNombres, value);
            }
        }
        public ValidatableObject<string> ContactoTelefono
        {
            get
            {
                return this.contactoTelefono;
            }

            set
            {
                if (this.contactoTelefono == value)
                {
                    return;
                }

                this.SetProperty(ref this.contactoTelefono, value);
            }
        }
        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Initialize whether fieldsvalue are true or false.
        /// </summary>
        /// <returns>true or false </returns>
        public bool AreFieldsValid()
        {
            bool isEmail = this.Email.Validate();
            bool isNameValid = this.Name.Validate();
            bool isPasswordValid = this.Password.Validate();
            bool isDireccion = this.Direccion.Validate();
            bool isTelefono = this.Telefono.Validate();
            bool isContactoNombres = this.ContactoNombres.Validate();
            bool isContactoTelefono = this.ContactoTelefono.Validate();
            return isPasswordValid && isNameValid && isEmail && isDireccion && isTelefono && isContactoNombres && isContactoNombres && isContactoTelefono;
        }

        /// <summary>
        /// Initializing the properties.
        /// </summary>
        private void InitializeProperties()
        {
            this.Name = new ValidatableObject<string>();
            this.Password = new ValidatablePair<string>();
            this.Direccion = new ValidatableObject<string>();
            this.Telefono = new ValidatableObject<string>();
            this.ContactoNombres = new ValidatableObject<string>();
            this.ContactoTelefono = new ValidatableObject<string>();
        }

        /// <summary>
        /// this method contains the validation rules
        /// </summary>
        private void AddValidationRules()
        {
            this.Name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Nombre completos Requerida" });
            this.Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Clave Requerida" });
            this.Password.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Repetir clave requerida" });
            this.Direccion.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Dirección requerida" });
            this.Telefono.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Telefono requerido" });
            this.contactoNombres.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Contacto nombres requerido" });
            this.contactoTelefono.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Contacto telefono requerido" });
        }

        /// <summary>
        /// Invoked when the Log in button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoginClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SignUpClicked(object obj)
        {
            if (this.AreFieldsValid())
            {
                Usuario usuario = new Usuario();
                usuario.nombresCompletos = name.ToString();
                usuario.clave = Password.Item1.ToString();
                usuario.usuario = Email.ToString();
                usuario.direccion = Direccion.ToString();
                usuario.telefono = Telefono.ToString();
                usuario.contactoNombres = ContactoNombres.ToString();
                usuario.contactoTelefono = ContactoTelefono.ToString();
                usuario.centralEmergenciaId = CentralEmergenciaSelected.ID;
                
                var usuarioRespuesta = ApiService.Instance.PostUsuarioRegistro(usuario);

                if(usuarioRespuesta != null)
                {
                    LimpiarCampos();
                    Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                }
            }
        }

        private void GetCentralesEmergencia()
        {
            try
            {
                List<CentralEmergencia> centralesEmergencia = ApiService.Instance.GetCentralesEmergencia().Result;

                if (centralesEmergencia == null)
                {
                    CentralEmergencias = new ObservableCollection<CentralEmergencia>();
                }
                else
                {
                    CentralEmergencias = new ObservableCollection<CentralEmergencia>(centralesEmergencia);
                    CentralEmergenciaSelected = centralEmergencias.First();
                }                                                
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error: " + e);
            }
        }

        private void LimpiarCampos()
        {
            this.Email.Value = "";
            this.Password.Item1.Value = "";
            this.Password.Item2.Value = "";
            this.Direccion.Value = "";
            this.Telefono.Value = "";
            this.ContactoTelefono.Value = "";
            this.ContactoNombres.Value = "";
        }
        #endregion
    }
}