using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer.RequestModels
{
    public class DeleteModel
    {
        [Required(ErrorMessage ="Id is required")]
        public int EmployeeId { get; set; }
    }
}
