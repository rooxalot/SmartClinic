using System;

namespace SmartClinic.Domain.Interfaces.Context
{
    public interface ISmartClinicContext : IDisposable
    {
        int SaveChanges();
    }
}