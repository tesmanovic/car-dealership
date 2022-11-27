using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace SmyzeTask.Helpers
{
    public static class YamlHelper
    {
        private static readonly string RootPath = Environment.GetEnvironmentVariable("ROOT_PATH");
        private static readonly string AssetsFolderName = @"\src\Assets\";
        public static string CreateUrlYamlFile(string fileName)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if(env == "Development")
                return Directory.GetCurrentDirectory()+ AssetsFolderName+ fileName.ToLower() + ".yaml";
            return RootPath+AssetsFolderName + fileName.ToLower() + ".yaml";
        }

        public static async Task<T> MapObjectFromYaml<T>(string filePath) where T : class
        {
            try
            {
                var deserializer = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();

                var input = await File.ReadAllTextAsync(filePath);

                var result = deserializer.Deserialize<T>(input);

                if (result == null)
                    throw new Exception($"Deserialization faild. Data from " + filePath + " is not properly .");

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
