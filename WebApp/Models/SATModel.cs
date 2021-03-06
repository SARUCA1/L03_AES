using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Helpers;

namespace WebApp.Models
{
    public class SATModel 
    {
        [StringLength(11)]
        [Index(0)]
        public string ID { get; set; }
        [StringLength(60)]
        [Index(1)]
        public string Email { get; set; }
        [StringLength(60)]
        [Index(2)]
        public string Propietario { get; set; }
        [StringLength(20)]
        [Index(3)]
        public string Color { get; set; }
        [StringLength(30)]
        [Index(4)]
        public string Marca { get; set; }
        [StringLength(100)]
        [Index(5)]
        public string Serie { get; set; }

        public static bool Save(SATModel model)
        {
            //Data.Instance.Lista.Add<SATModel>(model);
            Data.Instance.Lista.Insertar(model, Comparar.CompEmail);
            Data.Instance.ArbolID.Insertar(model, Comparar.CompID);
            Data.Instance.ArbolSerial.Insertar(model, Comparar.CompSerial);
            return true;
        }

        public int CompareTo(object obj)
        {
            var sat = (SATModel)obj;
            return ID.CompareTo(sat.ID);
        }
    }
}
