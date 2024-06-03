using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EntrevistaUltimus.ViewModels
{
    public class UserViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido no puede tener más de 100 caracteres.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de nacimiento no es válida.")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [StringLength(15, ErrorMessage = "El número de teléfono no puede tener más de 15 caracteres.")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [StringLength(100, ErrorMessage = "El correo electrónico no puede tener más de 100 caracteres.")]
        [Remote(action: "VerifyEmail", controller: "User", ErrorMessage = "El correo electrónico ya está en uso.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La nacionalidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La nacionalidad no es válida.")]
        public int NationalityId { get; set; }

        [Required(ErrorMessage = "La residencia es obligatoria.")]
        [StringLength(200, ErrorMessage = "La residencia no puede tener más de 200 caracteres.")]
        public string Residency { get; set; }

        [Required(ErrorMessage = "El género es obligatorio.")]
        [Range(1, 2, ErrorMessage = "El género no es válido.")]
        public int Gender { get; set; }
    }
}
