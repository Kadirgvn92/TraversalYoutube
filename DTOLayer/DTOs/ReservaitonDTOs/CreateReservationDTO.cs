﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.DTOLayer.DTOs.ReservaitonDTOs;
public class CreateReservationDTO
{
    public int AppUserId { get; set; }
    public string? PersonCount { get; set; }
    public DateTime ReservationDate { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public int DestinationID { get; set; }
}
