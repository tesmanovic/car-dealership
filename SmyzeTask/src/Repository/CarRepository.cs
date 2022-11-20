using SmyzeTask.Helpers;
using SmyzeTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmyzeTask.Repository
{
    public class CarRepository
    {
        private static string GetBrandPath(string brand)
        {
            return YamlHelper.CreateUrlYamlFile(brand);
        }

        private static string GetModelPath(string brand, string model)
        {
            return YamlHelper.CreateUrlYamlFile((string.Join("\\", new string[] { brand, Convert.ToString(model) })));
        }

        private static string GetOfferPath(string brand, string model, string offer)
        {
            return YamlHelper.CreateUrlYamlFile(string.Join("\\", new string[] { brand, Convert.ToString(model), Convert.ToString(offer) }));
        }

        public static async Task<Car> GetCar(string brand, string model, string offer)
        {
            var car = await YamlHelper.MapObjectFromYaml<Car>(GetBrandPath(brand));
            car.Model = await YamlHelper.MapObjectFromYaml<CarModel>(GetModelPath(brand, model));
            car.Offer = await YamlHelper.MapObjectFromYaml<CarOffer>(GetOfferPath(brand, model, offer));

            return car;
        }
    }
}
