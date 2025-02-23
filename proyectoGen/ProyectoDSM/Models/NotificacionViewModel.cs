﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProyectoGenNHibernate.Enumerated.Proyecto;

namespace ProyectoDSM.Models
{
    public class NotificacionViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }


        [Display(Prompt = "El tipo de notificacion", Description = "El tipo de notificacion", Name = "Tipo de Notificación")]
        [Required(ErrorMessage = "Debe indicar el tipo de notificación")]
        public TipoNotificacionEnum Tipo { get; set; }

        [Display(Prompt = "El contenido de la notificación", Description = "El contenido de la notificación", Name = "Contenido")]
        [Required(ErrorMessage = "Debe indicar el contenido de la notificación")]
        [StringLength(maximumLength: 4000, ErrorMessage = "La notificacion no puede tener más de 4000 caracateres")]
        public string Contenido { get; set; }
        [Display(Prompt = "Id del tipo de notificacion con el que está relacionado", Description = "Id del tipo de notificacion con el que está relacionado", Name = "Id del tipo (id de premium, etc.)")]
        [Required(ErrorMessage = "Debe indicar el id del tipo de mensaje")]
        public int Id_tipo { get; set; }

        
    }
}