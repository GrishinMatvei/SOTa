using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pleasantRustle
{
   partial  class Agents
    {

        public byte[] LogoTip
        {
            get
            {
                string logoMod;
                if (Logo.Length >= 1)
                    logoMod = Logo.Substring(1);
                else return File.ReadAllBytes("logo.png");
                if (File.Exists($"{logoMod}"))
                { return File.ReadAllBytes($"{logoMod}"); }
                return File.ReadAllBytes("logo.png"); ;
            }
        }

        public int Skidka
        {
            get
            {
                decimal sum = (decimal)ProductRealization.Sum(s => s.Count * s.Products.PriceMin);
                if (sum < 10000) { return 0; }
                if (sum >= 10000 && sum < 50000) { return 5; }
                if (sum >= 50000 && sum < 150000) { return 10; }
                if (sum >= 150000 && sum < 500000) { return 20; }
                return 25;
            }
        }

        public string AType
        {
            get
            {
                return $"{AgentTypes.TypeName}";
            }
        }

        public string NameCompany1
        {
            get
            {
                return $"{NameCompany}";
            }
        }
        public string CountRealization
        {
            get
            {
                int sum = ProductRealization.Sum(s => s.Count);
                return sum.ToString() + " продаж за год";
            }

        }
    }
}
