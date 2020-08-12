using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoClub.Entities;

namespace VideoClub.Validaciones
{
    public class ValidacionMayorEdad18 : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cliente = (Cliente)validationContext.ObjectInstance;

            if (cliente.TipoMembresiaId == TipoMembresia.Desconocido ||
                cliente.TipoMembresiaId == TipoMembresia.Prepago)
            {
                return ValidationResult.Success;
            }


            if (cliente.FechaNacimiento != null)
            {

                var edad = DateTime.Today.Year - cliente.FechaNacimiento.Value.Year;



                return (edad >= 18)
                    ? ValidationResult.Success
                    : new ValidationResult("El cliente debe tener al menos 18 años para ser miembro.");

            }
            else
            {
                return ValidationResult.Success;
            }





        }
    }


}