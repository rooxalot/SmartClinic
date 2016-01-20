using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SmartClinic.Domain.Entities.Business;
using SmartClinic.Domain.Enums;
using SmartClinic.Domain.ValueObjects;

namespace SmartClinic.Data.Context
{
    public class SmartClinicTestInitializer : DropCreateDatabaseAlways<SmartClinicContext>
    {
        protected override void Seed(SmartClinicContext context)
        {
            //Add user
            var user = new User("admin", "power123", true, UserType.Administrator);
            context.Users.Add(user);

            //Add Clinic
            var clinic = new Clinic("SmartClinicDefault", "Cuidando de você", new Cnpj(59899760000165), new Phone(59318988, 11));
            context.Clinics.Add(clinic);

            //Add Secretaries
            var secretary = new Secretary("Anna Rosa", new Rg(0987890675), new Phone(29894434),
                new Address("Rua Padre Gabriel Campos", "Próx. ao Octacilio", "292", "Arthur Alvim", "São Paulo", Uf.SP),
                Sex.Feminino);
            context.Secretaries.Add(secretary);

            //Add Doctor
            var doctor1 = new Doctor("Carlos Luiz", new Rg(0989098975), new Crm("8904756457", Uf.SP), true, Sex.Masculino, 
                new Address("Av Waldemar Tietz", "", "614", "Arthur Alvim", "São Paulo", Uf.SP));

            var doctor2 = new Doctor("Sandra", new Rg(5678916530), new Crm("8904067454", Uf.SP), true, Sex.Feminino,
                new Address("Av Pablo Luiz", "Próximo ao Extra", "4566", "Arthur Alvim", "Rio de Janeiro", Uf.RJ));

            var doctors = new List<Doctor> {doctor1, doctor2};
            context.Doctors.AddRange(doctors);

            //Add Covenant
            var covenants = new List<Covenant>()
            { 
                new Covenant("Sancil", true, DateTime.Now, DateTime.Now.AddYears(2), new Phone(89518988, 11), new Cnpj(59899760580165), "Consultas a domicilio e plano odontológico."),
                new Covenant("UltraMed", true, DateTime.Now, DateTime.Now.AddYears(1), new Phone(), new Cnpj(59896980580160)),
                new Covenant("Amil", true, DateTime.Now, DateTime.Now.AddYears(1), new Phone(), new Cnpj(57796980580163)),
                new Covenant("Sem convênio", true, DateTime.Now, DateTime.MaxValue, null, null)
            };
            context.Covenants.AddRange(covenants);
            context.SaveChanges();

            //Add Pacient
            var pacient1 = new Pacient("Rodrigo Martins",
                new Address("Av Waldemar Tietz", "", "614", "Arthur Alvim", "São Paulo", Uf.SP),
                new Phone(), new Rg(), Sex.Masculino, covenants.FirstOrDefault());

            var pacient2 = new Pacient("Maria Inez",
                new Address("Av Waldemar Tietz", "", "614", "Arthur Alvim", "São Paulo", Uf.SP),
                new Phone(), new Rg(), Sex.Masculino, covenants[1]);

            var pacients = new List<Pacient> {pacient1, pacient2};
            context.Pacients.AddRange(pacients);

            //Add Appointment
            var appointment1 = new Appointment(doctor2, pacient1, covenants.FirstOrDefault(), DateTime.Now,
                450.00M, AppointmentType.Internal);

            var appointment2 = new Appointment(doctor1, pacient1, covenants.FirstOrDefault(), DateTime.Now,
                750.00M, AppointmentType.External);

            var appointments = new List<Appointment> {appointment1, appointment2};
            context.Appointments.AddRange(appointments);

            base.Seed(context);
        }
    }
}