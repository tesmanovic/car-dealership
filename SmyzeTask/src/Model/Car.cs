using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmyzeTask.Model
{
    public class Car
    {
        public string Manufacturer { get; set; }
        public CarModel Model { get; set; }
        public CarOffer Offer { get; set; }

        public string ToFlatJson() {
            dynamic obj = new ExpandoObject();
            obj.manufacturer = this.Manufacturer;
            obj.model = this.Model.Model;
            obj.color = this.Offer.Color;
            obj.hp = this.Offer.Hp;
            obj.engine = this.Offer.Engine;
            obj.fuel = this.Offer.Fuel;
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

    }
}
