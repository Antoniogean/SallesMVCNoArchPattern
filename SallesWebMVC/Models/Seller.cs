﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SallesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Data de aniversário")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Salário base")]
        [Range(100.0, 5000.0, ErrorMessage ="{0} must be from {1} to {2}")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        [DataType(DataType.Currency)]
        public double BaseSalary { get; set; }

        [ValidateNever]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord record)
        {
            SalesRecords.Add(record);
        }

        public double TotalSales(DateTime initialDate, DateTime finalDate) 
        {
            return SalesRecords.Where(records => records.Date >= initialDate && records.Date <= finalDate).Sum(records => records.Amount);
        }

        public static implicit operator Seller(Task<Seller> v)
        {
            throw new NotImplementedException();
        }
    }
}
