using ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Dtos.Character
{
    public class DeleteCharacterDto
    {
        public int Id { get; set; }
        public String Name { get; set; } = "Mohammad";
        public int HitPoints { get; set; } = 100;
        public int Strngth { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intellegence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}
