using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace ComoViajamos.ViewModels
{
    public class TravelReviewViewModel
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public String DatetimeFrom { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public String DatetimeUntil { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int TravelFeelingId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int[] TravelFeelingReasonIds { get; set; }

        [MaxLength(500, ErrorMessage = "Este campo no puede tener más de 500 caracteres")]
        public String Comments { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int TransportId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int TransportBranchId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int TransportBranchOrientationId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public String CaptchaToken { get; set; }
    }
}
