using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ITicketService
    {
        Task<object> ResrvationTicket(ReservationRequest reservation,int userid);
        Task<List<TicketResponse>> GetTickets(int userid);
    }
}
