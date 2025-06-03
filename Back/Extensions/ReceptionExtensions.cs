using Back.Dtos;
using Back.Models;

namespace Back.Extensions;

public static class ReceptionExtensions
{
    public static ReceptionEntity ToReception(this PostReceptionDTO postReceptionDTO)
    {
        return new()
        {
            length = postReceptionDTO.Length,
            DateOfAppointment = DateOnly.FromDateTime(DateTime.Now),
            MedicalCardId = postReceptionDTO.MedicalCardId
        };
    }
    
}